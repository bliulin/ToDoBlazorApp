using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using Todo.Shared;

namespace TodoBlazorWasm.Pages
{
    public partial class ToDoEdit
    {
        [Parameter]
        public string? Id { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public HttpClient HttpClient { get; set; }

        public TodoItemModel TodoItem { get; set; } = new TodoItemModel();

        protected override async Task OnInitializedAsync()
        {
            if (Id != "new")
            {
                TodoItem = await HttpClient.GetFromJsonAsync<TodoItemModel>($"/todos/{Id}");
            }            
        }

        protected async Task HandleValidSubmit()
        {
            if (Id != "new")
            {
                await HttpClient.PutAsJsonAsync($"/todos/{Id}", TodoItem);
            }
            else
            {
                await HttpClient.PostAsJsonAsync($"/todos", TodoItem);
            }

            NavigationManager.NavigateTo("/");
        }

        protected void HandleInvalidSubmit()
        {
            
        }        

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}
