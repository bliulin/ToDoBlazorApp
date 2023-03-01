using Todo.Shared;

namespace TodoBlazorWasm.Pages
{
    public partial class Index
    {
        public List<ToDoItem> Items { get; set; } = new List<ToDoItem>();

        protected override Task OnInitializedAsync()
        {
            Items.AddRange(new[] { new ToDoItem("first task"), new ToDoItem("second task") });

            return Task.CompletedTask;
        }
    }
}
