using Microsoft.AspNetCore.Components;

namespace TodoBlazorWasm.Components
{
    public partial class ConfirmationDialog
    {
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Content { get; set; }

        protected bool ShowDialog { get; set; }

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        public void Show()
        {
            ShowDialog = true;
            StateHasChanged();
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        public async void OnOkClicked()
        {
            ShowDialog = false;            
            await this.CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }

        public void OnCancelClicked()
        {
            this.Close();
        }
    }
}
