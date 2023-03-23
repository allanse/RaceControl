using System;
using System.ComponentModel.DataAnnotations;

namespace RaceControl.Dominio.Entidades
{
    public class HistoricoCorrida: EntidadeBase
    {
        public HistoricoCorrida() { }

        [Required]
        public int CompetidorId { get; set; }
        [Required]
        public int PistaCorridaId { get; set; }
        [Required]
        public DateTime DataCorrida { get; set; }
        [Required]
        public decimal TempoGasto { get; set; }
        public virtual Competidor Competidor { get; set; }
        public virtual PistaCorrida PistaCorrida { get; set; }
    }
}
