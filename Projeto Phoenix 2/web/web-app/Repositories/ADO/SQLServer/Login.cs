﻿using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Data;
using web_app.Models;

namespace web_app.Repositories.ADO.SQLServer
{
    public class Login
    {
        private readonly string connectionString;
        public Login(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void Add(Models.Login login)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into login (username, password, tipologinid) values (@user,@senha,@tipologin); select convert(int,@@identity) as loginid;;";

                    command.Parameters.Add("@user", SqlDbType.VarChar).Value = login.Username;
                    command.Parameters.Add("@senha", SqlDbType.VarChar).Value = login.Password;
                    command.Parameters.Add("@tipologin", SqlDbType.Int).Value = login.TipoLogin;

                    login.LoginId = (int)command.ExecuteScalar();
                }
            }
        }
        public List<Models.Login> get()
        {
            List<Models.Login> logins = new List<Models.Login>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select loginid, username, password, tipologinid from login;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Models.Login login1 = new Models.Login();
                        login1.LoginId = (int)dr["loginid"];
                        login1.Username = (string)dr["username"];
                        login1.Password= (string)dr["password"];
                        login1.TipoLogin = (int)dr["tipologinid"];
                        logins.Add(login1);
                    }
                }
            }

            return logins;
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
