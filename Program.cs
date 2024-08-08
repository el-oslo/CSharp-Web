using Api.Data;
using Api.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>{
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "Cours API", Description = "Bring me today's schedule", Version = "v1"});
});

builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
});

builder.Services.AddControllers().AddNewtonsoftJson(options => {
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<CoursContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options => {
    options.AddPolicy("AllowReactApp",
        build=>{
            build.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
        }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c=>{
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cours API v1");
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowReactApp");
app.MapControllers();
app.Run();