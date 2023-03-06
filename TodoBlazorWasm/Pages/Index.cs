using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using Todo.Shared;
using TodoBlazorWasm.Components;

namespace TodoBlazorWasm.Pages
{
    public partial class Index
    {
        private ToDoItem _toDelete;
        private string _confirmationDeleteText = "";

        public List<ToDoItem> Items { get; set; } = new List<ToDoItem>();

        [Inject]
        public HttpClient HttpClient { get; set; }

        protected ConfirmationDialog ConfirmationDeleteDialog { get; set; }

        protected string ConfirmationText => _confirmationDeleteText;

        protected override async Task OnInitializedAsync()
        {
            var array = await HttpClient.GetFromJsonAsync<ToDoItem[]>("/todos");
            Items = new List<ToDoItem>(array);
        }

        protected async Task DeleteTodo(ToDoItem item)
        {
            _toDelete = item;
            _confirmationDeleteText = $"Are you sure you want to delete '{item.Title}'?";
            ConfirmationDeleteDialog.Show();
        }

        protected async void OnConfirmationDeleteTodoDialogClosed(bool arg)
        {
            await RemoveTodo(_toDelete.Id.Value);
            StateHasChanged();
        }

        private async Task RemoveTodo(Guid id)
        {
            await HttpClient.DeleteAsync($"/todos/{id}");
            var array = await HttpClient.GetFromJsonAsync<ToDoItem[]>("/todos");
            Items = new List<ToDoItem>(array);
            this.StateHasChanged();
        }
    }
}
