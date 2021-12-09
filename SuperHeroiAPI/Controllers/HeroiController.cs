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
    public class HeroiController : ControllerBase
    {
        private readonly IHeroRepository _repo;

        public HeroiController(IHeroRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<HeroiController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var herois = await _repo.GetAllHerois(true);

                return Ok(herois);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET api/<HeroiController>/5
        [HttpGet("{id}", Name = "GetHeroi")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var herois = await _repo.GetHeroiById(id, true);

                return Ok(herois);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // POST api/Heroi
        [HttpPost]
        public async Task<IActionResult> Post(Heroi model)
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

        // PUT api/<HeroiController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Heroi model)
        {
            try
            {
                var heroi = await _repo.GetHeroiById(id);
                if (heroi != null)
                {
                    _repo.Update(model);

                    if (await _repo.SaveChangeAsync())
                        return Ok("Alterado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest($"Não Alterado!");
        }

        // DELETE api/<HeroiController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var heroi = await _repo.GetHeroiById(id);
                if (heroi != null)
                {
                    _repo.Delete(heroi);

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

