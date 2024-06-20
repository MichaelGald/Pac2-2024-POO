namespace IntroduccionCsharp.Ejemplos.Herencia
{
    internal class EmpleadoPorHora : Empleado
    {
       

        public int HorasTrabajadas { get; set; }

        public decimal TarifaPorHora { get; set; } 
        public EmpleadoPorHora(string nombre, int id, decimal salarioBase, int horasTrabajadas, decimal tarifaPorHora) : base(nombre, id, salarioBase)
        {
            this.HorasTrabajadas = horasTrabajadas;
            this.TarifaPorHora = tarifaPorHora;
        }
        public override decimal CalcularSalario()
        {
            return TarifaPorHora * HorasTrabajadas;
        }
    }
}
