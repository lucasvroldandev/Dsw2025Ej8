using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    internal class Exceptions
    {
        // Excepciones.cs
        public class MontoNoValidoException : Exception
        {
            public MontoNoValidoException()
                : base("El monto ingresado no es válido para la operación solicitada.") { }
        }

        public class CuentaNoActivaException : Exception
        {
            public CuentaNoActivaException(string estado)
                : base($"No se puede operar con la cuenta {estado}.") { }
        }

        public class SaldoInsuficienteException : Exception
        {
            public SaldoInsuficienteException()
                : base("La cuenta no cuenta con saldo para la operación solicitada. Fue suspendida.") { }
        }

    }
}
