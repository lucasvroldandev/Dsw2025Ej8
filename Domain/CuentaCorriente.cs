using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dsw2025Ej8.Domain.Exceptions;

namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente : CuentaBancaria
    {
        public decimal LimiteDescubierto { get; init; } //al inicializar,no por constructor,init.          para clase cuenta corriente
        public decimal Comision { get; private set; }//                                y cuenta corriente
        public CuentaCorriente(string numero, decimal saldo, string[] titulares,decimal comision) : base (numero, saldo, titulares)
        {
            Comision = comision;

        }
        public override void Depositar(decimal monto)
        {
            try
            {
                if (estado != Estado.Activa)
                    throw new CuentaNoActivaException(estado.ToString());

                if (monto <= 0)
                    throw new MontoNoValidoException();

                Saldo += monto;
            }
            catch (CuentaNoActivaException ex)
            {
                Console.WriteLine("Error: La cuenta no está activa. Estado: " + ex.Message);
            }
            catch (MontoNoValidoException ex)
            {
                Console.WriteLine("Error: Monto inválido. Detalle: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error desconocido: " + ex.Message);
            }
        }

        public override void Retirar(decimal monto)
        {
            try
            {
                if (estado != Estado.Activa)
                    throw new CuentaNoActivaException(estado.ToString());

                if (monto <= 0)
                    throw new MontoNoValidoException();

                if ((Saldo - monto) >= Saldo+LimiteDescubierto)
                {
                   
                    throw new SaldoInsuficienteException();
                }

                Saldo -= monto;
                Console.WriteLine($"Retiro exitoso. Nuevo saldo: {Saldo}");
            }
            catch (CuentaNoActivaException ex)
            {
                Console.WriteLine("Cuenta no activa: " + ex.Message);
            }
            catch (MontoNoValidoException ex)
            {
                Console.WriteLine("Monto inválido: " + ex.Message);
            }
            catch (SaldoInsuficienteException ex)
            {
                Console.WriteLine("Saldo insuficiente: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inesperado: " + ex.Message);
            }
        }

        public override void AplicarInteres()
        {
           
        }
    }

}

