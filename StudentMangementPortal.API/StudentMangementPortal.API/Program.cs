using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using StudentMangementPortal.API.Data.Models;
using StudentMangementPortal.API.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<StudentDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("StudentDb")));
builder.Services.AddScoped<IStudentRepository,StudentRepository>();
builder.Services.AddScoped<IImageRepository,ImageRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("angularApplication", (builder) =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .WithMethods("GET", "POST", "PUT", "DELETE")
        .WithExposedHeaders("*");
    });
});
builder.Services.AddControllers();

builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddFluentValidation(conf =>
//{
//    conf.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
//    conf.AutomaticValidationEnabled = false;
//});
builder.Services.AddAutoMapper(typeof(Program).Assembly);//--------Auto mapping
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions {
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath,"Resources")),
    RequestPath= "/Resources"
});
app.UseCors("angularApplication");
app.UseAuthorization();

app.MapControllers();

app.Run();
