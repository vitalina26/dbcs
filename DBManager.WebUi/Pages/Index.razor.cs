using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DBManager.WebUi.Components;
using DBManager.WebUi.Models;
using DBManager.WebUi.Services;
using Microsoft.AspNetCore.Components;

namespace DBManager.WebUi.Pages
{
    public partial class Index:ComponentBase
    {
        [Inject] public DatabaseService DatabaseService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        private List<DatabaseViewModel> AllDatabases { get; set; } = new();
        private Modal CreateModal { get; set; }
        private Modal OpenModal { get; set; }
        private Modal DeleteModal { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await ReloadDatabases();
        }

        private async Task ReloadDatabases()
        {
            AllDatabases = await DatabaseService.GetAllDatabases() ?? new List<DatabaseViewModel>();
        }

        private void OpenDatabase(string path)
        {
            NavigationManager.NavigateTo($"database/{path}");
        }
        private async Task DeleteDatabase()
        {
            await DatabaseService.DeleteDataBaseByPath(DeleteDatabasePath);
            DeleteDatabasePath = String.Empty;
            await ReloadDatabases();
        }
        private void Delete(string path)
        {
            DeleteDatabasePath = path;
            DeleteModal.ShowModal();
        }

        public string DeleteDatabasePath { get; set; }

        private void Open()
        {
            OpenModal.ShowModal();
        }
        private void Create()
        {
            CreateModal.ShowModal();
        }
    }
}