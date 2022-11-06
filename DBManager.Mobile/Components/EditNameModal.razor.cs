using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;

namespace DBManager.Mobile.Components
{
    public partial class EditNameModal : ComponentBase
    {
        [CascadingParameter] public BlazoredModalInstance BlazoredModal { get; set; }
        [Parameter] public string Name { get; set; }
        
        [Parameter] public string Message { get; set; }
        private string Error => string.IsNullOrEmpty(Name) ? "Name cannot be empty" : "";


        private void Cancel()
        {
            BlazoredModal.Close(ModalResult.Cancel());
        }
        private void Save()
        {
            BlazoredModal.Close(ModalResult.Ok(Name));
        }
    }
}