using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aplicacao.CalculoJuros;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.CalculoJuros.Tests
{
    [TestClass()]
    public class AplicCalculoJuroTests
    {        
        [TestMethod()]       
        public void CalcularTest()
        {
            AplicCalculoJuro aplicCalculoJuro = new AplicCalculoJuro();
            decimal result = aplicCalculoJuro.Calcular(100, 5);
            
            Assert.AreEqual(105.11m, result);
        }
    }
}