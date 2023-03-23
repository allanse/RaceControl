using RaceControl.Dominio.Entidades;
using RaceControl.Dominio.Interfaces;

namespace RaceControl.Dominio.Servicos
{
    public class ServicoCompetidor : ServicoBase<Competidor>
    {
        public ServicoCompetidor(IRepositorioBase<Competidor> repositorio) : base(repositorio)
        {
        }

        public bool ValidarCompetidor(Competidor competidor)
        {
            if (competidor.Peso <=0)
            {
                return false;
            }

            if (competidor.Altura <= 0)
            {
                return false;
            }

            return true;
        }

    }
}
