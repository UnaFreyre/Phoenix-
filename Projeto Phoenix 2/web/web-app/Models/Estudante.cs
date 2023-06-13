namespace web_app.Models
{
    public class Estudante
    {
        public int EstudanteID { get; set; }
        public string Nome { get; set; }
        public int LoginID { get; set; }

        public Estudante()
        {
            this.EstudanteID = 0;
            this.Nome = string.Empty;
            this.LoginID = 0;
        }
    }
}
