using Aplicacao.CalculoJuros.Dto;
using System;
using System.Threading.Tasks;
using Aplicacao.TaxaJuros;

namespace Aplicacao.CalculoJuros
{
    public class AplicCalculoJuro : IAplicCalculoJuro
    {
        private readonly IAplicTaxaJuro _aplicTaxaJuro;

        public AplicCalculoJuro(IAplicTaxaJuro aplicTaxaJuro)
        {
            _aplicTaxaJuro = aplicTaxaJuro;
        }       

        public async Task<decimal> Calcular(CalculoJurosDto dto)
        {
            var juros = await _aplicTaxaJuro.GetJuros();

            var montante = (decimal)((double)dto.ValorInicial * Math.Pow(1 + (double)juros, dto.Meses));

            return decimal.Truncate(100 * montante) / 100;

        }               
    }
}