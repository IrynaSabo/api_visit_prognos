using APIVisitPrognos.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIVisitPrognos.Data
{
    public interface IDishRepository
    {
         void Add<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;

         IEnumerable<Dish> GetAllDishes();
         Dish  GetDishById(int id);       

         bool Save();
        
    }
}
