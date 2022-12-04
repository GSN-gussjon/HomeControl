using HADotNet.Core;
using HomeControl.DBModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomeControl.Services
{
    public class SqlService
    {
        #region Private members
        private HttpClient client;

        private const string endpoint = "https://gsnha.duckdns.org:1880/endpoint";
        #endregion

        #region Ctor
        public SqlService()
        {
            client = ClientFactory.Client;
        }
        #endregion

        #region Public methods
        public async Task<IEnumerable<FoodMenu>> GetFoodMenu()
        {
            try
            {
                var request = BuildRequest(HttpMethod.Get, "foodMenu");
                var response = await client.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Error");
                    return null;
                }

                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<FoodMenu>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            try
            {
                var request = BuildRequest(HttpMethod.Get, "users");
                var response = await client.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Error");
                    return null;
                }

                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<User>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public async Task<User> GetUserByToken(string token)
        {
            try
            {
                var request = BuildRequest(HttpMethod.Get, $"userByToken?token={token}");
                var response = await client.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Error");
                    return null;
                }

                var json = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<User>>(json);

                return users?.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public async Task<User> GetUserByLoginPassword(string login, string password)
        {
            try
            {
                var request = BuildRequest(HttpMethod.Get, $"userByLoginPassword?login={login}&password={password}");
                var response = await client.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Error");
                    return null;
                }

                var json = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<User>>(json);

                return users?.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
        #endregion

        #region Private methods
        private HttpRequestMessage BuildRequest(HttpMethod httpMethod, string topic)
        {
            var request = new HttpRequestMessage(httpMethod, $"{endpoint}/{topic}");
            request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "admin123", "C7z06p97"))));

            return request;
        }

        #endregion
    }
}
