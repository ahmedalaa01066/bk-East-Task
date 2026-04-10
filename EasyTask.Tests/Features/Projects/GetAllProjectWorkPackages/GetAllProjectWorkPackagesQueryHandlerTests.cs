using EasyTask.Common.Endpoints;
using EasyTask.Common.Requests;
using EasyTask.Data;
using EasyTask.Features.Projects.GetAllProjectWorkPackages.Queries;
using EasyTask.Models.Enums;
using EasyTask.Models.WorkPackageDependencies;
using EasyTask.Models.WorkPackages;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EasyTask.Tests.Features.Projects.GetAllProjectWorkPackages;

public class GetAllProjectWorkPackagesQueryHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnProjectWorkPackages_WithCorrectDependencyMappings()
    {
        var dbName = $"GetAllProjectWorkPackages_{Guid.NewGuid()}";
        await using var context = new TestEntities(dbName);

        var projectId = "project-1";

        var wp1 = new WorkPackage
        {
            ID = "wp-1",
            Name = "Work Package 1",
            ProjectId = projectId,
            StartDate = new DateTime(2026, 1, 1),
            EndDate = new DateTime(2026, 1, 10)
        };

        var wp2 = new WorkPackage
        {
            ID = "wp-2",
            Name = "Work Package 2",
            ProjectId = projectId,
            StartDate = new DateTime(2026, 1, 11),
            EndDate = new DateTime(2026, 1, 20)
        };

        var otherProjectWp = new WorkPackage
        {
            ID = "wp-3",
            Name = "Other Project Work Package",
            ProjectId = "project-2",
            StartDate = new DateTime(2026, 2, 1),
            EndDate = new DateTime(2026, 2, 10)
        };

        var dependency = new WorkPackageDependency
        {
            ID = "dep-1",
            DependencyType = Dependencies.FinishToStart,
            SourceWorkPackageId = "wp-1",
            DestinationWorkPackageId = "wp-2"
        };

        context.WorkPackages.AddRange(wp1, wp2, otherProjectWp);
        context.WorkPackageDependencies.Add(dependency);
        await context.SaveChangesAsync();

        var repository = new Repository<WorkPackage>(context, new UserState { UserID = "test-user" });
        var requestParameters = new RequestHandlerBaseParameters<WorkPackage>(new NoOpMediator(), new UserState { UserID = "test-user" }, repository);
        var handler = new GetAllProjectWorkPackagesQueryHandler(requestParameters);

        var result = await handler.Handle(new GetAllProjectWorkPackagesQuery(projectId), CancellationToken.None);

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Data);
        Assert.Equal(2, result.Data.WorkPackages.Count);

        var first = result.Data.WorkPackages.Single(x => x.Id == "wp-1");
        Assert.Single(first.OutgoingDependencies);
        Assert.Equal(Dependencies.FinishToStart, first.OutgoingDependencies[0].DependencyType);
        Assert.Equal("wp-2", first.OutgoingDependencies[0].WorkPackageId);
        Assert.Empty(first.IncomingDependencies);

        var second = result.Data.WorkPackages.Single(x => x.Id == "wp-2");
        Assert.Single(second.IncomingDependencies);
        Assert.Equal(Dependencies.FinishToStart, second.IncomingDependencies[0].DependencyType);
        Assert.Equal("wp-1", second.IncomingDependencies[0].WorkPackageId);
        Assert.Empty(second.OutgoingDependencies);
    }

    [Fact]
    public async Task Handle_ShouldReturnEmptyList_WhenProjectHasNoWorkPackages()
    {
        var dbName = $"GetAllProjectWorkPackages_Empty_{Guid.NewGuid()}";
        await using var context = new TestEntities(dbName);

        context.WorkPackages.Add(new WorkPackage
        {
            ID = "wp-1",
            Name = "Other Project Work Package",
            ProjectId = "another-project",
            StartDate = new DateTime(2026, 3, 1),
            EndDate = new DateTime(2026, 3, 10)
        });

        await context.SaveChangesAsync();

        var repository = new Repository<WorkPackage>(context, new UserState { UserID = "test-user" });
        var requestParameters = new RequestHandlerBaseParameters<WorkPackage>(new NoOpMediator(), new UserState { UserID = "test-user" }, repository);
        var handler = new GetAllProjectWorkPackagesQueryHandler(requestParameters);

        var result = await handler.Handle(new GetAllProjectWorkPackagesQuery("project-without-workpackages"), CancellationToken.None);

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Data);
        Assert.Empty(result.Data.WorkPackages);
    }

    private sealed class TestEntities(string dbName) : Entities
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(dbName);
        }
    }

    private sealed class NoOpMediator : IMediator
    {
        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
            => throw new NotSupportedException();

        public Task Send<TRequest>(TRequest request, CancellationToken cancellationToken = default)
            where TRequest : IRequest
            => throw new NotSupportedException();

        public Task<object?> Send(object request, CancellationToken cancellationToken = default)
            => throw new NotSupportedException();

        public IAsyncEnumerable<TResponse> CreateStream<TResponse>(IStreamRequest<TResponse> request, CancellationToken cancellationToken = default)
            => EmptyAsync<TResponse>();

        public IAsyncEnumerable<object?> CreateStream(object request, CancellationToken cancellationToken = default)
            => EmptyAsync<object?>();

        public Task Publish(object notification, CancellationToken cancellationToken = default)
            => Task.CompletedTask;

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
            where TNotification : INotification
            => Task.CompletedTask;

        private static async IAsyncEnumerable<T> EmptyAsync<T>()
        {
            await Task.CompletedTask;
            yield break;
        }
    }
}
