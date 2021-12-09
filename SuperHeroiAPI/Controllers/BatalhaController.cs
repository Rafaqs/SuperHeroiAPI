using Hero.Dominio;
using Hero.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SuperHeroiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatalhaController : ControllerBase
    {
        private readonly IHeroRepository _repo;

        public BatalhaController(IHeroRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<BatalhaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var batalhas = await _repo.GetAllBatalhas(true);
                return Ok(batalhas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET api/<BatalhaController>/5
        [HttpGet("{id}", Name = "GetBatalha")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var batalhas = await _repo.GetBatalhaById(id, true);
                return Ok(batalhas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // POST api/<BatalhaController>
        [HttpPost]
        public async Task<IActionResult> Post(Batalha model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangeAsync())
                {
                    return Ok("Adicionado");
                }   
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Não Adicionado");
        }

        // PUT api/<BatalhaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Batalha model)
        {
            try
            {
                var batalha = await _repo.GetBatalhaById(id);
                if (batalha != null)
                {
                    _repo.Update(model);
                    if (await _repo.SaveChangeAsync())
                        return Ok("Atualizado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest($"Não Atualizado!");
        }

        // DELETE api/<BatalhaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var batalha = await _repo.GetBatalhaById(id);
                if(batalha != null)
                {
                    _repo.Delete(batalha);
                    if (await _repo.SaveChangeAsync())
                        return Ok("Deletado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest($"Não Deletado!");
        }
    }
}
