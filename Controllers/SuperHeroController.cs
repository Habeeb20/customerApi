using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dotnet.models;
using Microsoft.AspNetCore.Http.HttpResults;
using Dotnet.Service.superHeroService;


namespace Dotnet.Controllers
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
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var result = await _superHeroService.GetAllHeroes();
            return Ok(result);
           
        }
        

        [HttpGet("{id}")]
        

        public async Task<ActionResult<SuperHero>>? GetSingleHero(int id) 
        {
           var result = await _superHeroService.GetSingleHero(id);
           if(result is null){
            return NotFound("hero not found");
           }
           return Ok(result);
        }
         [HttpPost]

        public async Task<ActionResult<List<SuperHero>>> Addhero(SuperHero hero)
        {
           var result =await  _superHeroService.AddHero(hero);
           return Ok(result);

        } 

        [HttpPut("{id}")]

        public async Task<ActionResult<List<SuperHero>>>? updatedHero(int id, SuperHero request)
        {
          var result =await  _superHeroService.updateHero(id, request );
          if(result is null){
            return NotFound("hero not found");
          }
          return Ok(result);

          
            
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<SuperHero>>>? DeleteHero(int id)
        {
           var result = await _superHeroService.DeleteHero(id);
           if(result is null){
            return NotFound("the hero not found");
           }
           return Ok(result);

        }
        
    }

  
}
