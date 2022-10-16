using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DBManager.WebUi.Models;
using Newtonsoft.Json;

namespace DBManager.WebUi.Services.HttpServices
{
    public class ColumnService : HttpServiceBase
    {
        protected override string _apiControllerName { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public ColumnService()
        {
            _apiControllerName = "Column";
        }

        public async Task<ColumnViewModel> CreateColumn(string tableName, ColumnViewModel column)
        {
            var response = await _client.PostAsync(Url($"CreateColumn/{tableName}"),
                new StringContent(JsonConvert.SerializeObject(column), Encoding.UTF8, "application/json"));
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsAsync<string>().GetAwaiter().GetResult());
            return await response.Content.ReadAsAsync<ColumnViewModel>();
        }

        public async Task<bool> RenameColumn(string tableName, string oldName, string newName)
        {
            var response = await _client.PostAsync(Url($"RenameColumn/{tableName}/{oldName}/{newName}"), null!);
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsAsync<string>().GetAwaiter().GetResult());
            return await response.Content.ReadAsAsync<bool>();
        }
        public async Task<bool> DeleteColumn(string tableName, int columnIndex)
        {
            var response = await _client.DeleteAsync(Url($"DeleteColumn/{tableName}/{columnIndex}"));
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsAsync<string>().GetAwaiter().GetResult());
            return await response.Content.ReadAsAsync<bool>();
        }
    }
}