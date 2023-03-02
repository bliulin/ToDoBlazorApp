using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Shared
{
    public class ToDoItem
    {
        public ToDoItem()
        {

        }

        public ToDoItem(Guid id, string title = "", bool isDone = false)
        {
            Id = id;
            Title = title;
            IsDone = isDone;
        }

        public Guid? Id { get; set; }

        public string Title { get; set; }

        public bool IsDone { get; set; }
    }
}
