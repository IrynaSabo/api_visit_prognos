using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIVisitPrognos.Data;
using APIVisitPrognos.Data.Entities;
using APIVisitPrognos.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APIVisitPrognos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DishesController : ControllerBase
    {
        private readonly IDishRepository _repository;
        private readonly IMapper _mapper;
        public DishesController(IDishRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            
        }
        [HttpGet]
        public ActionResult<IEnumerable<Dish>> GetAll()
        {
            try
            {
                var results =  _repository.GetAllDishes();

                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id:int}")]
        public ActionResult<Dish> GetDishmById(int id)
        {
            try
            {
                var result = _repository.GetDishById(id);

                if (result == null) return NotFound();

                return Ok(result);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
        [HttpPost]
        public ActionResult<DishModel> Post(DishModel model)
        {
            try
            {
                var dish = _mapper.Map<Dish>(model);
                _repository.Add(dish);
                if ( _repository.Save())
                {
                    return Created($"/api/dishes/{dish.Id}", _mapper.Map<DishModel>(dish));
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            return BadRequest();
        }
        // PUT api/<controller>/5
        [HttpPut("{id:int}")]
        public ActionResult<DishModel> Put(int id, DishModel model)
        {
            try
            {
                var selectedDish =  _repository.GetDishById(id);
                if (selectedDish == null) return NotFound($"Could not find dish with id of {id}");

                _mapper.Map(model, selectedDish);

                if ( _repository.Save())
                {
                    return _mapper.Map<DishModel>(selectedDish);
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();

        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var selectedDish =  _repository.GetDishById(id);
                if (selectedDish == null) return NotFound();

                _repository.Delete(selectedDish);

                if ( _repository.Save())
                {
                    return Ok();
                }

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest("Failed to delete the studio");
        }
    }
}
