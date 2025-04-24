using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBConnect
    {
        // Kết nối trực tiếp không cần App.config
        protected static SqlConnection conn = new SqlConnection(
            "Data Source=DESKTOP-DLUDP9Q;Initial Catalog=QuanLyPhim;Integrated Security=True"
        );

        protected static SqlConnection GetConnection()
        {
            string connString =  connString = "Data Source=DESKTOP-DLUDP9Q;Initial Catalog=QuanLyPhim;Integrated Security=True";
            
            return new SqlConnection(connString);
        }
    }
}
