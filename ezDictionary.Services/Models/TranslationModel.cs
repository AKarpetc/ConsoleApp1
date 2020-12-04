using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ezDictionary.Services.Models
{
    public class TranslationModel
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class TranslationsModel
    {
        [JsonProperty("translations")]
        public List<TranslationModel> Translations { get; set; }
    }
}
