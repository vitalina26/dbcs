using System;
using System.Net.Http;
using System.Threading.Tasks;
using DBManager.WebUi.Models;

namespace DBManager.WebUi.Services.HttpServices
{
    public class TableService : HttpServiceBase
    {
        protected override string _apiControllerName { get; set; }
        /// <summary>
        /// Constructor.
        /// </summary>
        public TableService()
        {
            _apiControllerName = "Table";
        }

        public async Task<TableViewModel> CreateTable(string tableName)
        {
            var response = await _client.PostAsync(Url($"CreateTable/{tableName}"), null!);
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsAsync<string>().GetAwaiter().GetResult());
            return await response.Content.ReadAsAsync<TableViewModel>();
        }
        
        public async Task<bool> DeleteTable(string tableName)
        {
            var response = await _client.DeleteAsync(Url($"DeleteTable/{tableName}"));
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsAsync<string>().GetAwaiter().GetResult());
            return await response.Content.ReadAsAsync<bool>();
        }
        
        public async Task<bool> RenameTable(string oldTableName, string newTableName)
        {
            var response = await _client.PostAsync(Url($"RenameTable/{oldTableName}/{newTableName}"), null!);
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsAsync<string>().GetAwaiter().GetResult());
            return await response.Content.ReadAsAsync<bool>();
        }
        
        public async Task<TableViewModel> Difference(string firstTableName, string secondTableName)
        {
            var response = await _client.PostAsync(Url($"Difference/{firstTableName}/{secondTableName}"), null!);
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsAsync<string>().GetAwaiter().GetResult());
            return await response.Content.ReadAsAsync<TableViewModel>();
        }
        
        public async Task<TableViewModel> GetTableByName(string tableName)
        {
            var response = await _client.GetAsync(Url($"GetTableByName/{tableName}"));
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsAsync<string>().GetAwaiter().GetResult());
            return await response.Content.ReadAsAsync<TableViewModel>();
        }
    }
}