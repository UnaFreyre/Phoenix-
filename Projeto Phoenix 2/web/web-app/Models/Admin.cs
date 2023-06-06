namespace web_app.Models
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string Nome { get; set; }
        public int LoginID { get; set; }
        public Admin()
        {
            this.AdminID = 0;
            this.Nome = string.Empty;
            this.LoginID = 0;
        }
    }
}
