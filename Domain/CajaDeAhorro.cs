using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CajaDeAhorro : CuentaBancaria
    {
        public decimal TasaInteres { get; init; } //al inicializar,no por constructor,init. para subclase          caja de ahorro
        public CajaDeAhorro (string numero, decimal saldo, string[] titulares) : base (numero, saldo, titulares)
        {


        }
        public  override void Depositar(decimal monto)
        {
            if (_tipo == TipoCuenta.CajaDeAhorro)
            {
                _saldo += monto;
            }
            else if (_tipo == TipoCuenta.CuentaCorriente)
            {
                monto -= monto * _comision;
                _saldo += monto;
            }
        }

        public override void Retirar(decimal monto)
        {
            if (_tipo == TipoCuenta.CajaDeAhorro)
            {
                _saldo -= monto;
            }
            else if (_tipo == TipoCuenta.CuentaCorriente)
            {
                if (_saldo - monto >= -_limiteDeDescubierto)
                {
                    _saldo -= monto;
                }
                if (_saldo < 0)
                {
                    _estado = Estado.Suspendida;
                }
            }
        }

        public override void AplicarInteres()
        {
            if (_tipo == TipoCuenta.CajaDeAhorro)
            {
                _saldo += _saldo * _tasaDeInteres;
            }
        }
    }
}
}
// buenas tardes me estimad cleingte 