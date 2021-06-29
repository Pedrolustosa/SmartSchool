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
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetProfessorById(id, false);
            if (aluno == null) return BadRequest("O Aluno não encontrado");

            return Ok(aluno);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="professor"></param>
        /// <returns></returns>
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
            var prof = _repo.GetProfessorById(id, false);
            if (prof == null) return BadRequest("Professor não encontrado!");

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não atualizado!");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id, false);
            if (prof == null) return BadRequest("Professor não encontrado!");

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não atualizado!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _repo.GetProfessorById(id, false);
            if (prof == null) return BadRequest("Professor não encontrado!");

            _repo.Delete(prof);
            if (_repo.SaveChanges())
            {
                return Ok("Professor deletado!");
            }
            return BadRequest("Professor não deletado!");
        }
    }
}