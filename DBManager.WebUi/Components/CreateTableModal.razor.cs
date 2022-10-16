using System;
using System.Threading.Tasks;
using Blazored.Modal;
using Blazored.Modal.Services;
using Blazored.Toast.Services;
using DBManager.WebUi.Models;
using DBManager.WebUi.Services.HttpServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace DBManager.WebUi.Components
{
    public partial class CreateTableModal : ComponentBase
    {
        [CascadingParameter] public BlazoredModalInstance BlazoredModal { get; set; }
        [Inject] public TableService TableService { get; set; }
        [Inject] public IToastService ToastService { get; set; }
        private TableViewModel Table { get; set; } = new();

        private EditContext _editContext;
        private ValidationMessageStore _messageStore;

        protected override void OnInitialized()
        {
            _editContext = new EditContext(Table);
            _messageStore = new ValidationMessageStore(_editContext);
            _editContext.OnValidationRequested += (s, e) => _messageStore.Clear();
            _editContext.OnFieldChanged += (s, e) =>
            {
                _messageStore.Clear(e.FieldIdentifier);
                _editContext.GetValidationMessages(e.FieldIdentifier);
            };
        }

        private void Cancel()
        {
            BlazoredModal.Close(ModalResult.Cancel());
        }

        private async Task Create()
        {
            try
            {
                var isValid = _editContext.Validate();
                if (!isValid)
                    return;
                var result = await TableService.CreateTable(Table.Name);
                if (result != null)
                {
                    ToastService.ShowSuccess("Table successfully created");
                    BlazoredModal.Close(ModalResult.Ok(true));
                }
                else
                    ToastService.ShowError("Something went wrong");
            }
            catch (Exception ex)
            {
                ToastService.ShowError(string.IsNullOrEmpty(ex.Message)
                    ? "Something went wrong"
                    : ex.Message);
            }
        }
    }
}