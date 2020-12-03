using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ezDictionary.Services.Models
{
    public class ResponseModel
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("text")]
        public List<string> Text { get; set; }
    }
}
