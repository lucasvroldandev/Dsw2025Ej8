using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dsw2025Ej8.Domain.Exceptions;

namespace Dsw2025Ej8.Domain;


public abstract class CuentaBancaria
{
  
    public string Numero {  get;   set; }
    public decimal Saldo {  get;  set; }
    public Estado estado {  get; set; }
    public string[] Titulares { get; set; }
    

    public CuentaBancaria(string numero, decimal saldo , string[] titulares )
    {
        Numero = numero;
        Saldo = saldo;
        estado = Estado.Activa;
        Titulares = titulares;
       
    }
   

    public virtual void Depositar(decimal monto)
    {}

    public virtual void Retirar(decimal monto) { }

    public virtual void AplicarInteres()
    {}
}
