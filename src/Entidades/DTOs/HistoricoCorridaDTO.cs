using System;
using System.ComponentModel.DataAnnotations;

namespace RaceControl.Dominio.DTOs
{
    public class HistoricoCorridaDTO
    {
        [Key]
        public int? id { get; set; } = null;

        public int CompetidorId { get; set; }
        
        public int PistaCorridaId { get; set; }
        
        public DateTime DataCorrida { get; set; }
        
        public decimal TempoGasto { get; set; }
    }
}
