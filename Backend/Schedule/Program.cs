using Microsoft.EntityFrameworkCore;
using Schedule.Data;
using Schedule.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy => policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// Database
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ScheduleDbContext>();

// Services
builder.Services.AddScoped<IAudienceAdminService, AudienceAdminService>();
builder.Services.AddScoped<IGroupAdminService, GroupAdminService>();
builder.Services.AddScoped<ISubjectAdminService, SubjectAdminService>();
builder.Services.AddScoped<ITeacherAdminService, TeacherAdminService>();
builder.Services.AddScoped<ILessonAdminService, LessonAdminService>();
builder.Services.AddScoped<IConverterService, ConverterService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<ISelectionService, SelectionService>();


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

app.UseCors();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
