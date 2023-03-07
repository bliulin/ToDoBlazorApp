using Microsoft.AspNetCore.Components;

namespace TodoBlazorWasm.Components
{
    public partial class ConfirmationDialog
    {
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Content { get; set; }

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        protected bool ShowModal { get; set; }

        public void Close()
        {
            ShowModal = false;
        }

        public void Show()
        {
            ShowModal = true;
        }

        public void OnCancelClicked()
        {
            Close();
        }

        public async void OnOkClicked()
        {
            await CloseEventCallback.InvokeAsync(true);
            Close();
        }
    }
}
