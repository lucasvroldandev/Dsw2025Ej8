using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dsw2025Ej8.Domain.Exceptions;

namespace Dsw2025Ej8.Domain;


public abstract class CuentaBancaria
{
  
    public string Numero {  get;  private set; }
    public decimal Saldo {  get; private set; }
    public Estado estado {  get; private set; }
    public string[] Titulares { get; private set; }

    public CuentaBancaria(string numero, decimal saldo , string[] titulares)
    {
        Numero = numero;
        Saldo = saldo;
        estado = Estado.Activa;
        Titulares = titulares;
    }
   

    public virtual void Depositar(decimal monto)
    {
        if (estado != Estado.Activa)
        {
            throw new CuentaNoActivaException();
        }
        else if (monto > 0)
        {
            monto += Saldo;
        }
        else 
        { 
            throw new MontoNoValidoException();
        } 
    }

    public virtual void Retirar(decimal monto)
    {
        if (estado != Estado.Activa)
        {
            throw new CuentaNoActivaException();
        }
        else if (monto < 0)
        {
            throw new MontoNoValidoException();
        }
        else if (monto >= Saldo)
        {
            throw new SaldoInsuficienteException();
        }
        else
        {
            monto -= Saldo;
        }
    }

    public virtual void AplicarInteres()
    {
        if (_tipo == TipoCuenta.CajaDeAhorro)
        {
            _saldo += _saldo * _tasaDeInteres;
        }
    }
}
