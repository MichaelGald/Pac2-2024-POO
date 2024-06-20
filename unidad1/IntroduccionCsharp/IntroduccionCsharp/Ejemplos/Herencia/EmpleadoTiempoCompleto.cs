namespace IntroduccionCsharp.Ejemplos.Herencia
{
    internal class EmpleadoTiempoCompleto : Empleado
    {
        public decimal Bono { get; set; }

        public EmpleadoTiempoCompleto(string nombre, int id, decimal salarioBase, decimal bono) : base(nombre, id, salarioBase)
        {
            this.Bono = bono;
        }



        public override decimal CalcularSalario()
        {
            return SalarioBase + Bono;
        }
    }
}
