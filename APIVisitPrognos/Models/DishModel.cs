using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIVisitPrognos.Models
{
    public class DishModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Description { get; set; }
    }
}
