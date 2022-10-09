using System.Threading.Tasks;
using DBManager.WebUi.Models;
using DBManager.WebUi.Services;
using Microsoft.AspNetCore.Components;

namespace DBManager.WebUi.Pages
{
    public partial class TableDetails :ComponentBase
    {
        [Parameter] public string TableName { get; set; }
        [Inject] public TableService TableService { get; set; }
        [Inject] public RowService RowService { get; set; }
        public TableViewModel Table { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Table = await TableService.GetTableByName(TableName);
        }
    }
}