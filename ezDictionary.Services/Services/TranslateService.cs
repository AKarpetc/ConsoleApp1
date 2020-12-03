using ezDictionary.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ezDictionary.Services.Services
{
    public class TranslateService : ITranslationService
    {
        private string _key;
        private string _url;
        public TranslateService(string key, string url)
        {
            _key = key;
            _url = url;
        }


        public async Task<string> Translate(string ru)
        {
            try
            {

                var client = new HttpClient();

                var content = JsonConvert.SerializeObject(new List<RequestTranslationModel>() { new RequestTranslationModel { Text = ru } });

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,

                    RequestUri = new Uri(_url),

                    Headers =
                    { { "x-rapidapi-key", "fe71bfc3a2mshccf0f6b70f705edp1463a4jsn4536e87f108d" },
                        { "x-rapidapi-host", "microsoft-translator-text.p.rapidapi.com" },
                    },
                    Content = new StringContent(content)
                    {
                        Headers =
                        {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                    }
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return null;
        }
    }
}
