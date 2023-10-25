using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace connectSQL
{
    internal class users
    {
       public int InsertData(string connectionString)
        {
            string email,password,firstName,lastName,message;
            Console.WriteLine("Insert email address");
            email=Console.ReadLine();
            Console.WriteLine("Insert password");
            password= Console.ReadLine();
            Console.WriteLine("Insert first name");
            firstName= Console.ReadLine();
            Console.WriteLine("Insert last name");
            lastName = Console.ReadLine();
            Console.WriteLine("Insert message");
            message = Console.ReadLine();

            string query = "INSERT INTO users(Email,Password,FirstName,LastName,Message)" +
                           "VALUES(@Email,@Password,@FirstName,@LastName,@Message)";
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@Email",SqlDbType.VarChar,50).Value = email;
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = password;
                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = firstName;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = lastName;
                cmd.Parameters.Add("@Message", SqlDbType.VarChar, 50).Value = message;

                cn.Open();
                int rowAffected=cmd.ExecuteNonQuery();
                cn.Close();

                return rowAffected;
            }
        }
        internal void readData(string connectionString)
        {
            string queryString = "select * from users";
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                            reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }
    }

   
}
