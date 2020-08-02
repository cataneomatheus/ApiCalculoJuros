using Aplicacao.UrlGitHub.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.UrlGitHub
{
    public class AplicUrlGitHub : IAplicUrlGitHub
    {
        public List<UrlGitHubView> GetUrlGitHub()
        {
            var ret = new List<UrlGitHubView>();
            
            ret.Add(new UrlGitHubView() { 
                NomeApi = "ApiCalculoJuros",
                UrlApi = "https://github.com/cataneomatheus/ApiCalculoJuros.git"
            });

            ret.Add(new UrlGitHubView()
            {
                NomeApi = "ApiTaxaJuros",
                UrlApi = "https://github.com/cataneomatheus/ApiTaxaJuros.git"
            });

            return ret;
        }
    }
}
