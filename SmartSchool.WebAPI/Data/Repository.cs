using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly SmartSchoolContext _context;
        public Repository(SmartSchoolContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        //Alunos
        public Aluno[] GetAllAlunos()
        {
            throw new System.NotImplementedException();
        }

        public Aluno[] GetAllAlunosByDisciplinaId()
        {
            throw new System.NotImplementedException();
        }

        public Aluno[] GetAlunosById()
        {
            throw new System.NotImplementedException();
        }

        //Professor
        public Professor[] GetAllProfessores()
        {
            throw new System.NotImplementedException();
        }

        public Professor[] GetAllProfessoresByDisciplinaId()
        {
            throw new System.NotImplementedException();
        }

        public Professor[] GetProfessorById()
        {
            throw new System.NotImplementedException();
        }
    }
}