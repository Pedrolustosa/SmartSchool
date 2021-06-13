using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno(){
                Id = 1,
                Nome = "Maria",
                 Sobrenome = "Lustosa",
                Telefone = "123456789"
            },
            new Aluno(){
                Id = 2,
                Nome = "Pedro",
                Sobrenome = "Lustosa",
                Telefone = "123456799"
            },
        };
        public AlunoController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        [HttpGet("ById/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(x => x.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(
                x => x.Nome.Contains(nome) &&
                x.Sobrenome.Contains(sobrenome)
            );
            if (aluno == null) return BadRequest("O Nome do Aluno não foi encontrado");
            return Ok(aluno);
        }
    }
}