using MicroserviceTeachers;
using MicroserviceTeachers.Services;
using MicroserviceTeachers.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<TeacherContext>(builder.Configuration.GetConnectionString("TeacherConnectionString"));
builder.Services.AddScoped<ITeacher, Teacher>();
builder.Services.AddScoped<ITeacherContext, TeacherContext>();
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
