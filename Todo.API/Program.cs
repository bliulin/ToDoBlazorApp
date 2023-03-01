using Microsoft.Extensions.Caching.Memory;
using Todo.API.DataProvider;
using Todo.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ITodosProvider, TodosProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/todos", async (ITodosProvider todosProvider) => 
{
    var list = await todosProvider.GetTodos();
    return list;
});

app.MapPost("/todos", async (ToDoItem todo, ITodosProvider todosProvider) => 
{
    await todosProvider.Add(todo);
});

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}