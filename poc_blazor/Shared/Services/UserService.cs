using poc_blazor.Infrastructure;
using System.Net.Http.Json;
using poc_blazor.Shared.DTO;
using poc_blazor.Shared.IServices;
using Blazored.LocalStorage;

namespace poc_blazor.Shared.Services
{
    public class UserService : IUserService
    {
        private readonly ILocalStorageService _localStorage;

        private readonly PublicClient publicClient;
        private readonly HttpClient authClient;
        private const string endpoint = "api/account";

        public UserService( PublicClient publicClient, HttpClient authClient, ILocalStorageService localStorage)
        {
            this._localStorage = localStorage;
            this.publicClient = publicClient;
            this.authClient = authClient;
        }
        /*.btn-primary {
    color: #fff;
    background-color: #1b6ec2;
    border-color: #1861ac;
}*/
        public async Task<bool> LogIn(UserDTO.Login model)
        {
            var response = await publicClient.Client.PostAsJsonAsync(endpoint, model);
            if (response.IsSuccessStatusCode)
            {
                string token = await response.Content.ReadAsStringAsync();
                authClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                await _localStorage.SetItemAsStringAsync("token", token);
                return true;
            }
            return false;
        }

        public async Task<bool> Register(UserDTO.Register model)
        {
            var response = await publicClient.Client.PostAsJsonAsync($"{endpoint}/register", model);
            if (response.IsSuccessStatusCode)
            {
                string token = await response.Content.ReadAsStringAsync();
                authClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                await _localStorage.SetItemAsStringAsync("token", token);
                return true;
            } 
            return false;
        }
    }
}
