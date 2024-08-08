using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.DTOs.Matiere;
using Api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("Api/matiere")]
    [ApiController]
    public class MatiereController : ControllerBase
    {
        private readonly CoursContext _context;
        public MatiereController(CoursContext context)
        {
            _context = context;
        } 

        [HttpGet]
        public IActionResult GetAll(){
            var matieres = _context.Matieres.ToList()
            .Select(s => s.ToMatiereDto());

            return Ok(matieres);
        }

        [HttpGet("{code}")]
        public IActionResult GetById([FromRoute] string code){
            var matiere = _context.Matieres.Find(code);

            if (matiere == null){
                return NotFound();
            }
            return Ok(matiere.ToMatiereDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMatiereRequest createDto){
            var matiereModel = createDto.ToMatiereFromCreate();
            _context.Matieres.Add(matiereModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {code = matiereModel.Codematiere}, matiereModel.ToMatiereDto());
        }

        [HttpPut]
        [Route("{code}")]
        public IActionResult Update([FromRoute] string code,[FromBody] UpdateMatiereRequest updateDto){
            var matiereModel = _context.Matieres.FirstOrDefault(x => x.Codematiere == code);

            if (matiereModel == null){
                return NotFound();
            }

            matiereModel.Nommatiere = updateDto.Nommatiere;

            _context.SaveChanges();
            return Ok(matiereModel.ToMatiereDto());
        }

        [HttpDelete]
        [Route("{code}")]
        public IActionResult Delete([FromRoute] string code){
            var matiereModel = _context.Matieres.FirstOrDefault(x => x.Codematiere == code);

            if (matiereModel == null){
                return NotFound();
            }

            _context.Matieres.Remove(matiereModel);
            _context.SaveChanges();
            
            return NoContent();
        }
    }
}