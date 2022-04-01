using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.Models
{
    
    public class Step
    {
        //public Step(string text, string image)
        //{
        //    Image = image;
        //    if (string.IsNullOrEmpty(image))
        //    {
        //        throw new InvalidOperationException("Invalid path to image source");
        //    }
        //    Text = text;
        //    if (string.IsNullOrEmpty(text))
        //    {
        //        throw new InvalidOperationException("Invalid text for step");
        //    }
        //}

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
    }
}
