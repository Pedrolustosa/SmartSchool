using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly SmartSchoolContext _context;

        public AlunoController(SmartSchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        /// <summary>
        /// Api/Aluno/ById/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ById/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(x => x.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }

        /// <summary>
        /// Api/Aluno/Name
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="sobrenome"></param>
        /// <returns></returns>
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(
                x => x.Nome.Contains(nome) &&
                x.Sobrenome.Contains(sobrenome)
            );
            if (aluno == null) return BadRequest("O Nome do Aluno não foi encontrado");
            return Ok(aluno);
        }

        /// <summary>
        /// Api/Aluno
        /// </summary>
        /// <param name="aluno"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        /// <summary>
        /// Api/Aluno
        /// </summary>
        /// <param name="id"></param>
        /// <param name="aluno"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        /// <summary>
        /// Api/Aluno
        /// </summary>
        /// <param name="id"></param>
        /// <param name="aluno"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        /// <summary>
        /// Api/Aluno
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}