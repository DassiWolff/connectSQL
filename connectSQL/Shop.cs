using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace connectSQL
{
    internal class Shop
    {
       public int InsertData(string connectionString)
        {
            string categoryId, name, price, desc, image;
            Console.WriteLine("Insert categoryId");
            categoryId = Console.ReadLine();
            Console.WriteLine("Insert name");
            name = Console.ReadLine();
            Console.WriteLine("Insert price");
            price = Console.ReadLine();
            Console.WriteLine("Insert desc");
            desc = Console.ReadLine();
            Console.WriteLine("Insert image");
            image = Console.ReadLine();

            string query = "INSERT INTO Products(categoryId,name,price,des,img)" +
                            "VALUES(@categoryId,@name,@price,@des,@img)";
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@categoryId", SqlDbType.VarChar, 50).Value = categoryId;
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = name;
                cmd.Parameters.Add("@price", SqlDbType.VarChar, 50).Value = price;
                cmd.Parameters.Add("@des", SqlDbType.VarChar, 50).Value = desc;
                cmd.Parameters.Add("@img", SqlDbType.VarChar, 50).Value = image;

                cn.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                cn.Close();

                return rowAffected;
            }
        }
        internal void readData(string connectionString)
        {
            string queryString = "select * from Products";
            using (SqlConnection connection = new SqlConnection(connectionString))
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
