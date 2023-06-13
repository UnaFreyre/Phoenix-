using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace web_app.Repositories.ADO.SQLServer
{
    public class Login
    {
        private readonly string connectionString;
        public Login(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool check(Models.Login login)
        {
            bool result = false;

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select LoginID from login where username=@username and Password=@Password";
                    command.Parameters.Add(new SqlParameter("@Username", System.Data.SqlDbType.VarChar)).Value = login.Username;
                    command.Parameters.Add(new SqlParameter("@Password", System.Data.SqlDbType.VarChar)).Value = login.Password;

                    SqlDataReader dr = command.ExecuteReader();
                    result = dr.Read();
                }
            }

            return result;
        }
        public Models.Login pegarId(Models.Login loginR)
        {
            Models.Login login = new Models.Login();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select TipoLoginID from login where Username=@Username and Password=@Password";
                    command.Parameters.Add(new SqlParameter("@Username", System.Data.SqlDbType.VarChar)).Value = loginR.Username;
                    command.Parameters.Add(new SqlParameter("@Password", System.Data.SqlDbType.VarChar)).Value = loginR.Password;

                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.Read())
                    {
                        login.LoginId = (int)dr["TipoLoginID"];
                    }
                }
            }

            return login;
        }

    }
}
