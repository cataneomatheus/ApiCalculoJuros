using Aplicacao.CalculoJuros.Dto;
using Aplicacao.TaxaJuros;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Aplicacao.CalculoJuros.Tests
{
    [TestClass()]
    public class AplicCalculoJuroTests
    {        
        [TestMethod()]       
        public async System.Threading.Tasks.Task CalcularTestAsync()
        {
            var mockaplicCalculoJuro = new Mock<IAplicTaxaJuro>();
            mockaplicCalculoJuro.Setup(p => p.GetJuros()).ReturnsAsync(0.01m);

            var calculaJurosAplic = new AplicCalculoJuro(mockaplicCalculoJuro.Object);
            var dto = new CalculoJurosDto
            {
                ValorInicial = 100,
                Meses = 5
            };

            var result = await calculaJurosAplic.Calcular(dto);
            Assert.AreEqual(105.10m, result);
        }
    }
}