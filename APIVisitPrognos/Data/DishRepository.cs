using APIVisitPrognos.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIVisitPrognos.Data
{
    public class DishRepository:IDishRepository
    {
        private readonly AppDbContext _appDbContext;
        public DishRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Add<T>(T entity) where T : class
        {
            _appDbContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _appDbContext.Remove(entity);
        }


        public IEnumerable<Dish> GetAllDishes()
        {
            return  _appDbContext.Dishes;

        }


        public bool Save()
        {
            return  _appDbContext.SaveChanges() >= 0;
        }

        public Dish GetDishById(int id)
        {
            return _appDbContext.Dishes.FirstOrDefault(d => d.Id == id);
        }

        
    
}
}
