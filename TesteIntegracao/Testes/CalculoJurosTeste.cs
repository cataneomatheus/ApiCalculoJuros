using Aplicacao.CalculoJuros.Dto;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using TesteIntegracao.Acessorios;
using Xunit;

namespace TesteIntegracao.Testes
{
    public class CalculoJurosTeste
    {
        private readonly TesteContexto _testeContexto;

        public CalculoJurosTeste()
        {
            _testeContexto = new TesteContexto();
        }

        [Fact]
        public async Task RespostaOk()
        {
            var response = await _testeContexto.Client.GetAsync("calculajuros/calcular");

            response.EnsureSuccessStatusCode();

            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task DeveRetornar105_10()
        {
            var dto = new CalculoJurosDto
            {
                ValorInicial = 100,
                Meses = 5
            };

            var url = QueryHelpers.AddQueryString("CalculaJuros/Calcular", new Dictionary<string, string>
            {
                { nameof(dto.ValorInicial), dto.ValorInicial.ToString() },
                { nameof(dto.Meses), dto.Meses.ToString() }
            });

            var response = await _testeContexto.Client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var valorAtual = await JsonSerializer.DeserializeAsync<decimal>(await response.Content.ReadAsStreamAsync());

            Assert.Equal(105.10m, valorAtual);
        }
    }
}
