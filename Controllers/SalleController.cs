using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.DTOs.Salle;
using Api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("Api/salle")]
    [ApiController]
    public class SalleController : ControllerBase
    {
        private readonly CoursContext _context;
        public SalleController(CoursContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll(){
            var salles = _context.Salles.ToList()
            .Select(s => s.ToSalleDto());

            return Ok(salles);
        }

        [HttpGet("{num}")]
        public IActionResult GetById([FromRoute] int num){
            var salle = _context.Salles.Find(num);
            if (salle == null){
                return NotFound();
            }

            return Ok(salle.ToSalleDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateSalleRequest createDto){
            var salle = createDto.ToSalleFromCreate();
            _context.Salles.Add(salle);

            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {num = salle.Numsalle}, salle.ToSalleDto());
        }

        [HttpPut]
        [Route("{num}")]
        public IActionResult Update([FromRoute] int num, [FromBody] UpdateSalleRequest updateDto){
            var salle = _context.Salles.Find(num);
            if (salle ==null){
                return NotFound();
            }

            salle.Designsalle = updateDto.Designsalle;

            _context.SaveChanges();
            return Ok(salle.ToSalleDto()); 
        }

        [HttpDelete]
        [Route("{num}")]
        public IActionResult Delete([FromRoute] int num){
            var salle = _context.Salles.Find(num);
            if (salle ==null){
                return NotFound();
            }

            _context.Salles.Remove(salle);
            
            _context.SaveChanges();
            return NoContent();
        }
        
    }
}