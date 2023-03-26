namespace RaceControl.Dominio.DTOs
{
    public class CompetidorDTO
    {
        public int? id { get; set; } = null;
        public string Nome { get; set; }

        public char Sexo { get; set; }

        public decimal TemperaturaMediaCorpo { get; set; }

        public decimal Peso { get; set; }

        public decimal Altura { get; set; }
    }
}
