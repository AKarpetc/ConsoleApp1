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
        private ParametersBuilder parameters;

        public void SetParameters(ParametersBuilder parameters)
        {
            this.parameters = parameters;
        }

        public async Task<MemoryStream> GetFile(string en)
        {
            try
            {
                var uri = new Uri($"https://translate.google.com.vn/translate_tts?ie=UTF-8&q={en}&tl=en&client=tw-ob");
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(uri);

                var puth = string.Format("{0}.mp3", en);

                using (var fs = new MemoryStream())
                {
                    await response.Content.CopyToAsync(fs);
                    return fs;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
