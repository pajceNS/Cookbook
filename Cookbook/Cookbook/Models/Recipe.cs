using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.Models
{
    public class Recipe
    {
        public Recipe(Guid id, string name, string backgroundImage, string thumbnailImage, string shortDescription, string longDescription, string type)
        {
            
            Id = id;
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidOperationException("Title can't be empty");
            }

            if (string.IsNullOrEmpty(shortDescription))
            {
                throw new InvalidOperationException(nameof(shortDescription));
            }
            Name = name;
            BackgroundImage = backgroundImage;
            ThumbnailImage = thumbnailImage;
            ShortDescription = shortDescription;
            LongDescription = longDescription;
            Type = type;
        }

            [JsonProperty("id")]
            public Guid Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("steps")]
            public List<Step> Steps { get; set; }

            [JsonProperty("backgroundImage")]
            public string BackgroundImage { get; set; }

            [JsonProperty("thumbnailImage")]
            public string ThumbnailImage { get; set; }

            [JsonProperty("ingredients")]
            public List<Ingredient> Ingredients { get; set; }

            [JsonProperty("shortDescription")]
            public string ShortDescription { get; set; }

            [JsonProperty("longDescription")]

            public string LongDescription { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }


    }
}
