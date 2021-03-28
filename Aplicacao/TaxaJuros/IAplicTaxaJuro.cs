using System.Threading.Tasks;

namespace Aplicacao.TaxaJuros
{
    public interface IAplicTaxaJuro
    {
        Task<decimal> GetJuros();
    }
}
