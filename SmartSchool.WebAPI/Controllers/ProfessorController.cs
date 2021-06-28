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
        private readonly IRepository _repo;

        public ProfessorController(SmartSchoolContext context, IRepository repo)
        {
            _repo = repo;
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
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não cadastrado!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (prof == null) return BadRequest("Professor não encontrado!");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (prof == null) return BadRequest("Professor não encontrado!");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
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