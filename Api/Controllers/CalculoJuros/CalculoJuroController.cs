using Aplicacao.CalculoJuros;
using Aplicacao.CalculoJuros.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet("Calcular")]
        public async Task<decimal> CalculaJuros([FromQuery] CalculoJurosDto dto)
        {
            try
            {
                return await _aplicCalculoJuro.Calcular(dto);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao calcular juros.", ex);
            }
        }
    }
}
