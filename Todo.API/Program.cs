using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Owin.Cors;
using Todo.API.DataProvider;
using Todo.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITodosProvider, TodosDatabaseProvider>();
builder.Services.AddDbContext<TodoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TodoDb")));

builder.Services.AddCors();

var app = builder.Build();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


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

app.MapPost("/todos", async (TodoItemModel todo, ITodosProvider todosProvider) => 
{
    await todosProvider.Add(todo);
});

app.MapPut("/todos/{id}", async (TodoItemModel todo, ITodosProvider todosProvider) => 
{
    await todosProvider.Edit(todo);
});

app.MapGet("/todos/{id}", async (Guid id, ITodosProvider todosProvider) =>
{
    var todoItem = await todosProvider.GetTodo(id);
    return todoItem;
});

app.MapDelete("/todos/{id}", async (Guid id, ITodosProvider todosProvider) => {
    await todosProvider.Remove(id);
});

app.Run();
