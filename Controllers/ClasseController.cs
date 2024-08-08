using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.DTOs.Classe;
using Api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("Api/classe")]
    [ApiController]
    public class ClasseController : ControllerBase
    {
        private readonly CoursContext _context;
        public ClasseController(CoursContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var classes = await _context.Classes
                .Include(c => c.Cours)
                .ToListAsync();
            var classesDto = classes.Select(s=>s.ToClasseDto());

            return Ok(classes);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromBody] string id){
            var classe =await _context.Classes.FindAsync(id);
            if(classe == null){
                return NotFound();
            }

            return Ok(classe.ToClasseDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClasseRequest createDto){
            var classeModel = createDto.ToClasseFromCreate();
           await  _context.Classes.AddAsync(classeModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = classeModel.Numclasse}, classeModel.ToClasseDto());
        }

        [HttpPut]
        [Route("{numClasse}")]
        public async Task<IActionResult> Update([FromRoute] string numClasse, [FromBody] UpdateClasseRequest updateDto){
            var classeModel =await _context.Classes.FirstOrDefaultAsync(x => x.Numclasse == numClasse);

            if (classeModel == null){
                return NotFound();
            }

            classeModel.Niveau = updateDto.Niveau;
            classeModel.Parcours = updateDto.Parcours;

            await _context.SaveChangesAsync();

            return Ok(classeModel.ToClasseDto());
        }

        [HttpDelete]
        [Route("{numClasse}")]
        public async Task<IActionResult> Delete([FromRoute] string numClasse){
            var classeModel =await _context.Classes.FirstOrDefaultAsync(x => x.Numclasse == numClasse);

            if (classeModel == null){
                return NotFound();
            }

            _context.Classes.Remove(classeModel);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}