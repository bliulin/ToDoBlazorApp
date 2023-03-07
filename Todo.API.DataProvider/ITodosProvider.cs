using Todo.Shared;

namespace Todo.API.DataProvider
{
    public interface ITodosProvider
    {
        Task Add(TodoItemModel item);
        Task Edit(TodoItemModel item);
        Task<TodoItemModel[]> GetTodos();
        Task<TodoItemModel> GetTodo(Guid id);
        Task Remove(Guid todoId);
    }
}