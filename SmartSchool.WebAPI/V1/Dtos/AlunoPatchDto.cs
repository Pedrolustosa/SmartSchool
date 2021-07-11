namespace SmartSchool.WebAPI.V1.Dtos
{
    public class AlunoPatchDto
    {
        /// <summary>
        /// Este é o DTO de Alunos para pequenas atualizações. Ex: 1 campo
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
    }
}