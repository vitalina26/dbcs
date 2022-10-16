using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;

namespace DBManager.WebUi.Components
{
    public partial class ConfirmationModal : ComponentBase
    {
        [CascadingParameter] public BlazoredModalInstance BlazoredModal { get; set; }
        
        
        [Parameter] public string Message { get; set; }
        private void CloseConfirmationModal(bool isPositive)
        {
            BlazoredModal.Close(ModalResult.Ok(isPositive));
        }

    }
}