using System.Configuration; // Cần thêm namespace này
using System.Data.SqlClient;

namespace DAL
{
    public class DBConnect
    {
        // Biến kết nối dùng chung
        protected static SqlConnection conn = new SqlConnection(GetConnectionString());

        // Phương thức lấy chuỗi kết nối từ App.config
        protected static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["QuanLyPhim"].ConnectionString;
        }

        // Tạo đối tượng SqlConnection mỗi khi cần
        protected static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }
    }
}
