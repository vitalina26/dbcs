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
    public partial class CreateDatabaseModal : ComponentBase
    {
        [CascadingParameter] public Modal Modal { get; set; }
        [Parameter] public Action<bool> Result { get; set; }
        [Inject] public DatabaseService DatabaseService { get; set; }
        private DatabaseViewModel Database { get; set; } = new();

        private EditContext _editContext;
        private ValidationMessageStore _messageStore;
        private Toast Toast { get; set; }

        protected override void OnInitialized()
        {
            _editContext = new EditContext(Database);
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
                var result = await DatabaseService.CreateDatabase(Database);
                if (result != null)
                {
                    Toast.ShowToast("success", "Success","Database successfully created");
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
        private void HandlePath(InputFileChangeEventArgs e)
        {
            try
            {
                var file = e.File;
                if (!Regex.Match(file.ContentType, @$"^text/").Success)
                {
                    Toast.ShowToast("error", "Error","Incorrect format");
                    return;
                }
                Database.Path = Path.GetFullPath(file.Name);
            }
            catch (Exception ex)
            {
                Toast.ShowToast("error", "Error",ex.Message);
            }
        }
    }
}