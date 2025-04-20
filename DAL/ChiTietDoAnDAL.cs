using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class ChiTietDoAnDAL : DBConnect
    {
        public static List<ChiTietDoAn> LayTheoDon(string maDon)
        {
            List<ChiTietDoAn> list = new List<ChiTietDoAn>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ChiTietDoAn WHERE MaDonHang=@ma", conn);
            cmd.Parameters.AddWithValue("@ma", maDon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new ChiTietDoAn
                {
                    MaChiTiet = reader["MaChiTiet"].ToString(),
                    MaDonHang = reader["MaDonHang"].ToString(),
                    MaDoAn = reader["MaDoAn"].ToString(),
                    SoLuong = (int)reader["SoLuong"],
                    Gia = (decimal)reader["Gia"],
                    ThanhTien = (decimal)reader["ThanhTien"]
                });
            }
            conn.Close();
            return list;
        }

        public static void Them(ChiTietDoAn obj)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO ChiTietDoAn (MaChiTiet, MaDonHang, MaDoAn, SoLuong, Gia) VALUES (@MaChiTiet, @MaDonHang, @MaDoAn, @SoLuong, @Gia)", conn);
            cmd.Parameters.AddWithValue("@MaChiTiet", obj.MaChiTiet);
            cmd.Parameters.AddWithValue("@MaDonHang", obj.MaDonHang);
            cmd.Parameters.AddWithValue("@MaDoAn", obj.MaDoAn);
            cmd.Parameters.AddWithValue("@SoLuong", obj.SoLuong);
            cmd.Parameters.AddWithValue("@Gia", obj.Gia);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void Xoa(string id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM ChiTietDoAn WHERE MaChiTiet = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
