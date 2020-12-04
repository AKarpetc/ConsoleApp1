using ezDictionary.Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ezDictionary.Services.Services
{
    public class ToVoiceService
    {

        private VoiceParametersBuilder parameters;

        public void SetParameters(ParametersBuilder parameters)
        {
            if (!(parameters is VoiceParametersBuilder))
            {
                throw new ArgumentException("Ошибка входного параметра трубектся параметр типа VoiceParametersBuilder");
            }

            this.parameters = (VoiceParametersBuilder)parameters;
        }

        public async Task<byte[]> GetFile(string text)
        {
            parameters.SetText(text);
            string url = parameters.Build();

            var uri = new Uri(url);
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(uri);

            var puth = string.Format("{0}.mp3", text);

            using (var fs = new MemoryStream())
            {
                await response.Content.CopyToAsync(fs);

                return fs.ToArray();
            }

        }
    }
}
