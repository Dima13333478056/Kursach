using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WPF_Distant
{
    internal class DB
    {
        MySqlConnection connect = new MySqlConnection("server=localhost;database=DB_Distant;uid=root;pwd=admin1234;charset=utf8;");
        public void openConnection()
        {
            connect.Open();
        }
        public void closeConnection()
        {
            connect.Close();
        }
        public MySqlConnection getConnection()
        {
            return connect;
        }
    }
}
