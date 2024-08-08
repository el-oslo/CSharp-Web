using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.DTOs.Cours;
using Api.Mappers;
using Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("Api/cours")]
    [ApiController]
    public class CoursController : ControllerBase
    {
        private readonly CoursContext _context;
        public CoursController(CoursContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            Console.WriteLine("Received a get request for cours");
            var cours = await _context.Cours
                        .Include( c => c.CodematiereNavigation)
                        .Include( c => c.NumclasseNavigation)
                        .Include( c => c.NumenseignantNavigation)
                        .Include( c => c.NumsalleNavigation)
                        .ToListAsync();
            
            var coursDto = cours.Select( s => s.ToCoursDto());
            return Ok(cours);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var cour = await _context.Cours
                        .Include( c => c.CodematiereNavigation)
                        .Include( c => c.NumclasseNavigation)
                        .Include( c => c.NumenseignantNavigation)
                        .Include( c => c.NumsalleNavigation)
                        .FirstOrDefaultAsync(c => c.Numcours == id);
            if(cour == null){
                return NotFound();
            }

            return Ok(cour.ToCoursDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCoursRequest createDto){
            var codematiere = await _context.Matieres.FirstOrDefaultAsync(m => m.Codematiere == createDto.Codematiere);
            var enseignant = await _context.Enseignants.FirstOrDefaultAsync(e => e.Numenseignant == createDto.Numenseignant);
            var classe = await _context.Classes.FirstOrDefaultAsync(c => c.Numclasse == createDto.Numclasse);
            var salle = await _context.Salles.FirstOrDefaultAsync(s => s.Numsalle == createDto.Numsalle);

            if (codematiere == null || enseignant == null || classe == null || salle == null)
            {
                return BadRequest("Invalid foreign key references.");
            }


            var cour = new Cour
            {
                Codematiere = createDto.Codematiere,
                Numenseignant = createDto.Numenseignant,
                Numclasse = createDto.Numclasse,
                Numsalle = createDto.Numsalle,
                Date = DateOnly.Parse(createDto.Date),
                Heuredebut = TimeOnly.Parse(createDto.Heuredebut),
                Heurefin = TimeOnly.Parse(createDto.Heurefin),
                CodematiereNavigation = codematiere,
                NumenseignantNavigation = enseignant,
                NumclasseNavigation = classe,
                NumsalleNavigation = salle
            };

            await _context.Cours.AddAsync(cour);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetById), new {id = cour.Numcours}, cour.ToCoursDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateCoursRequest updateDto){
            var cour = _context.Cours.FirstOrDefault(x => x.Numcours == id);
            if (cour == null){
                return NotFound();
            }

            cour.Codematiere = updateDto.Codematiere;
            cour.Numenseignant = updateDto.Numenseignant;
            cour.Numsalle = updateDto.Numsalle;
            cour.Numclasse = updateDto.Numclasse;
            cour.Date = updateDto.Date;
            cour.Heuredebut = updateDto.Heuredebut;
            cour.Heurefin = updateDto.Heurefin;

            _context.SaveChanges();
            return Ok(cour.ToCoursDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id){
            var cour = _context.Cours.FirstOrDefault(x => x.Numcours == id);
            if (cour == null){
                return NotFound();
            }

            _context.Cours.Remove(cour);
            _context.SaveChanges();
            return NoContent();
        }
    }
}