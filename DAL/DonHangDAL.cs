using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DonHangDAL : DBConnect
    {
        public static List<DonHang> LayTatCa()
        {
            List<DonHang> list = new List<DonHang>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM DonHang", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new DonHang
                {
                    MaDonHang = reader["MaDonHang"].ToString(),
                    MaKhachHang = reader["MaKhachHang"].ToString(),
                    NgayTao = (DateTime)reader["NgayTao"],
                    TongTien = (decimal)reader["TongTien"]
                });
            }
            conn.Close();
            return list;
        }

        public static void Them(DonHang obj)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO DonHang (MaDonHang, MaKhachHang, NgayTao, TongTien) VALUES (@MaDonHang, @MaKhachHang, @NgayTao, @TongTien)", conn);
            cmd.Parameters.AddWithValue("@MaDonHang", obj.MaDonHang);
            cmd.Parameters.AddWithValue("@MaKhachHang", obj.MaKhachHang);
            cmd.Parameters.AddWithValue("@NgayTao", obj.NgayTao);
            cmd.Parameters.AddWithValue("@TongTien", obj.TongTien);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void Xoa(string id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM DonHang WHERE MaDonHang = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
