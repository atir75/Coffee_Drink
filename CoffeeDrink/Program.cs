using CoffeeDrink.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os ao cont�iner.
builder.Services.AddControllers();

// Adiciona a configura��o do servi�o ICoffeeRepository e sua implementa��o CoffeeRepository
builder.Services.AddScoped<ICoffeeRepository, CoffeeRepository>();

// Adiciona a configura��o do Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura o pipeline de solicita��o HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
