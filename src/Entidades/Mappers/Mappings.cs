using AutoMapper;
using RaceControl.Dominio.DTOs;
using RaceControl.Dominio.Entidades;

namespace RaceControl.Dominio.Mappers
{
    public class Mappings: Profile
    {
        public Mappings()
        {
            CreateMap<HistoricoCorridaDTO, HistoricoCorrida>().ReverseMap();
            CreateMap<CompetidorDTO, Competidor>().ReverseMap();
        }
    }
}
