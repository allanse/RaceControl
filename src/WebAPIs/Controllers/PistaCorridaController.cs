using Microsoft.AspNetCore.Mvc;
using RaceControl.Dominio.Entidades;
using RaceControl.Dominio.Servicos;
using System.Threading.Tasks;

namespace RaceControl.WebAPIs.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PistaCorridaController : ControllerBase
    {
        private readonly ServicoPistaCorrida servicoPistaCorrida;

        public PistaCorridaController (ServicoPistaCorrida servicoPistaCorrida)
        {
            this.servicoPistaCorrida = servicoPistaCorrida;
        }

        [HttpPost]
        public async Task<ActionResult<PistaCorrida>> Adicionar([FromBody] PistaCorrida PistaCorrida)
        {
            await servicoPistaCorrida.Add(PistaCorrida);

            return Ok("Pista inserida com sucesso!");
        }

        [HttpPut]
        public async Task<ActionResult<PistaCorrida>> Atualizar([FromBody] PistaCorrida PistaCorrida)
        {    
            await servicoPistaCorrida.Update(PistaCorrida);

            return Ok("Pista atualizada com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PistaCorrida>> Remover(int id)
        {
            await servicoPistaCorrida.Remove(id);

            return Ok("Pista removida com sucesso!");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PistaCorrida>> GetById(int id)
        {
            var result = await servicoPistaCorrida.GetById(id);
            if (result == null) return BadRequest("Pista não encontrada!");

            return Ok(result);
        }

    }
}
