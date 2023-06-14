namespace web_app.Models
{
    public class Conjunto
    {
        public IEnumerable<Professor> Professores { get; set; }
        public IEnumerable<Estudante> Estudantes { get; set; }
        public IEnumerable<Admin> Admins { get; set; }
        public IEnumerable<Login> Logins { get; set; }
    }
}
