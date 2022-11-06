using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DBManager.Mobile.Models;
using Newtonsoft.Json;

namespace DBManager.Mobile.Services.HttpServices
{
    public class DatabaseService : HttpServiceBase
    {
        protected override string _apiControllerName { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public DatabaseService()
        {
            _apiControllerName = "Database";
        }

        public async Task<List<DatabaseViewModel>> GetAllDatabases()
        {
            var response = await _client.GetAsync(Url($"GetAllDatabases"));
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsAsync<string>().GetAwaiter().GetResult());
            return await response.Content.ReadAsAsync<List<DatabaseViewModel>>();
        }

        public async Task<DatabaseViewModel> OpenDatabase(string path)
        {
            var response = await _client.PostAsync(Url($"OpenDatabase/{Uri.EscapeUriString(path)}"), null!);
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsAsync<string>().GetAwaiter().GetResult());
            return await response.Content.ReadAsAsync<DatabaseViewModel>();
        }

        
        public async Task<bool> RenameDatabase(string newName)
        {
            var response = await _client.PostAsync(Url($"RenameDatabase/{newName}"), null!);
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsAsync<string>().GetAwaiter().GetResult());
            return await response.Content.ReadAsAsync<bool>();
        }
        public async Task<DatabaseViewModel> CreateDatabase(DatabaseViewModel database)
        {
            var response = await _client.PostAsync(Url($"CreateDatabase"),
                new StringContent(JsonConvert.SerializeObject(database), Encoding.UTF8, "application/json"));
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsAsync<string>().GetAwaiter().GetResult());
            return await response.Content.ReadAsAsync<DatabaseViewModel>();
        }

        public async Task<bool> SaveDatabase()
        {
            var response = await _client.PostAsync(Url($"SaveDatabase"), null!);
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsAsync<string>().GetAwaiter().GetResult());
            return await response.Content.ReadAsAsync<bool>();
        }

        public async Task<bool> DeleteDataBase()
        {
            var response = await _client.DeleteAsync(Url($"DeleteDataBase"));
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsAsync<string>().GetAwaiter().GetResult());
            return await response.Content.ReadAsAsync<bool>();
        }

        public async Task<bool> DeleteDataBaseByPath(string databasePath)
        {
            var response = await _client.DeleteAsync(Url($"DeleteDataBaseByPath/{databasePath}"));
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsAsync<string>().GetAwaiter().GetResult());
            return await response.Content.ReadAsAsync<bool>();
        }
    }
}