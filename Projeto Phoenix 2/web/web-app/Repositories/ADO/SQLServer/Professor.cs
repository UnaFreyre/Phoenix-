using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using web_app.Models;

namespace web_app.Repositories.ADO.SQLServer
{
    public class Professor
    {
        private readonly string connectionString; //Declarado para toda a classe. Possível alterar somente no construtor.
        public Professor(string connectionString) //Quem invocar o construtor do repositório deve enviar a string de conexão.
        {
            this.connectionString = connectionString; //atualização do atributo por meio do valor que veio no parâmetro do construtor..
        }

        public void add(Models.Professor Professor)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into Professor (nome, loginid) values (@nome,@loginid); select convert(int,@@identity) as professorid;;";

                    command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = Professor.Nome;
                    command.Parameters.Add(new SqlParameter("@loginid", System.Data.SqlDbType.Int)).Value = Professor.LoginID;

                    Professor.ProfessorID = (int)command.ExecuteScalar(); // o homem do saco leva os dados até o sgbd e volta com o valor do id => ExecuteScalar retorna um único valor. Observe que o CommandText foi alterado com mais uma instrução. Então, as duas instruções são executadas e temos como retorno o valor do id que foi gerado pelo sgbd na tabela Professor. Assim, conseguimos atualizar o valor do id do objeto Professor que antes da inserção era 0.
                }
            }
        }

        public List<Models.Professor> get()
        {
            List<Models.Professor> Professores = new List<Models.Professor>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select professorid, nome, loginid from Professor;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Models.Professor Professor = new Models.Professor();
                        Professor.ProfessorID = (int)dr["professorid"];
                        Professor.Nome = (string)dr["nome"];
                        Professor.LoginID = (int)dr["loginid"];
                        Professores.Add(Professor);
                    }
                }
            }

            return Professores;
        }

        public void delete(int professorid)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "delete from Professor where professorid = @professorid;";
                    command.Parameters.Add(new SqlParameter("@professorid", System.Data.SqlDbType.Int)).Value = professorid;

                    command.ExecuteNonQuery();
                }
            }
        }

        public Models.Professor getById(int professorid) //somente 1 Professor.
        {
            Models.Professor Professor = new Models.Professor();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select professorid, nome,loginid from Professor where professorid=@professorid;";
                    command.Parameters.Add(new SqlParameter("@professorid", System.Data.SqlDbType.Int)).Value = professorid;

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {
                        Professor.ProfessorID = (int)dr["professorid"];
                        Professor.Nome = (string)dr["nome"];
                        Professor.LoginID = (int)dr["loginid"];
                    }
                }
            }

            return Professor;
        }

        public void update(int professorid, Models.Professor Professor)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update Professor set nome = @nome, loginid = @loginid where professorid=@professorid;";

                    command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = Professor.Nome;
                    command.Parameters.Add(new SqlParameter("@loginid", System.Data.SqlDbType.Int)).Value = Professor.LoginID;
                    command.Parameters.Add(new SqlParameter("@professorid", System.Data.SqlDbType.Int)).Value = Professor.ProfessorID;

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
