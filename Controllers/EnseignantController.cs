using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.DTOs.Enseignant;
using Api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("Api/enseignant")]
    [ApiController]
    public class EnseignantController : ControllerBase
    {
        private readonly CoursContext _context;
        public EnseignantController(CoursContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll(){
            var enseignants = _context.Enseignants.ToList();

            return Ok(enseignants);
        }

        [HttpGet("{num}")]
        public IActionResult GetById([FromRoute] int num){
            var enseignant = _context.Enseignants.Find(num);

            if (enseignant == null){
                return NotFound();
            }

            return Ok(enseignant.ToEnseignantDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateEnseignantRequest createDto){
            var enseignantModel = createDto.ToEnseignantFromCreate();
            _context.Enseignants.Add(enseignantModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {num = enseignantModel.Numenseignant}, enseignantModel.ToEnseignantDto());
        }

        [HttpPut]
        [Route("{num}")]
        public IActionResult Update([FromRoute] int num, [FromBody] UpdateEnseignantRequest updateDto){
            var enseignantModel = _context.Enseignants.FirstOrDefault(x => x.Numenseignant == num);

            if (enseignantModel == null){
                return NotFound();
            }

            enseignantModel.Nomenseignant = updateDto.Nomenseignant;
            enseignantModel.Prenomenseignant = updateDto.Prenomenseignant;
            enseignantModel.Civiliteenseignant = updateDto.Civiliteenseignant;

            _context.SaveChanges();
            return Ok(enseignantModel.ToEnseignantDto());
        }

        [HttpDelete]
        [Route("{num}")]
        public IActionResult Delete([FromRoute] int num){
            var enseignantModel = _context.Enseignants.FirstOrDefault(x => x.Numenseignant == num);
            
            if (enseignantModel == null){
                return NotFound();
            }

            _context.Enseignants.Remove(enseignantModel);
            _context.SaveChanges();

            return NoContent();
        }
    }
}