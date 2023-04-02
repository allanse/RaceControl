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
    public class CompetidorController : ControllerBase
    {
        private readonly ServicoCompetidor servicoCompetidor;
        private readonly IMapper mapper;

        public CompetidorController (ServicoCompetidor servicoCompetidor, IMapper mapper)
        {
            this.servicoCompetidor = servicoCompetidor;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Competidor>> Adicionar([FromBody] CompetidorDTO competidorDTO)
        {
            
            Competidor competidor = mapper.Map<Competidor>(competidorDTO);

            try
            {
                if (competidor.ValidarClasse())
                {
                    await servicoCompetidor.Add(competidor);
                }                
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }              

            return Ok("Competidor inserido com sucesso!");
        }

        [HttpPut]
        public async Task<ActionResult<Competidor>> Atualizar([FromBody] CompetidorDTO competidorDTO)
        {

            Competidor competidor = mapper.Map<Competidor>(competidorDTO);

            try
            {
                if (competidor.ValidarClasse())
                {
                    await servicoCompetidor.Update(competidor);
                }
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }  

            return Ok("Competidor atualizado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Competidor>> Remover(int id)
        {
            await servicoCompetidor.Remove(id);

            return Ok("Competidor removido com sucesso!");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Competidor>> GetById(int id)
        {
            var result = await servicoCompetidor.GetById(id);
            if (result == null) return BadRequest("Competidor não encontrado!");

            return Ok(result);
        }

        [HttpGet]
        [Route("competidores-sem-corrida")]
        public async Task<ActionResult<IEnumerable<CompetidorSemCorridaDTO>>> GetCompetidoresSemCorrida()
        {
            var competidores = await servicoCompetidor.ObterCompetidoresSemCorrida();

            return Ok(competidores);
        }

        [HttpGet]
        [Route("competidores-com-tempo-medio")]
        public async Task<ActionResult<IEnumerable<CompetidorSemCorridaDTO>>> GetCompetidoresComTempoMedio()
        {
            var competidores = await servicoCompetidor.ObterCompetidoresComTempoMedioNasCorridas();

            return Ok(competidores);
        }
    }
}
