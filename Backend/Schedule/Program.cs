using Microsoft.EntityFrameworkCore;
using Schedule.Data;
using Schedule.Services;

var builder = WebApplication.CreateBuilder(args);

// Database
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ScheduleDbContext>(options => options.UseSqlServer(connection));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAudienceAdminService, AudienceAdminService>();
builder.Services.AddScoped<IGroupAdminService, GroupAdminService>();
builder.Services.AddScoped<ISubjectAdminService, SubjectAdminService>();
builder.Services.AddScoped<ITeacherAdminService, TeacherAdminService>();

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
