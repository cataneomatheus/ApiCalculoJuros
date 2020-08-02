using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;

namespace Aplicacao.CalculoJuros
{
    public class AplicCalculoJuro : IAplicCalculoJuro
    {
        public decimal Calcular(decimal valorIni, int tempo)
        {
            var juros = 0.01; // GetJuros();

            var montante = (decimal)((double)valorIni * Math.Pow(1 + juros, tempo));

            return decimal.Truncate(100 * montante) / 100;
        }

        private double GetJuros()
        {
            var client = new HttpClient();
            var response = client.GetAsync("http://localhost:51675/TaxaJuro").Result;

            if (!response.IsSuccessStatusCode)
                throw new Exception("Erro ao recuperar api de cálculo de juros");

            var ret = response.Content.ReadAsStringAsync().Result;

            var formato = new NumberFormatInfo
            {
                NumberDecimalSeparator = "."
            };

            return Convert.ToDouble(ret, formato);
        }
    }
}