using Aplicacao.UrlGitHub.View;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Aplicacao.UrlGitHub
{
    public class AplicUrlGitHub : IAplicUrlGitHub
    {
        private readonly IConfiguration _configuration;

        public AplicUrlGitHub(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<UrlGitHubView> GetUrlGitHub()
        {
            return new List<UrlGitHubView>
            {
                new UrlGitHubView()
                {
                    NomeApi = "ApiCalculoJuros",
                    UrlApi = _configuration["UrlGitApiCalculoJuros"]
                },
                new UrlGitHubView()
                {
                    NomeApi = "ApiTaxaJuros",
                    UrlApi = _configuration["UrlGitApiTaxaJuros"]
                }
            };            
        }
    }
}
