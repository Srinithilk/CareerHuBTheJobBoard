using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CareerHuBTheJobBoard.Util
{
    static class DbConnUtil
    {
        static SqlConnection connection = null;
        //public static SqlConnection GetConnection(string connectionString)
        //{
        //    connection.ConnectionString = connectionString;
        //    return connection;
        //}
        //(or)
        public static SqlConnection GetConnection()
        {
            connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            // connection.ConnectionString = @"Server=LAPTOP-FBNFDUHS;Database=CareerHub;Integrated Security=True;";
            return connection;
        }
    }
}
