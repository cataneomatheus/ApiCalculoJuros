using Aplicacao.CalculoJuros.Dto;
using System.Threading.Tasks;

namespace Aplicacao.CalculoJuros
{
    public interface IAplicCalculoJuro
    {
        Task<decimal> Calcular(CalculoJurosDto dto);
    }
}
