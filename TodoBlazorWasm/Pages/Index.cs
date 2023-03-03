using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using Todo.Shared;

namespace TodoBlazorWasm.Pages
{
    public partial class Index
    {
        public List<ToDoItem> Items { get; set; } = new List<ToDoItem>();

        [Inject]
        public HttpClient HttpClient { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var array = await HttpClient.GetFromJsonAsync<ToDoItem[]>("/todos");
            Items = new List<ToDoItem>(array);
        }

        protected async Task DeleteTodo(ToDoItem item)
        {
            await HttpClient.DeleteAsync($"/todos/{item.Id}");
            var array = await HttpClient.GetFromJsonAsync<ToDoItem[]>("/todos");
            Items = new List<ToDoItem>(array);
            this.StateHasChanged();
        }
    }
}
