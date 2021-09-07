using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PokemonSearch.Models;

namespace PokemonSearch.Extensions
{
    public class HttpClientDelegatingHandler
         : DelegatingHandler
    {

        public HttpClientDelegatingHandler()
        {

        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpClientHandler handler = new HttpClientHandler();
            using var client = new HttpClient(handler, false);

            using HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Pokemon output = JsonConvert.DeserializeObject<Pokemon>(content);

                string description = String.Join(",", output.FlavorTextEntries.Where(x => x.Language.Name == "en").Select(x => x.FlavorText).ToArray());

                var url = request.RequestUri.AbsolutePath;
                var pokemonName = url.Substring(url.LastIndexOf("/") + 1);

                var translation = await GetShakespeareDescription(description);

                var finalOutput = new PokemonResponse() { Name = pokemonName, Description = translation.Contents.Translated };

                var stringContent = new StringContent(JsonConvert.SerializeObject(finalOutput), Encoding.UTF8, "application/json");
                return new HttpResponseMessage(HttpStatusCode.OK) { Content = stringContent };
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "Something went wrong, Please try again!" };
            }
        }


        async Task<Translation> GetShakespeareDescription(string description)
        {
            HttpClient client = new HttpClient();
            var input = new
            {
                text = description
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"https://api.funtranslations.com/translate/shakespeare", stringContent);

            var content = await response.Content.ReadAsStringAsync();
            Translation output = JsonConvert.DeserializeObject<Translation>(content);

            return output;
        }

    }
}
