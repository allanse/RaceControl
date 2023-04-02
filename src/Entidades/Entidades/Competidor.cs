using System;
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
        public char Sexo { get; set; }

        [Required]
        public decimal TemperaturaMediaCorpo { get; set; }

        [Required]
        public decimal Peso { get; set; }

        [Required]
        public decimal Altura { get; set; }

        private bool ValidarSexo()
        {
            switch (Sexo)
            {
                case 'M': return true;
                case 'F': return true;
                case 'O': return true;
                default:
                    throw new Exception("A propriedade Sexo deve ser M, F ou O"); ;
            }
        }
        private bool ValidarTemperatura()
        {
            if (TemperaturaMediaCorpo >= 36 && TemperaturaMediaCorpo <= 38)
            {
                return true;
            }

            throw new Exception("A temperatura média do corpo deve estar entre 36 e 38 graus"); ;
        }

        private bool ValidarPeso()
        {
            if (Peso > 0)
            {
                return true;
            }

            throw new Exception("O peso deve ser maior que 0"); ;
        }

        private bool ValidarAltura()
        {
            if (Altura > 0)
            {
                return true;
            }

            throw new Exception("A altura deve ser maior que 0"); ;
        }

        public bool ValidarClasse()
        {
            //Se os atributos validados estiverem corretos retorna true senão irá retornar uma exception
            ValidarSexo();

            ValidarTemperatura();

            ValidarPeso();

            ValidarAltura();            

            return true;
        }
    }
}
