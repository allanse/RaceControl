using AutoMapper;
using RaceControl.Dominio.DTOs;
using RaceControl.Dominio.Entidades;

namespace RaceControl.Dominio.Mappers
{
    public class DtoToEntidadeMappingHistoricoCorrida: Profile
    {
        public DtoToEntidadeMappingHistoricoCorrida()
        {
            HistoricoCorridaMap();
        }

        private void HistoricoCorridaMap()
        {
            CreateMap<HistoricoCorridaDTO, HistoricoCorrida>().ReverseMap();
        }
    }
}
