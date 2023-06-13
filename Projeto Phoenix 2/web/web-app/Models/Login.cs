namespace web_app.Models
{
    public class Login
    {
        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int TipoLogin { get; set; }

        public Login()
        {
            this.LoginId = 0;
            this.Username = string.Empty;
            this.Password = string.Empty;
            this.TipoLogin = 0;
        }
    }
}

