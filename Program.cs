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
            CuentaCorriente cc = new CuentaCorriente ("123", 1500, new string[] { "Juan" },0.05m);
            cc.Retirar(500);

            CajaDeAhorro ca = new CajaDeAhorro ("123", 1500, new string[] { "Juan" },0.05m);
            cc.estado = Estado.Suspendida;
            cc.Retirar(200);
            
        }
    }
}
