using System.Linq;
using SmartSchool.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartSchoolContext _context;

        public ProfessorController(SmartSchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        [HttpGet("ById/{id}")]
        public IActionResult GetById(int id)
        {
            var professores = _context.Professores.FirstOrDefault(x => x.Id == id);
            if (professores == null) return BadRequest("Professor não encontrado");
            return Ok(professores);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome)
        {
            var professores = _context.Professores.FirstOrDefault(
                x => x.Nome.Contains(nome)
            );
            if (professores == null) return BadRequest("O Nome do professore não foi encontrado");
            return Ok(professores);
        }

        [HttpPost]
        public IActionResult Post(Professor Professor)
        {
            _context.Add(Professor);
            _context.SaveChanges();
            return Ok(Professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor Professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (prof == null) return BadRequest("Professor não encontrado!");

            _context.Update(Professor);
            _context.SaveChanges();
            return Ok(Professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor Professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (prof == null) return BadRequest("Professor não encontrado!");

            _context.Update(Professor);
            _context.SaveChanges();
            return Ok(Professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (professor == null) return BadRequest("Professor não encontrado!");

            _context.Remove(professor);
            _context.SaveChanges();
            return Ok();
        }
    }
}