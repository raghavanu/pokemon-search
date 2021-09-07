using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PokemonSearch.Models;

namespace PokemonSearch.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _apiClient;

        public PokemonService(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<PokemonResponse> GetPokemonDescription(string pokemonName)
        {
            string address = $"https://pokeapi.co/api/v2/pokemon-species/{pokemonName}";
            var response = await _apiClient.GetAsync($"{address}");
            var jsonResponse = await response.Content.ReadAsStringAsync();

            PokemonResponse output = JsonConvert.DeserializeObject<PokemonResponse>(jsonResponse);

            return output;
        }
    }
}
