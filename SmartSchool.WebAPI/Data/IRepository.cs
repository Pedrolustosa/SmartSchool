using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T ebtity) where T : class;
        void Update<T>(T ebtity) where T : class;
        void Delete<T>(T ebtity) where T : class;
        bool SaveChanges();


        //Alunos
        Aluno[] GetAllAlunos();
        Aluno[] GetAllAlunosByDisciplinaId();
        Aluno[] GetAlunosById();

        //Professores
        Professor[] GetAllProfessores();
        Professor[] GetAllProfessoresByDisciplinaId();
        Professor[] GetProfessorById();

    }
}