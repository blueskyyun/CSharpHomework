using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace program1
{
    class AdoProvider
    {
        
       
            //static void Main(string[] args)
            //{
              
            //    Console.WriteLine("InsertCustomer:");
            //    InsertCustomer();
            //    QueryCustomers();

            //    Console.WriteLine("DeleteCustomer:");
            //    DeleteCustomer();
            //    QueryCustomers();

            //    Console.WriteLine("QueryOrdersAndCustomer:");
            //    QueryOrdersAndCustomer();
            //}

            private static void InsertCustomer()
            {
                using (MySqlConnection connection = GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand
                    ("INSERT INTO customer(c_name) VALUES(@Name)", connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Name", "bob");
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            private static void DeleteCustomer()
            {
                using (MySqlConnection connection = GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand
                    ("delete from customer where c_name = 'bob'", connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            private static void QueryCustomers()
            {
                using (MySqlConnection connection = GetConnection())
                {
                    string stm = "SELECT * FROM customer";
                    using (MySqlCommand cmd = new MySqlCommand(stm, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(reader.GetInt32(0) + ": "
                                    + reader.GetString(1));
                            }
                        }
                    }
                }
            }

            private static void QueryOrdersAndCustomer()
            {
                using (MySqlConnection connection = GetConnection())
                {
                    string stm = @"SELECT o_id,c_name From customer,
                orders WHERE customer.c_id=orders.o_cus";
                    using (MySqlCommand cmd = new MySqlCommand(stm, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(reader.GetString(0) + "\t" +
                                 reader.GetString(1));
                            }
                        }
                    }
                }
            }


            private static MySqlConnection GetConnection()
            {
                MySqlConnection connection = new MySqlConnection(
                    "datasource=localhost;username=root;" +
                    "password=mysecondmysql;database=ordersystem;charset=utf8");
                connection.Open();
                return connection;
            }
        }

   

}
