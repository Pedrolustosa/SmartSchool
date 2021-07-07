using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class SmartSchoolContext : DbContext
    {
        public SmartSchoolContext(DbContextOptions<SmartSchoolContext> options) : base(options) { }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<AlunoCurso> AlunosCursos { get; set; }
        public DbSet<AlunoDisciplina> AlunosDisciplinas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AlunoDisciplina>()
                .HasKey(AD => new { AD.AlunoId, AD.DisciplinaId });

            builder.Entity<AlunoCurso>()
                .HasKey(AD => new { AD.AlunoId, AD.CursoId });
        }
    }
}