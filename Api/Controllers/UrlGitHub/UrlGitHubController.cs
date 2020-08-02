using Aplicacao.UrlGitHub;
using Aplicacao.UrlGitHub.View;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCalculoJuro.Controllers.UrlGitHub
{
    [ApiController]
    [Route("UrlGitHub")]
    public class UrlGitHubController : ControllerBase
    {
        private readonly IAplicUrlGitHub _urlGitHub;
        public UrlGitHubController(IAplicUrlGitHub urlGitHub)
        {
            _urlGitHub = urlGitHub;
        }
        [HttpGet]
        public List<UrlGitHubView> ShowMeTheCode()
        {
            return _urlGitHub.GetUrlGitHub();
        }
    }
}
