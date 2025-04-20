using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class KhachHangDAL : DBConnect
    {
        public static List<KhachHang> LayTatCa()
        {
            List<KhachHang> list = new List<KhachHang>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM KhachHang", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new KhachHang
                    {
                        MaKhachHang = reader["MaKhachHang"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        Email = reader["Email"].ToString()
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách khách hàng: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }
    }
}