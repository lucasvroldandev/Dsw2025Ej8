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
        public decimal TasaInteres { get; init; }
        public CuentaCorriente(string numero, decimal saldo, string[] titulares,decimal comision) : base (numero, saldo, titulares)
        {
            Comision = comision;

        }
        public override void Depositar(decimal monto)
        {
            decimal ComisionDescontar = monto * Comision;
            try
            {
                if (estado != Estado.Activa)
                    throw new CuentaNoActivaException(estado.ToString());

                if (monto <= 0)
                    throw new MontoNoValidoException();

                Saldo +=( monto+ComisionDescontar);
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
            decimal ComisionDescontar = monto * Comision;
            try
            {
                if (estado != Estado.Activa)
                    throw new CuentaNoActivaException(estado.ToString());

                if (monto <= 0)
                    throw new MontoNoValidoException();

                if ((monto+ComisionDescontar) >= Saldo+LimiteDescubierto)
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
            try
            {
                if (Saldo > 0) // Ejemplo: Solo aplica interés si el saldo es positivo
                {
                    decimal interes = Saldo * TasaInteres;  
                    Saldo += interes;
                }
                else
                {
                    throw new SaldoInsuficienteException();
                }
            }
            catch (SaldoInsuficienteException ex)
            {
                Console.WriteLine($"Advertencia: {ex.Message}"); 
            }

        }
    }

}

//comision costo de cuenta corriente es por retiro
//intereses es remuneracon por tener dinero,rendimiento
