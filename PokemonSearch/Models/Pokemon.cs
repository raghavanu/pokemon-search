using System.Collections.Generic;
using Newtonsoft.Json;

namespace PokemonSearch.Models
{
    public class Pokemon
    {
        public int Id { get; set; }

        public string Name { get; set; }


        [JsonProperty("base_experience")]
        public int BaseExperience { get; set; }

        public int Height { get; set; }

        
        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }

        
        public int Order { get; set; }

        public int Weight { get; set; }

        [JsonProperty("flavor_text_entries")]
        public List<AbilityFlavorText> FlavorTextEntries { get; set; }
    }
}
