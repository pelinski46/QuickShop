using System.Net.Http.Json;

namespace QuickShop.Client.Services
{
    public class RoleCheckService
    {
        private readonly HttpClient _httpClient;
        public RoleCheckService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<string>> GetUserRolesAsync (string emailId)
        {
            try
            {
                
                return await _httpClient.GetFromJsonAsync<List<string>>($"api/role/GetUserRole/{emailId}");
            }
            catch
            {
                return new List<string>();
            }
        }

        public async Task<bool> isAdmin(string emailId)
        {
            var roles = await GetUserRolesAsync(emailId);
            return roles.Contains("Admin");
        }
    }
}
