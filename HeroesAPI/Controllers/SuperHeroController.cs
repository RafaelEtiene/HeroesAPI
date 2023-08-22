using HeroesAPI.Models;
using HeroesAPI.Services.SuperHeroService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeroesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;
        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        [Route("GetAllHeroes")]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var result = await _superHeroService.GetAllHeroes();
            if (result is null)
                return NotFound("Hero not found!");

            return Ok(result);
        }

        [HttpGet]
        [Route("GetSingleHero/{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleSuperHero(int id)
        {
            var result = await _superHeroService.GetSingleSuperHero(id);
            if (result is null)
                return NotFound("Hero not found!");

            return Ok(result);
        }

        [HttpPost]
        [Route("AddHero")]
        public async Task<ActionResult<List<SuperHero>>> AddHero([FromBody] SuperHero request)
        {
            var result = await _superHeroService.AddHero(request);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateHero")]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero request)
        {
            var result = await _superHeroService.UpdateHero(request);

            if (result is null)
            {
                return NotFound("This hero doesn't exist.");
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("DeleteHero/{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            await _superHeroService.DeleteHero(id);
            return Ok();
        }
    }
}
