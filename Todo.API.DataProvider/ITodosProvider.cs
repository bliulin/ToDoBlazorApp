using Todo.Shared;

namespace Todo.API.DataProvider
{
    public interface ITodosProvider
    {
        Task Add(ToDoItem item);
        Task<ToDoItem[]> GetTodos();
        Task Remove(Guid todoId);
    }
}