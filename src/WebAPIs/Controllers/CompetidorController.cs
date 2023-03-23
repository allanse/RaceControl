﻿using Microsoft.AspNetCore.Mvc;
using RaceControl.Dominio.Entidades;
using RaceControl.Dominio.Servicos;
using System.Threading.Tasks;

namespace RaceControl.WebAPIs.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompetidorController : ControllerBase
    {
        private readonly ServicoCompetidor servicoCompetidor;

        public CompetidorController (ServicoCompetidor servicoCompetidor)
        {
            this.servicoCompetidor = servicoCompetidor;
        }

        [HttpPost]
        public async Task<ActionResult<Competidor>> Adicionar([FromBody] Competidor competidor)
        {
            if (!servicoCompetidor.ValidarCompetidor(competidor))
            {
                return BadRequest("Competidor inválido!");
            }

            await servicoCompetidor.Add(competidor);

            return Ok("Competidor inserido com sucesso!");
        }

        [HttpPut]
        public async Task<ActionResult<Competidor>> Atualizar([FromBody] Competidor competidor)
        {
            if (!servicoCompetidor.ValidarCompetidor(competidor))
            {
                return BadRequest("Competidor inválido!");
            }

            await servicoCompetidor.Update(competidor);

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

    }
}