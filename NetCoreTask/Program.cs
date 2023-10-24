using Microsoft.EntityFrameworkCore;

using NetCoreTask.DataBase;
using NetCoreTask.DataBase.Entities;
using NetCoreTask.DataBase.Repository.Abstract;
using NetCoreTask.DataBase.Repository.Services;
using NetCoreTask.Models.Dto;
using NetCoreTask.Services;
using NetCoreTask.Services.Abstractions;

using Swashbuckle.AspNetCore.SwaggerUI;

namespace NetCoreTask;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
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
            app.UseSwaggerUI(c =>
            {
                c.ConfigObject = new ConfigObject
                {
                    ShowCommonExtensions = true
                };
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}