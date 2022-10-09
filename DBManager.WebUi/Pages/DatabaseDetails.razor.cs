using System;
using System.Threading.Tasks;
using DBManager.WebUi.Components;
using DBManager.WebUi.Models;
using DBManager.WebUi.Services;
using Microsoft.AspNetCore.Components;

namespace DBManager.WebUi.Pages
{
    public partial class DatabaseDetails :ComponentBase
    {
        [Parameter] public string DatabasePath { get; set; }
        [Inject] public DatabaseService DatabaseService { get; set; }
        [Inject] public TableService TableService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        public DatabaseViewModel Database { get; set; } = new();
        private Modal CreateModal { get; set; }
        private Modal OpenModal { get; set; }
        private Modal DeleteModal { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await ReloadDatabase();
        }

        private async Task ReloadDatabase()
        {
            Database = await DatabaseService.OpenDatabase(DatabasePath) ?? new DatabaseViewModel();
        }
        private void Create()
        {
            CreateModal.ShowModal();
        }
        private void Delete(string name)
        {
            DeleteTableName = name;
            DeleteModal.ShowModal();
        }
        private async Task DeleteTable()
        {
            await TableService.DeleteTable(DeleteTableName);
            DeleteTableName = String.Empty;
            await ReloadDatabase();
        }

        public string DeleteTableName { get; set; }

        private void Open(string tableName)
        {
            NavigationManager.NavigateTo($"tableDetails/{tableName}");
        }
    }
}