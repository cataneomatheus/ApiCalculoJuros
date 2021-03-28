using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Aplicacao.TaxaJuros
{
    public class AplicTaxaJuro : IAplicTaxaJuro
    {
        private readonly IConfiguration _configuration;

        public AplicTaxaJuro(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<decimal> GetJuros()
        {
            var client = new HttpClient();

            var response = await client.GetAsync(GetUrl("TaxaJuro"));

            response.EnsureSuccessStatusCode();

            return await JsonSerializer.DeserializeAsync<decimal>(await response.Content.ReadAsStreamAsync());
        }

        private Uri GetUrl(string nomeController)
        {
            return new Uri(_configuration["UrlApiTaxaJuros"] + nomeController);
        }
    }
}
