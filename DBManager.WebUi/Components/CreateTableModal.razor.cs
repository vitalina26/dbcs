using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DBManager.WebUi.Models;
using DBManager.WebUi.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace DBManager.WebUi.Components
{
    public partial class CreateTableModal : ComponentBase
    {
        [CascadingParameter] public Modal Modal { get; set; }
        [Parameter] public Action<bool> Result { get; set; }
        [Inject] public TableService TableService { get; set; }
        private TableViewModel Table { get; set; } = new();

        private EditContext _editContext;
        private ValidationMessageStore _messageStore;
        private Toast Toast { get; set; }

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
            Result?.Invoke(false);
            Modal.CloseModal();
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
                    Toast.ShowToast("success", "Success","Table successfully created");
                    Result?.Invoke(true);
                    Modal.CloseModal();
                }
                else
                    Toast.ShowToast("error", "Error","Something went wrong");
            }
            catch (Exception ex)
            {
                Toast.ShowToast("error", "Error", string.IsNullOrEmpty(ex.Message)
                    ? "Something went wrong"
                    : ex.Message);
            }

        }
    }
}