using APIVisitPrognos.Data.Entities;
using APIVisitPrognos.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIVisitPrognos.Data
{
    public class VisitPrognosProfile:Profile
    {
        public VisitPrognosProfile()
        {
            this.CreateMap<Dish, DishModel>().ReverseMap();
        }
        
    }
}
