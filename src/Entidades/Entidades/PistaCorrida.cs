using System.ComponentModel.DataAnnotations;

namespace RaceControl.Dominio.Entidades
{
    public class PistaCorrida: EntidadeBase
    {
        public PistaCorrida()
        {

        }
        [Required, MaxLength(50, ErrorMessage = "A descrição da pista não pode ter mais que 50 caracteres")]
        public virtual string Descricao { get; set; }
    }
}
