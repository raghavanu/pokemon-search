using System.Threading.Tasks;
using PokemonSearch.Models;

namespace PokemonSearch.Services
{
    public interface IPokemonService
    {
        Task<PokemonResponse> GetPokemonDescription(string pokemonName);
    }
}
