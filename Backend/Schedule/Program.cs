using Microsoft.EntityFrameworkCore;
using Schedule.Data;
using Schedule.Services;

var builder = WebApplication.CreateBuilder(args);

// Database
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ScheduleDbContext>(options => options.UseSqlServer(connection));

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


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsApi",
        builder => builder.WithOrigins("https://26.183.203.98:8082")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

app.UseCors("CorsApi");

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
