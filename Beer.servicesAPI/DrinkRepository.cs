using Beer.servicesAPI.Basis;
using Bier.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Beer.servicesAPI
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly Uri baseAdress = new Uri("http://localhost:40950/api/");
        private readonly string route = "Drink";

        private HttpClient CreateHttpClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = baseAdress;
            return client;
        }

        private HttpResponseMessage GetResponseMessage(Func<string, Task<HttpResponseMessage>> func)
        {
            Task<HttpResponseMessage> ResponseTask = func(route);
            ResponseTask.Wait();

            return ResponseTask.Result;

        }
        private HttpResponseMessage GetResponseMessage(Func<string,HttpContent, Task<HttpResponseMessage>> func, HttpContent content)
        {
            Task<HttpResponseMessage> ResponseTask = func(route, content);
            ResponseTask.Wait();

            return ResponseTask.Result;

        }

        private string GetJsonContent(HttpResponseMessage response)
        {
            Task<string> content = response.Content.ReadAsStringAsync();
            content.Wait();
            return content.Result;

        }




        public IEnumerable<Drink> GetAll()
        {
            using (HttpClient client = CreateHttpClient())
            {
                HttpResponseMessage response = GetResponseMessage(client.GetAsync);
                if (!response.IsSuccessStatusCode) throw new HttpRequestException();
                
                string jsonString = GetJsonContent(response);
                return JsonConvert.DeserializeObject<IEnumerable<Drink>>(jsonString);

            }
        }

        public Drink GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public Drink Insert(Drink entity)
        {
            JsonContent entityJson = JsonContent.Create(entity);

            using(HttpClient client = CreateHttpClient())
            {
                HttpResponseMessage response = GetResponseMessage(client.PostAsync, entityJson);
                if (!response.IsSuccessStatusCode) throw new HttpRequestException();
                
                string jsonString = GetJsonContent(response);
                return JsonConvert.DeserializeObject<Drink>(jsonString);

            }
        }

        public Drink Update(int id, Drink drink)
        {
            throw new NotImplementedException();
        }

        public Drink Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
