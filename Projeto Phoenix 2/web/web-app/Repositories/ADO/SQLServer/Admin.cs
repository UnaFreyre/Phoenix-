using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using web_app.Models;

namespace web_app.Repositories.ADO.SQLServer
{
    public class Admin
    {
        private readonly string connectionString; //Declarado para toda a classe. Possível alterar somente no construtor.
        public Admin(string connectionString) //Quem invocar o construtor do repositório deve enviar a string de conexão.
        {
            this.connectionString = connectionString; //atualização do atributo por meio do valor que veio no parâmetro do construtor..
        }

        public void add(Models.Admin Admin)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into Admin (nome, loginid) values (@nome,@loginid); select convert(int,@@identity) as Adminid;;";

                    command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = Admin.Nome;
                    command.Parameters.Add(new SqlParameter("@loginid", System.Data.SqlDbType.Date)).Value = Admin.LoginID;

                    Admin.AdminID = (int)command.ExecuteScalar(); // o homem do saco leva os dados até o sgbd e volta com o valor do id => ExecuteScalar retorna um único valor. Observe que o CommandText foi alterado com mais uma instrução. Então, as duas instruções são executadas e temos como retorno o valor do id que foi gerado pelo sgbd na tabela Admin. Assim, conseguimos atualizar o valor do id do objeto Admin que antes da inserção era 0.
                }
            }
        }

        public List<Models.Admin> get()
        {
            List<Models.Admin> Admines = new List<Models.Admin>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select Adminid, nome, loginid from Admin;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Models.Admin Admin = new Models.Admin();
                        Admin.AdminID = (int)dr["Adminid"];
                        Admin.Nome = (string)dr["nome"];
                        Admin.LoginID = (int)dr["loginid"];
                        Admines.Add(Admin);
                    }
                }
            }

            return Admines;
        }

        public void delete(int Adminid)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "delete from Admin where Adminid = @Adminid;";
                    command.Parameters.Add(new SqlParameter("@Adminid", System.Data.SqlDbType.Int)).Value = Adminid;

                    command.ExecuteNonQuery();
                }
            }
        }

        public Models.Admin getById(int Adminid) //somente 1 Admin.
        {
            Models.Admin Admin = new Models.Admin();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select adminid, nome, tipologin from Admin where Adminid=@Adminid;";
                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = Adminid;

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {
                        Admin.AdminID = (int)dr["Adminid"];
                        Admin.Nome = (string)dr["nome"];
                        Admin.LoginID = (int)dr["loginid"];
                    }
                }
            }

            return Admin;
        }

        public void update(int Adminid, Models.Admin Admin)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update Admin set nome = @nome, where loginid=@loginid;";

                    command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = Admin.Nome;
                    command.Parameters.Add(new SqlParameter("@loginid", System.Data.SqlDbType.Date)).Value = Admin.LoginID;
                    command.Parameters.Add(new SqlParameter("@Adminid", System.Data.SqlDbType.Int)).Value = Adminid;

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
