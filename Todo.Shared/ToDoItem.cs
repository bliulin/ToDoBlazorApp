using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Shared
{
    public record ToDoItem(string Title = "", bool IsDone = false)
    {
        public Guid? Id { get; private set; } = Guid.NewGuid();

        //public void SetGuid(Guid id)
        //{
        //    Id = id;
        //}
    }
}
