using web_app.Repositories.ADO.SQLServer;

namespace web_app.Models
{
    public class Professor
    {
        public int ProfessorID { get; set; }
        public string Nome { get; set; }
        public int CursoID { get; set; }
        public int LoginID { get; set; }

        public Professor()
        {
            this.ProfessorID = 0;
            this.Nome = string.Empty;
            this.CursoID = 0;
            this.LoginID = 0;
        }
    }

}
