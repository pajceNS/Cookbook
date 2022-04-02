using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.Models
{
    
    public class Step
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
    }
}
