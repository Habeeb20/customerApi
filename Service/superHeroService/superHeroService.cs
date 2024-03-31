using System;
using Dotnet.Data;
namespace Dotnet.Service.superHeroService
{
    public class  superHeroService : ISuperHeroService
    {
         private static List<SuperHero> superhero = new List<SuperHero> {
                new SuperHero{Id = 1, Name = "spiderMan", FirstName = "peter", LastName = "john", Place = "new york"}
        };

        private readonly DataContext _context;


        public superHeroService(DataContext context)
        {
            _context = context;
            
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await _context.SuperHero.ToListAsync();
            return heroes;
        }

        public async Task<SuperHero?> GetSingleHero(int id)
        {
           var hero = await _context.SuperHero.FindAsync(id);
            if(hero is null ){
                return null;
            }
            return hero;

        }

        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            _context.SuperHero.Add(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHero.ToListAsync();

        }

        public async Task<List<SuperHero>?> updateHero(int id, SuperHero request)
        {
             var hero =await _context.SuperHero.FindAsync(id);
            if(hero is null){
                return null;
            }

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;

            await _context.SaveChangesAsync();
            return await _context.SuperHero.ToListAsync();
        }

        public async Task<List<SuperHero>?> DeleteHero(int id)
        {
             var hero =await _context.SuperHero.FindAsync(id);
            if(hero is null){
                return null;
            }

            _context.SuperHero.Remove(hero);
             await _context.SaveChangesAsync();
            return superhero;
        }
    }
}