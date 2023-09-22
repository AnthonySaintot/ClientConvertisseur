using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ClientConvertisseur.Models;

namespace WSConvertisseur.Services
{
    public class WSService : IService
    {
        private HttpClient client;
        public WSService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44327/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<Devise>> GetDevisesAsync(string nomControleur)
        {
            try
            {
                return await client.GetFromJsonAsync<List<Devise>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }

        Task<List<Devise>> IService.GetDevisesAsync(string nomControleur)
        {
            throw new System.NotImplementedException();
        }
    }
}
