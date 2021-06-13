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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(x => x.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }
    }
}