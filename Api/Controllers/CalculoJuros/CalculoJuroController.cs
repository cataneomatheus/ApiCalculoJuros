using Aplicacao.CalculoJuros;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCalculoJuro.Controllers.CalculoJuros
{
    [ApiController]
    [Route("CalculaJuros")]
    public class CalculaJurosController : ControllerBase
    {
        private readonly IAplicCalculoJuro _aplicCalculoJuro;

        public CalculaJurosController(IAplicCalculoJuro aplicCalculoJuro)
        {
            _aplicCalculoJuro = aplicCalculoJuro;
        }

        [HttpPost("Calcular")]
        public decimal CalculaJuros(decimal valorInicial, int meses)
        {
            try
            {
                return _aplicCalculoJuro.Calcular(valorInicial, meses);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao calcular juros.", ex);
            }
        }
    }
}
