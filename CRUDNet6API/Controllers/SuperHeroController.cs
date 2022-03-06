using CRUDNet6API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDNet6API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>
            {
                new SuperHero {
                    Id = 1,
                    Name = "Spider-man",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York City"
                },
                new SuperHero
                {
                    Id = 2,
                    Name = "Ironman",
                    FirstName = "Tony",
                    LastName = "Stark",
                    Place = "Long Island"
                }
            };

        [HttpGet("Get")]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heroes);
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = heroes.Find(x => x.Id == id);
            if (hero == null) return BadRequest("Super-heroi nao encontrado");
            return Ok(hero);
        }


        [HttpPost("Add")]
        public async Task<ActionResult<List<SuperHero>>> Add(SuperHero superHero)
        {
            heroes.Add(superHero);
            return Ok(heroes);
        }
    }
}
