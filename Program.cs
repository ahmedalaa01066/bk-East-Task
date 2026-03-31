using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using EasyTask.Common;
using EasyTask.Configurations;
using EasyTask.Features.Common.Medias.DTOs;
using EasyTask.Features.Emails.SendEmailToClients;
using EasyTask.Helpers;
using EasyTask.Middlewares;
using FirebaseAdmin;
using FluentValidation;
using Google.Apis.Auth.OAuth2;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Cross-origin
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
    builder.RegisterModule(new AutofacModule()));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddAutoMapper(typeof(MediaDTO));
//builder.Services.AddControllers()
//              .AddFluentValidation(fv =>
//              {
//                  fv.RegisterValidatorsFromAssemblyContaining<GetAllUsersRequestValidator>();
//              });
builder.Services.AddValidatorsFromAssemblyContaining<SendEmailToClientsRequestValidator>();

builder.Logging.ClearProviders();
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(ConfigurationHelper.GetConfiguration())
    .Enrich.WithMachineName()
    .Enrich.WithThreadId()
    .WriteTo.Seq("http://localhost:5341/")
    .WriteTo.MSSqlServer(connectionString: ConfigurationHelper.GetConnectionString(),
                     restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information,
                   sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true })
    .CreateLogger();
builder.Logging.AddSerilog();
Log.Information("starting App..");

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Program)));

// Configure JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "EasyTask",
        ValidAudience = "EasyTask-Users",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Constants.SecretKey))
    };
});
// Swagger Configuration
builder.Services.AddSwaggerGen(c =>
{
    c.MapType<TimeSpan>(() => new Microsoft.OpenApi.Models.OpenApiSchema
    {
        Type = "string",
        Example = new Microsoft.OpenApi.Any.OpenApiString("00:30:00")
    });
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EasyTask", Version = "v1" });
    
    // Configure Swagger to use JWT Authorization
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

//FirebaseApp.Create(new AppOptions()
//{
//    Credential = GoogleCredential.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "rag3ly-d6225-firebase-adminsdk-fbsvc-a7db045b8f.json")),
//});

builder.Services.AddHangfire(config =>
{
    config.UseSqlServerStorage(ConfigurationHelper.GetConnectionString(),
        new Hangfire.SqlServer.SqlServerStorageOptions
        {
            QueuePollInterval = TimeSpan.FromSeconds(1),
            CommandTimeout = TimeSpan.FromSeconds(1)
        });
});

builder.Services.AddHangfireServer();

builder.Services.AddScoped<TransactionMiddleware>();


var app = builder.Build();

app.UseHangfireDashboard("/hangfire"); // Optional dashboard

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

//recurring job for stolen phones

MapperHelper.Mapper = app.Services.GetService<IMapper>();
app.UseMiddleware<GlobalErrorHandlerMiddleware>();
app.UseMiddleware<TransactionMiddleware>();

app.UseCors();

// Configure Authentication & Authorization
app.UseHttpsRedirection();
app.UseAuthentication(); // This is essential for JWT authentication
app.UseAuthorization();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "wwwroot", "Media")),
    RequestPath = "/Media"
});
app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();
app.Run();