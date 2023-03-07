using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using Todo.Shared;
using TodoBlazorWasm.Components;

namespace TodoBlazorWasm.Pages
{
    public partial class Index
    {
        private TodoItemModel _toDelete;

        public List<TodoItemModel> Items { get; set; } = new List<TodoItemModel>();

        [Inject]
        public HttpClient HttpClient { get; set; }

        protected ConfirmationDialog ConfirmationDeleteDialog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var array = await HttpClient.GetFromJsonAsync<TodoItemModel[]>("/todos");
            Items = new List<TodoItemModel>(array);
        }

        protected async Task DeleteTodo(TodoItemModel item)
        {
            _toDelete = item;
            ConfirmationDeleteDialog.Show();
        }

        private async Task RemoveTodoItem(Guid id)
        {
            await HttpClient.DeleteAsync($"/todos/{id}");
            var array = await HttpClient.GetFromJsonAsync<TodoItemModel[]>("/todos");
            Items = new List<TodoItemModel>(array);
            this.StateHasChanged();
        }

        protected async void OnConfirmationDeleteTodoDialogClosed(bool arg)
        {
            if (arg)
            {
                await RemoveTodoItem(_toDelete.Id.Value);
            }
        }
    }
}
