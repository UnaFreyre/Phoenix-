using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using web_app.Models;

namespace web_app.Repositories.ADO.SQLServer
{
    public class Estudante
    {
        private readonly string connectionString; //Declarado para toda a classe. Possível alterar somente no construtor.
        public Estudante(string connectionString) //Quem invocar o construtor do repositório deve enviar a string de conexão.
        {
            this.connectionString = connectionString; //atualização do atributo por meio do valor que veio no parâmetro do construtor..
        }

        public void add(Models.Estudante Estudante)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into Estudante (nome, loginid) values (@nome,@loginid); select convert(int,@@identity) as estudanteid;;";

                    command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = Estudante.Nome;
                    command.Parameters.Add(new SqlParameter("@loginid", System.Data.SqlDbType.Int)).Value = Estudante.LoginID;

                    Estudante.EstudanteID = (int)command.ExecuteScalar(); // o homem do saco leva os dados até o sgbd e volta com o valor do id => ExecuteScalar retorna um único valor. Observe que o CommandText foi alterado com mais uma instrução. Então, as duas instruções são executadas e temos como retorno o valor do id que foi gerado pelo sgbd na tabela Estudante. Assim, conseguimos atualizar o valor do id do objeto Estudante que antes da inserção era 0.
                }
            }
        }

        public List<Models.Estudante> get()
        {
            List<Models.Estudante> Estudantes = new List<Models.Estudante>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select estudanteid, nome, loginid from Estudante;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Models.Estudante Estudante = new Models.Estudante();
                        Estudante.EstudanteID = (int)dr["estudanteid"];
                        Estudante.Nome = (string)dr["nome"];
                        Estudante.LoginID = (int)dr["loginid"];
                        Estudantes.Add(Estudante);
                    }
                }
            }

            return Estudantes;
        }

        public void delete(int estudanteid)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "delete from Estudante where estudanteid = @estudanteid;";
                    command.Parameters.Add(new SqlParameter("@estudanteid", System.Data.SqlDbType.Int)).Value = estudanteid;

                    command.ExecuteNonQuery();
                }
            }
        }

        public Models.Estudante getById(int estudanteid) //somente 1 Estudante.
        {
            Models.Estudante Estudante = new Models.Estudante();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select estudanteid, nome,loginid from Estudante where estudanteid=@estudanteid;";
                    command.Parameters.Add(new SqlParameter("@estudanteid", System.Data.SqlDbType.Int)).Value = estudanteid;

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {
                        Estudante.EstudanteID = (int)dr["estudanteid"];
                        Estudante.Nome = (string)dr["nome"];
                        Estudante.LoginID = (int)dr["loginid"];
                    }
                }
            }

            return Estudante;
        }

        public void update(int estudanteid, Models.Estudante Estudante)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update Estudante set nome = @nome, loginid = @loginid where estudanteid=@estudanteid;";

                    command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = Estudante.Nome;
                    command.Parameters.Add(new SqlParameter("@loginid", System.Data.SqlDbType.Int)).Value = Estudante.LoginID;
                    command.Parameters.Add(new SqlParameter("@estudanteid", System.Data.SqlDbType.Int)).Value = Estudante.EstudanteID;

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
