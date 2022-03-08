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

        [HttpPut("Edit")]
        public async Task<ActionResult<List<SuperHero>>> Edit(SuperHero superHero)
        {
            try
            {
                var hero = heroes.Find(x => x.Id == superHero.Id);
                if (superHero.Name != "") hero.Name = superHero.Name;
                if (superHero.FirstName != "") hero.FirstName = superHero.FirstName;
                if (superHero.LastName != "") hero.LastName = superHero.LastName;
                if (superHero.Place != "") hero.Place = superHero.Place;

                return Ok(heroes);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Herói não encontrado e não pode ser editado.");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            try
            {
                var hero = heroes.Find(x => x.Id == id);
                heroes.Remove(hero);

                return Ok(heroes);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Herói não encontrado e não pode ser deletado");
            }
        }
    }
}
