using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        [MaxLength(250, ErrorMessage = "Please make the title shorter")]
        public string Title { get; set; }

        public bool IsDone { get; set; }
    }
}
