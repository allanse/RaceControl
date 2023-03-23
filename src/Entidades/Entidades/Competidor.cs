using Dominio.Enums;
using System.ComponentModel.DataAnnotations;

namespace RaceControl.Dominio.Entidades
{
    public class Competidor : EntidadeBase
    {
        public Competidor()
        {

        }
        [Required, MaxLength(150, ErrorMessage ="O Nome do competidor não pode ter mais que 150 caracteres")]
        public string Nome { get; set; }
        [Required]
        public ESexo Sexo { get; set; }
        [Required, Range(36,38, ErrorMessage ="A temperatura média do corpo deve estar entre 36 e 38 graus")]
        public decimal TemperaturaMediaCorpo { get; set; }
        [Required]
        public decimal Peso { get; set; }
        [Required]
        public decimal Altura { get; set; }
    }
}
