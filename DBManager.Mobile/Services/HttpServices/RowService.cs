using System;
using System.Net.Http;
using System.Threading.Tasks;
using DBManager.Mobile.Models;

namespace DBManager.Mobile.Services.HttpServices
{
    public class RowService : HttpServiceBase
    {
        protected override string _apiControllerName { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public RowService()
        {
            _apiControllerName = "Row";
        }

        public async Task<RowViewModel> CreateRow(string tableName)
        {
            var response = await _client.PostAsync(Url($"CreateRow/{tableName}"), null!);
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsAsync<string>().GetAwaiter().GetResult());
            return await response.Content.ReadAsAsync<RowViewModel>();
        }

        public async Task<bool> DeleteRow(string tableName, int rowIndex)
        {
            var response = await _client.DeleteAsync(Url($"DeleteRow/{tableName}/{rowIndex}"));
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsAsync<string>().GetAwaiter().GetResult());
            return await response.Content.ReadAsAsync<bool>();
        }

        public async Task<bool> EditCell(string tableName, int columnIndex, int rowIndex, string newValue)
        {
            var response = await _client.PutAsync(Url($"EditCell/{tableName}/{columnIndex}/{rowIndex}/{newValue}"), null!);
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsAsync<string>().GetAwaiter().GetResult());
            return await response.Content.ReadAsAsync<bool>();
        }
    }
}