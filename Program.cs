using ProjectTracker.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ProjectTrackerDatabaseSettings>(
    builder.Configuration.GetSection("ProjectTrackerDatabase"));
builder.Services.AddSingleton<TaskService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

app.MapControllers();
app.Run();