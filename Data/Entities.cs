using EasyTask.Helpers;
using EasyTask.Models.Attendances;
using EasyTask.Models.CandidateCourses;
using EasyTask.Models.CandidateKPIs;
using EasyTask.Models.Candidates;
using EasyTask.Models.CandidateTasks;
using EasyTask.Models.CandidateVacations;
using EasyTask.Models.Courses;
using EasyTask.Models.DefaultKPIs;
using EasyTask.Models.Departments;
using EasyTask.Models.Documents;
using EasyTask.Models.Emails;
using EasyTask.Models.ExternalComapnies;
using EasyTask.Models.ExternalMembers;
using EasyTask.Models.ExternalMemberTasks;
using EasyTask.Models.Jobs;
using EasyTask.Models.KPIs;
using EasyTask.Models.Levels;
using EasyTask.Models.Managements;
using EasyTask.Models.Medias;
using EasyTask.Models.PauseShifts;
using EasyTask.Models.Penalities;
using EasyTask.Models.PermissionLogs;
using EasyTask.Models.PermissionRequests;
using EasyTask.Models.Permissions;
using EasyTask.Models.PlannedShifts;
using EasyTask.Models.Positions;
using EasyTask.Models.Projects;
using EasyTask.Models.ProjectTasks;
using EasyTask.Models.ProjectTypes;
using EasyTask.Models.RoleFeatures;
using EasyTask.Models.Shifts;
using EasyTask.Models.SpecialDays;
using EasyTask.Models.TaskDependencies;
using EasyTask.Models.Users;
using EasyTask.Models.VacationRequests;
using EasyTask.Models.Vacations;
using EasyTask.Models.WorkPackageDependencies;
using EasyTask.Models.WorkPackages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Diagnostics;

namespace EasyTask.Data;

public class Entities : DbContext
{
    public Entities()
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }
    public DbSet<Media> Medias { get; set; }
    public DbSet<RoleFeature> RoleFeatures { get; set; }
    public DbSet<Email> Emails { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Management> Managements { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Level> Levels { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Penality> Penalities { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<Course> courses { get; set; }
    public DbSet<CandidateCourse> candidateCourses { get; set; }
    public DbSet<KPI> KPIs { get; set; }
    public DbSet<DefaultKPI> DefaultKPIs { get; set; }
    public DbSet<CandidateKPI> CandidateKPIs { get; set; }
    public DbSet<Shift> Shifts { get; set; }
    public DbSet<PlannedShift> PlannedShifts { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<PauseShift> PauseShifts { get; set; }
    public DbSet<Vacation> Vacations { get; set; }
    public DbSet<VacationRequest> VacationRequests { get; set; }
    public DbSet<CandidateVacation> CandidateVacations { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<PermissionRequest> PermissionRequests { get; set; }
    public DbSet<SpecialDay> SpecialDays { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<PermissionLog> PermissionLogs { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectType> ProjectTypes { get; set; }
    public DbSet<ExternalMember> ExternalMembers { get; set; }
    public DbSet<ExternalCompany> ExternalCompanies { get; set; }
    public DbSet<WorkPackage> WorkPackages { get; set; }
    public DbSet<WorkPackageDependency> WorkPackageDependencies { get; set; }
    public DbSet<ProjectTask> ProjectTasks { get; set; }
    public DbSet<TaskDependency> TaskDependencies { get; set; }
    public DbSet<CandidateTask> CandidateTasks { get; set; }
    public DbSet<ExternalMemberTask> ExternalMemberTasks { get; set; }
    public DbSet<CandidateProject> CandidateProjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConfigurationHelper.GetConnectionString())
            .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
            .EnableSensitiveDataLogging()
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .ConfigureWarnings(w => w.Ignore(SqlServerEventId.SavepointsDisabledBecauseOfMARS));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Instructor>().ToTable("Instructor", schema: "HR");
        //  modelBuilder.Entity<Phone>()
        // .HasIndex(p => new { p.IMEI1, p.SerialNumber })
        // .IsUnique();

        modelBuilder.Entity<Level>()
      .HasIndex(L => new { L.Sequence })
      .IsUnique();

        //  modelBuilder.Entity<Client>()
        //.HasIndex(p => new { p.Email, p.Mobile })
        //.IsUnique();

        modelBuilder.Entity<CandidateKPI>()
        .HasIndex(ck => new { ck.CandidateId, ck.KPIId })
        .IsUnique();
        
        modelBuilder.Entity<CandidateProject>()
        .HasIndex(ck => new { ck.CandidateId, ck.ProjectId })
        .IsUnique();
    }
}
