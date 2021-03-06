﻿using Aplicacao.UrlGitHub;
using Aplicacao.UrlGitHub.View;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiCalculoJuro.Controllers.UrlGitHub
{
    [ApiController]
    [Route("ShowMeTheCode")]
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
