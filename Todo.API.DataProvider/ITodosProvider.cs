using Todo.Shared;

namespace Todo.API.DataProvider
{
    public interface ITodosProvider
    {
        Task Add(ToDoItem item);
        Task Edit(ToDoItem item);
        Task<ToDoItem[]> GetTodos();
        Task<ToDoItem> GetTodo(Guid id);
        Task Remove(Guid todoId);
    }
}