using Microsoft.AspNetCore.Components;

namespace DBManager.WebUi.Components
{
    public class ModalBase :ComponentBase
    {
        protected bool _showModal;
        [Parameter]public RenderFragment ChildContent { get; set; }
        [Parameter]public  string Title { get; set; }
        public void CloseModal()
        {
            _showModal = false;
            StateHasChanged();
        }
        public void ShowModal()
        {
            _showModal = true;
            StateHasChanged();
        }
    }
}