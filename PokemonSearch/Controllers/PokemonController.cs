using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PokemonSearch.Models;
using PokemonSearch.Services;

namespace PokemonSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _service;

        public PokemonController(IPokemonService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{name}")]
        [ProducesResponseType(typeof(PokemonResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPokemonWithShakespeareDescriptionAsync(string name)
        {
            PokemonResponse output = await _service.GetPokemonDescription(name);

            return Ok(output);
        }
    }
}
