using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class LichChieuDAL : DBConnect
    {
        public static List<LichChieu> LayTatCa()
        {
            List<LichChieu> list = new List<LichChieu>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM LichChieu", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new LichChieu
                {
                    MaLichChieu = reader["MaLichChieu"].ToString(),
                    MaPhim = reader["MaPhim"].ToString(),
                    MaPhong = reader["MaPhong"].ToString(),
                    GioBatDau = (DateTime)reader["GioBatDau"],
                    GiaVe = (decimal)reader["GiaVe"]
                });
            }
            conn.Close();
            return list;
        }

        public static void Them(LichChieu obj)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO LichChieu (MaLichChieu, MaPhim, MaPhong, GioBatDau, GiaVe) VALUES (@MaLichChieu, @MaPhim, @MaPhong, @GioBatDau, @GiaVe)", conn);
            cmd.Parameters.AddWithValue("@MaLichChieu", obj.MaLichChieu);
            cmd.Parameters.AddWithValue("@MaPhim", obj.MaPhim);
            cmd.Parameters.AddWithValue("@MaPhong", obj.MaPhong);
            cmd.Parameters.AddWithValue("@GioBatDau", obj.GioBatDau);
            cmd.Parameters.AddWithValue("@GiaVe", obj.GiaVe);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void CapNhat(LichChieu obj)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE LichChieu SET MaPhim=@MaPhim, MaPhong=@MaPhong, GioBatDau=@GioBatDau, GiaVe=@GiaVe WHERE MaLichChieu=@MaLichChieu", conn);
            cmd.Parameters.AddWithValue("@MaLichChieu", obj.MaLichChieu);
            cmd.Parameters.AddWithValue("@MaPhim", obj.MaPhim);
            cmd.Parameters.AddWithValue("@MaPhong", obj.MaPhong);
            cmd.Parameters.AddWithValue("@GioBatDau", obj.GioBatDau);
            cmd.Parameters.AddWithValue("@GiaVe", obj.GiaVe);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void Xoa(string id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM LichChieu WHERE MaLichChieu = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
