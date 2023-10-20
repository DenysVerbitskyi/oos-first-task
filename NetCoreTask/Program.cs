using Mapster;

using Microsoft.EntityFrameworkCore;

using NetCoreTask.Client.Services;
using NetCoreTask.DataBase;
using NetCoreTask.DataBase.Entities;
using NetCoreTask.DataBase.Repository.Abstract;
using NetCoreTask.DataBase.Repository.Services;
using NetCoreTask.Models;
using NetCoreTask.Services;
using NetCoreTask.Services.Abstractions;

namespace NetCoreTask;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<UniversityDbContext>(config =>
            config.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        builder.Services.AddScoped<IRepository<StudentEntity>, StudentsRepository>();
        builder.Services.AddScoped<IRepository<TeacherEntity>, TeachersRepository>();
        builder.Services.AddScoped<IRepository<CourseEntity>, CoursesRepository>();

        builder.Services.AddScoped<IApiService<StudentDto>, StudentsService>();
        builder.Services.AddScoped<IApiService<CourseDto>, CoursesService>();
        builder.Services.AddScoped<IApiService<TeacherDto>, TeachersService>();

        //builder.Services.AddSingleton<IDataMapper, DataMapper>();

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
    }
}