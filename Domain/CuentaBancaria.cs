namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
  
    public string Numero {  get; set; }
    public decimal Saldo {  get; set; }
    public Estado estado {  get; set; }
    public string[] Titulares { get; set; }

    public CuentaBancaria(string numero, decimal saldo , string[] titulares)
    {
        Numero = numero;
        Saldo = saldo;
        estado = Estado.Activa;
        Titulares = titulares;
    }
   

    public virtual void Depositar(decimal monto)
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

    public virtual void Retirar(decimal monto)
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

    public virtual void AplicarInteres()
    {
        if (_tipo == TipoCuenta.CajaDeAhorro)
        {
            _saldo += _saldo * _tasaDeInteres;
        }
    }
}
