using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RaceControl.Dominio.DTOs;
using RaceControl.Dominio.Entidades;
using RaceControl.Dominio.Servicos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceControl.WebAPIs.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HistoricoCorridaController : ControllerBase
    {
        private readonly ServicoHistoricoCorrida servicoHistoricoCorrida;
        private readonly IMapper mapper;

        public HistoricoCorridaController (ServicoHistoricoCorrida servicoHistoricoCorrida, IMapper mapper)
        {
            this.servicoHistoricoCorrida = servicoHistoricoCorrida;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<HistoricoCorridaDTO>> Adicionar([FromBody] HistoricoCorridaDTO historicoCorridaDTO)
        {
            HistoricoCorrida historicoCorrida = mapper.Map<HistoricoCorrida>(historicoCorridaDTO);

            if (!servicoHistoricoCorrida.ValidarDataCorrida(historicoCorrida))
            {
                return BadRequest("Data inválida!");
            }
            await servicoHistoricoCorrida.Add(historicoCorrida);

            return Ok("Historico inserido com sucesso!");
        }

        [HttpPut]
        public async Task<ActionResult<HistoricoCorridaDTO>> Atualizar([FromBody] HistoricoCorridaDTO historicoCorridaDTO)
        {
            HistoricoCorrida historicoCorrida = mapper.Map<HistoricoCorrida>(historicoCorridaDTO);

            if (!servicoHistoricoCorrida.ValidarDataCorrida(historicoCorrida))
            {
                return BadRequest("Data inválida!");
            }

            await servicoHistoricoCorrida.Update(historicoCorrida);

            return Ok("Historico atualizado com sucesso!");
        }

        [HttpGet]
        [Route("pistas-utilizadas")]
        public async Task<ActionResult<IEnumerable<PistaCorrida>>> GetPistasUtilizadas()
        {
            var pistas = await servicoHistoricoCorrida.ObterPistasUtilizadas();
            
            return Ok(pistas);
        }        
    }
}
