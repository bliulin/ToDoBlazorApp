using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Shared;

namespace Todo.API.DataProvider
{
    public class TodosProvider : ITodosProvider
    {
        private List<ToDoItem> _items = GetInitialList();

        public Task<ToDoItem[]> GetTodos()
        {
            return Task.FromResult(_items.ToArray());
        }

        public Task Add(ToDoItem item)
        {
            _items.Add(item);
            return Task.CompletedTask;
        }

        public Task Remove(Guid todoId)
        {
            var item = _items.FirstOrDefault(t => t.Id == todoId);
            if (item == null)
            {
                throw new Exception("not found");
            }
            _items.Remove(item);
            return Task.CompletedTask;
        }

        private static List<ToDoItem> GetInitialList()
        {
            return new List<ToDoItem>
            {
                new ToDoItem("Read from a book", false),
                new ToDoItem("Hit the gym", false),
                new ToDoItem("Meeting at Cegeka Academy", false)
            };
        }
    }
}
