using Microsoft.Data.SqlClient;

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

    }
}
