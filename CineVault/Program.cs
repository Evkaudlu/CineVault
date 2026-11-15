
using CineVault.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Визначення активного середовища
var environment = builder.Environment.EnvironmentName;

Console.WriteLine(
    $"=== Запуск у середовищі: {environment} ===");

// Отримання конфігурації підключення
var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection");

Console.WriteLine(
    $"Рядок підключення налаштовано: {!string.IsNullOrWhiteSpace(connectionString)}");

// Реєстрація контролерів
builder.Services.AddControllers();

// ЛР №8. Налаштування версійності API
builder.Services.AddApiVersioningWithApiExplorer();

// ЛР №8. Swagger для кількох версій API
builder.Services.AddSwaggerWithOptions();

var app = builder.Build();

// Swagger доступний лише в Development
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerWithOptions();
}

// Сторінка помилок для Local
if (app.Environment.IsLocal())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
