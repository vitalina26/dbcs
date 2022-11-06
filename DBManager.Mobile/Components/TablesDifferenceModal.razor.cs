using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazored.Modal;
using Blazored.Modal.Services;
using Blazored.Toast.Services;
using DBManager.Mobile.Models;
using DBManager.Mobile.Services.HttpServices;
using Microsoft.AspNetCore.Components;

namespace DBManager.Mobile.Components
{
    public partial class TablesDifferenceModal:ComponentBase
    {
        [CascadingParameter] public BlazoredModalInstance BlazoredModal { get; set; }
        [Parameter]public List<TableViewModel> Tables { get; set; } = new();
        [Inject] public IToastService ToastService { get; set; }
        [Inject] public TableService TableService { get; set; }
        public string FirstTableName { get; set; }
        public string SecondTableName { get; set; }
        public TableViewModel Result { get; set; }
        private void Cancel()
        {
            BlazoredModal.Close(ModalResult.Cancel());
        }

        private async Task Difference()
        {
            try
            {
                if(string.IsNullOrEmpty(FirstTableName) || string.IsNullOrEmpty(SecondTableName))
                    return;
                Result = await TableService.Difference(FirstTableName, SecondTableName);
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