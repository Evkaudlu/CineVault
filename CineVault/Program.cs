
using CineVault.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Визначення активного середовища
var environment = builder.Environment.EnvironmentName;

Console.WriteLine(
    $"=== Запуск у середовищі: {environment} ===");

// Отримання налаштувань поточного середовища
var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection");

Console.WriteLine(
    $"Рядок підключення налаштовано: {!string.IsNullOrWhiteSpace(connectionString)}");

// Реєстрація сервісів
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger тільки для Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Сторінка помилок тільки для Local
if (app.Environment.IsLocal())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
