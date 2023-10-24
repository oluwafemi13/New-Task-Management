using Management.Application.Contracts;
using Management.Infrastructure.Data;
using Management.Infrastructure.Repositories;
using Management.Infrastructure.Services;
using Management.Infrastructure.Services.Background_Services;
using Management.Infrastructure.Services.Business_Logic;
using Management.Infrastructure.Services.Worker;
using Management.Infrastructure.Services.Worker.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Task_Management.Infrastructure.Services.Worker.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DatabaseContext>(option =>

    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient, ServiceLifetime.Transient);



builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<ITaskRepository, TaskRepository>();
builder.Services.AddTransient<IMarkedComplete, MarkedComplete>();
builder.Services.AddTransient<IWorker, UserTaskCompleted>();
builder.Services.AddTransient<IWorker, AssignedNewTask>();
builder.Services.AddHostedService<MarkedCompletedService>();
builder.Services.AddHostedService<AssignedNewTaskService>();
builder.Services.AddHostedService<MarkedUserTaskCompleted>();
builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<INotificationRepository, NotificationRepository>();
builder.Services.AddTransient<INotificationService, NotificationService>();
builder.Services.AddTransient<IUserservice, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
