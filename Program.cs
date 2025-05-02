using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
             /*var cuenta = new CuentaBancaria("0002030", 5000,  new []{"Juan", "Sanchez"}, 0.05m,3000);
            {
            tasaInteres=0.05m;
            LimiteDescubierto=0.09;

            }*/
            /*CuentaCorriente cc1 = new CuentaCorriente ("123", 1500, new string[] { "Juan" },0.05m);

            CajaDeAhorro ca = new CajaDeAhorro ("123", 1500, new string[] { "Juan" },0.05m);
            cc.estado = Estado.Suspendida;*/

         
            
                // Instanciar cuentas
                CuentaBancaria cuenta1 = new CajaDeAhorro("1", 1500, new string[] {"Hernan"},0.05m);
                CuentaBancaria cuenta2 = new CajaDeAhorro("2", 0, new string[] { "Carlos" }, 0.05m);
                CuentaBancaria cuenta3 = new CuentaCorriente("3", 300, new string[] {"Lucas"},0.05m);
                CuentaBancaria cuenta4 = new CuentaCorriente("4", 5000, new string[] { "Francisco" }, 0.05m);

            // Operaciones
            cuenta1.Depositar(1000);
                cuenta1.Retirar(200); //aprox 2000

                cuenta2.Depositar(500);
                cuenta2.Retirar(600); // no debería poder

                cuenta3.Depositar(300);
                cuenta3.Retirar(700); // debería usar saldo negativo

                cuenta4.Retirar(300); //  sin dramas

                // Arreglo de cuentas
                List<CuentaBancaria> cuentas = new List<CuentaBancaria> { cuenta1, cuenta2, cuenta3, cuenta4 };

                // Mostrar resumen con clase anónima
                foreach (var cuenta in cuentas)
                {
                    var resumen = new
                    {
                        Numero = cuenta.Numero,
                        Tipo = cuenta.GetType().Name,
                        Saldo = cuenta.Saldo
                    };

                    Console.WriteLine($"Cuenta N°: {resumen.Numero}, Tipo: {resumen.Tipo}, Saldo: {resumen.Saldo:C}");
                }
            }
        }


    }


