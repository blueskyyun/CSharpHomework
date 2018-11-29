using System;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace program1
{
    class AdoDataset
    {
        //static void Main(string[] args)
        //{
            
        //    QueryOrders();
        //    LINQInDataSet();
        //    EditInDataSet();
        //    AddRowInDataSet();
        //}
        private static void LINQInDataSet()
        {
            using (MySqlConnection conn = GetConnection())
            {
                String sql = "SELECT * FROM Orders";
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, conn))
                {
                    using (DataSet ds = new DataSet())
                    {
                        dataAdapter.Fill(ds);
                        DataRow[] rows = ds.Tables[0].Select("o_id = 1");
                        for (int i = 0; i < rows.Length; i++)
                        {
                            Console.WriteLine($"{rows[i][0]},{rows[i][1]},{rows[i][2]},{rows[i][3]}");
                        }
                    }
                }
            }
        }

        private static void EditInDataSet()
        {
            using (MySqlConnection conn = GetConnection())
            {
                String sql = "SELECT * FROM Orders";
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, conn))
                {
                    MySqlCommandBuilder cmdBuilder =
                      new MySqlCommandBuilder(dataAdapter);
                    using (DataSet ds = new DataSet())
                    {
                        dataAdapter.Fill(ds);
                        DataRow[] rows = ds.Tables[0].Select("o_cus = 1");
                        for (int i = 0; i < rows.Length; i++)
                        {
                            rows[i].BeginEdit();
                            rows[i][1] = 3;
                            rows[i].EndEdit();
                        }
                        dataAdapter.Update(ds);
                    }
                }
            }
        }

        private static void AddRowInDataSet()
        {
            using (MySqlConnection conn = GetConnection())
            {
                String sql = "SELECT * FROM Orders";
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, conn))
                {
                    MySqlCommandBuilder cmdBuilder = new MySqlCommandBuilder(dataAdapter);
                    using (DataSet ds = new DataSet())
                    {
                        dataAdapter.Fill(ds);
                        DataRow newRow = ds.Tables[0].NewRow();
                        newRow[0] = 2;
                        newRow[1] = 1;
                        newRow[2] = 187.9;
                        newRow[3] = DateTime.Now.ToString();
                        ds.Tables[0].Rows.Add(newRow);
                        dataAdapter.Update(ds);
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

        private static void QueryOrders()
        {
            using (MySqlConnection conn = GetConnection())
            {
                String sql = "SELECT * FROM Orders";
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, conn))
                {
                    using (DataSet ds = new DataSet())
                    {
                        dataAdapter.Fill(ds);
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            foreach (object field in row.ItemArray)
                            {
                                Console.Write(field + "\t");
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
            //Console.WriteLine(ds.Tables[0].Rows[0][1]);
        }
    }
}
