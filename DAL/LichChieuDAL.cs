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
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM LichChieu", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new LichChieu
                        {
                            MaLichChieu = reader["MaLichChieu"].ToString(),
                            MaPhim = reader["MaPhim"].ToString(),
                            MaPhong = reader["MaPhong"].ToString(),
                            GioBatDau = Convert.ToDateTime(reader["GioBatDau"]),
                            GiaVe = Convert.ToDecimal(reader["GiaVe"])
                        });
                    }
                }
            }
            return list;
        }

        public static LichChieu LayTheoMa(string maLichChieu)
        {
            if (string.IsNullOrEmpty(maLichChieu))
                throw new ArgumentException("Mã lịch chiếu không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM LichChieu WHERE MaLichChieu = @MaLichChieu", conn);
                cmd.Parameters.AddWithValue("@MaLichChieu", maLichChieu);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new LichChieu
                        {
                            MaLichChieu = reader["MaLichChieu"].ToString(),
                            MaPhim = reader["MaPhim"].ToString(),
                            MaPhong = reader["MaPhong"].ToString(),
                            GioBatDau = Convert.ToDateTime(reader["GioBatDau"]),
                            GiaVe = Convert.ToDecimal(reader["GiaVe"])
                        };
                    }
                    return null;
                }
            }
        }

        public static void Them(LichChieu obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrEmpty(obj.MaLichChieu))
                throw new ArgumentException("Mã lịch chiếu không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO LichChieu (MaLichChieu, MaPhim, MaPhong, GioBatDau, GiaVe) VALUES (@MaLichChieu, @MaPhim, @MaPhong, @GioBatDau, @GiaVe)",
                    conn);
                cmd.Parameters.AddWithValue("@MaLichChieu", obj.MaLichChieu);
                cmd.Parameters.AddWithValue("@MaPhim", obj.MaPhim);
                cmd.Parameters.AddWithValue("@MaPhong", obj.MaPhong);
                cmd.Parameters.AddWithValue("@GioBatDau", obj.GioBatDau);
                cmd.Parameters.AddWithValue("@GiaVe", obj.GiaVe);
                cmd.ExecuteNonQuery();
            }
        }

        public static void CapNhat(LichChieu obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrEmpty(obj.MaLichChieu))
                throw new ArgumentException("Mã lịch chiếu không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE LichChieu SET MaPhim = @MaPhim, MaPhong = @MaPhong, GioBatDau = @GioBatDau, GiaVe = @GiaVe WHERE MaLichChieu = @MaLichChieu",
                    conn);
                cmd.Parameters.AddWithValue("@MaLichChieu", obj.MaLichChieu);
                cmd.Parameters.AddWithValue("@MaPhim", obj.MaPhim);
                cmd.Parameters.AddWithValue("@MaPhong", obj.MaPhong);
                cmd.Parameters.AddWithValue("@GioBatDau", obj.GioBatDau);
                cmd.Parameters.AddWithValue("@GiaVe", obj.GiaVe);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Xoa(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Mã lịch chiếu không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM LichChieu WHERE MaLichChieu = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}