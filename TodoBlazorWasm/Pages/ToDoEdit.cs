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

        protected override async Task OnInitializedAsync()
        {
            TodoItem = await HttpClient.GetFromJsonAsync<ToDoItem>($"/todos/{Id}");
        }

        protected async Task HandleValidSubmit()
        {
            if (TodoItem.Id.HasValue)
            {
                await HttpClient.PutAsJsonAsync($"/todos/{TodoItem.Id}", TodoItem);
            }
            else
            {
                await HttpClient.PostAsJsonAsync($"/todos", TodoItem);
            }
        }

        public ToDoItem TodoItem { get; set; } = new ToDoItem();

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}
