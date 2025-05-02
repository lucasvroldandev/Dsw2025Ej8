using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    internal class CuentaCorriente : CuentaBancaria
    {
        public decimal LimiteDescubierto { get; init; } //al inicializar,no por constructor,init.          para clase cuenta corriente
        public decimal Comision { get; private set; }//                                y cuenta corriente
        public CuentaCorriente(string numero, decimal saldo, string[] titulares,decimal comision) : base (numero, saldo, titulares)
        {
            Comision = comision;

        }
        public override void Depositar(decimal monto)
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
