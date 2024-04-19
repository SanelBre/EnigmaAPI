using EnigmaAPI.DataAccess;
using EnigmaAPI.Extensions;
using EnigmaAPI.Utils.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNameCaseInsensitive = false);
builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddSingleton<Seeder>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

await app.Services.SeedDataAsync();

app.Run();
