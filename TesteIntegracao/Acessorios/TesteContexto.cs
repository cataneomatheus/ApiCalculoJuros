using Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace TesteIntegracao.Acessorios
{
    public class TesteContexto
    {
        public HttpClient Client { get; set; }
        private TestServer _server;

        public TesteContexto()
        {
            SetupClient();
        }

        private void SetupClient()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>()
                                                         .UseConfiguration(new ConfigurationBuilder()
                                                         .AddJsonFile("appsettings.json")
                                                         .Build()));
            Client = _server.CreateClient();
        }
    }
}
