using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ValarAlerte.Models;


namespace ValarAlerte.Tools.Bdds.BddValalerte
{
    public class BddValalerte
    {
        private static BddValalerte _instance = null;
        private static readonly object _lock = new object();

        public static BddValalerte Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new BddValalerte();
                    }
                    return _instance;
                }
            }
        }

        internal bool verifUserExist(User user)
        {
            bool exist = false;
            IDbCommand command = new SqlCommand("SELECT * FROM Users WHERE Mail = @Mail", (SqlConnection)ConnectionValalerte.Instance);
            command.Parameters.Add(new SqlParameter("@Mail", SqlDbType.VarChar) { Value = user.MailAdress });
            ConnectionValalerte.Instance.Open();
            SqlDataReader reader = (SqlDataReader)command.ExecuteReader();
            if (reader.Read())
            {
                exist = true;
            }
            reader.Close();
            command.Dispose();
            ConnectionValalerte.Instance.Close();
            return exist;
        }

        internal User ComparePassword(string mailAdress, string hashPassword)
        {
            IDbCommand command = new SqlCommand("SELECT HashPass FROM Users WHERE Mail = @Mail", (SqlConnection)ConnectionValalerte.Instance);
            command.Parameters.Add(new SqlParameter("@Mail", SqlDbType.VarChar) { Value = mailAdress });
            ConnectionValalerte.Instance.Open();
            SqlDataReader reader = (SqlDataReader)command.ExecuteReader();
            reader.Read();
            string PassWord = (string)reader.GetValue(0);
            reader.Close();
            command.Dispose();
            ConnectionValalerte.Instance.Close();
            if (PassWord == hashPassword)
            {

                command = new SqlCommand("SELECT Id, Nom, Prenom, Mail, Role FROM Users WHERE Mail = @Mail", (SqlConnection)ConnectionValalerte.Instance);
                command.Parameters.Add(new SqlParameter("@Mail", SqlDbType.VarChar) { Value = mailAdress });
                ConnectionValalerte.Instance.Open();
                reader = (SqlDataReader)command.ExecuteReader();
                reader.Read();

                User u = new User 
                { 
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Firstname = reader.GetString(2),
                    MailAdress = reader.GetString(3),
                    Role = reader.GetString(4)
                };


                reader.Close();
                command.Dispose();
                ConnectionValalerte.Instance.Close();
                return u;
            }
            else
            {
                User u = new User { MailAdress = mailAdress };
                return u;
            }
        }
    }
}
