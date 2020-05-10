using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIVisitPrognos.Data.Entities
{
    public class AppDbContext:DbContext
    {
        public DbSet<Dish> Dishes { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>().HasData(new
            {
                Id = 1,        
                
                Description = "Gräddig kreolsk kotlettfilé med chorizo,cornichons och paprika,stekt potatis och sötsyrlig tomatsallad"
            }, new
            {
                Id = 2,
                Description = "Fiskgratäng med dillad räk- och vitvinssås, potatismos och citrusdressad morotssallad"
            }, new
            {
                Id = 3,
                Description = "Dansk sjömansbiff med lök och potatis, pressgurka, lingon och rostad blomkål med pumpafröströssel"
            }, new
            {
                Id = 4,
                Description = "Stekt marinerad kycklingfilé, sval sås med ramslök, citron och brynt smör, ugnsstekt potatis och haricots vertssallad",


            },
            new
            {
                Id = 5,
                Description = "Smördegsbakad cheddarpaj med stekt bacon, gräslökscrème och melonsallad.",


            }
            );


        }
        }
}
