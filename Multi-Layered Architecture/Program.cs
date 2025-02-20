using Microsoft.EntityFrameworkCore;
using Multi_Layered_Architecture.part5.Data;
using Multi_Layered_Architecture.part5.Repositories;
using Multi_Layered_Architecture.part5.Services;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình kết nối SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Cấu hình Dependency Injection
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<MovieService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
app.Run();

