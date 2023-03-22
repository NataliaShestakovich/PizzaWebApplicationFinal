using Microsoft.EntityFrameworkCore;
using PizzaWebAppAuthentication.Data;
using PizzaWebAppAuthentication.Models.AppModels;
using PizzaWebAppAuthentication.Repositories.RepositoryBase;

namespace PizzaWebAppAuthentication.Repositories.IngredientRepository
{
    public class IngredientRepository: RepositoryBase<Ingredient, int>, IIngredientRepository
    {
        public IngredientRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
       
        public async Task<IEnumerable<Ingredient>> GetIngredientsByName(string name) 
        {
            return await _dbContext.Set<Ingredient>().Where(i => i.Name == name).ToListAsync();
        }
        
        public async Task<bool> IngredientExistsAsync(string name, int id)
        {
            return await _dbContext.Set<Ingredient>().AnyAsync(i => i.Name == name && i.Id != id);
        }
    }
}
