using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Shared;

namespace Todo.API.DataProvider
{
    public class InMemoryTodosProvider : ITodosProvider
    {
        private List<TodoItemModel> _items = GetInitialList();

        public Task<TodoItemModel[]> GetTodos()
        {
            return Task.FromResult(_items.ToArray());
        }

        public Task Add(TodoItemModel item)
        {
            item.Id = Guid.NewGuid();
            _items.Add(item);
            return Task.CompletedTask;
        }

        public async Task Edit(TodoItemModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            var itemToEdit = await GetTodo(item.Id.Value);
            itemToEdit.Title = item.Title;
            itemToEdit.IsDone = item.IsDone;
        }

        public async Task Remove(Guid todoId)
        {
            var item = await GetTodo(todoId);
            _items.Remove(item);
        }

        public Task<TodoItemModel> GetTodo(Guid todoId)
        {
            var item = _items.FirstOrDefault(t => t.Id == todoId);
            if (item == null)
            {
                //TODO: use Result instead of throwing exception
                //https://josef.codes/my-take-on-the-result-class-in-c-sharp/
                throw new Exception($"Cannot find todo with id {todoId}");
            }
            return Task.FromResult(item);
        }

        private static List<TodoItemModel> GetInitialList()
        {
            return new List<TodoItemModel>
            {
                new TodoItemModel(Guid.NewGuid(), "Read from a book", false),
                new TodoItemModel(Guid.NewGuid(), "Hit the gym", false),
                new TodoItemModel(Guid.NewGuid(), "Meeting at Cegeka Academy", false)
            };
        }


    }
}
