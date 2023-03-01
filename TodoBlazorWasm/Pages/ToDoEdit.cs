using Microsoft.AspNetCore.Components;
using Todo.Shared;

namespace TodoBlazorWasm.Pages
{
    public partial class ToDoEdit
    {
        [Parameter]
        public string? Id { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        public ToDoItem Item { get; set; } = new ToDoItem();

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}
