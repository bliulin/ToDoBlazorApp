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

        public List<Marker> MapMarkers { get; set; } = new List<Marker>();

        protected override async Task OnInitializedAsync()
        {
            if (Id != "new")
            {
                TodoItem = await HttpClient.GetFromJsonAsync<ToDoItem>($"/todos/{Id}");
            }

            MapMarkers = new List<Marker>
            {
                //47.158332750629924, 27.587009829664954
                new Marker{Description = $"test",  ShowPopup = false, X = 27.587009829664954, Y = 47.158332750629924}
            };
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

        public ToDoItem TodoItem { get; set; } = new ToDoItem();

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}
