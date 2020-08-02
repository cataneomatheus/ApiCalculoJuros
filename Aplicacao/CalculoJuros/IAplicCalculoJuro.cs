using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.CalculoJuros
{
    public interface IAplicCalculoJuro
    {
        decimal Calcular(decimal valorIni, int tempo);
    }
}
