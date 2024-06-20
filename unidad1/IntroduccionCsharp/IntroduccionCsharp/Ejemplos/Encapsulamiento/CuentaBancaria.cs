namespace IntroduccionCsharp.Ejemplos.Encapsulamiento
{
    public class CuentaBancaria
    {
        private decimal Saldo { get; set; }

        public CuentaBancaria(decimal saldoInicial)
        {
            Saldo = saldoInicial;
        }

        public void Depositar(decimal cantidad)
        {
            if (cantidad > 0)
            {
                Saldo += cantidad; // Saldo = Saldo + cantidad
            }
            else 
            {
                Console.WriteLine("La canridad debe ser positiva."); // rechazarte vv
            }
        }

        public void Retirar(decimal cantidad) 
        {
            if (cantidad > 0 && cantidad <= Saldo)
            {
                Saldo -= cantidad;
            }
            else 
            {
                Console.WriteLine("Cantidad invalidad para retirar.");
            }
        }

        public decimal ObtenerSaldo() 
        {
            return Saldo;
        }
    }
}
