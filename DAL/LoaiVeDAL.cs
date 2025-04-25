using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class LoaiVeDAL : DBConnect
    {
        public static List<LoaiVe> LayTatCa()
        {
            List<LoaiVe> list = new List<LoaiVe>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM LoaiVe", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new LoaiVe
                        {
                            MaLoaiVe = reader["MaLoaiVe"].ToString(),
                            TenLoaiVe = reader["TenLoaiVe"].ToString(),
                            PhuThu = Convert.ToDecimal(reader["PhuThu"])
                        });
                    }
                }
            }
            return list;
        }

        public static LoaiVe LayTheoMa(string maLoaiVe)
        {
            if (string.IsNullOrEmpty(maLoaiVe))
                throw new ArgumentException("Mã loại vé không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM LoaiVe WHERE MaLoaiVe = @MaLoaiVe", conn);
                cmd.Parameters.AddWithValue("@MaLoaiVe", maLoaiVe);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new LoaiVe
                        {
                            MaLoaiVe = reader["MaLoaiVe"].ToString(),
                            TenLoaiVe = reader["TenLoaiVe"].ToString(),
                            PhuThu = Convert.ToDecimal(reader["PhuThu"])
                        };
                    }
                    return null;
                }
            }
        }

        public static void Them(LoaiVe obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrEmpty(obj.MaLoaiVe))
                throw new ArgumentException("Mã loại vé không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO LoaiVe (MaLoaiVe, TenLoaiVe, PhuThu) VALUES (@MaLoaiVe, @TenLoaiVe, @PhuThu)",
                    conn);
                cmd.Parameters.AddWithValue("@MaLoaiVe", obj.MaLoaiVe);
                cmd.Parameters.AddWithValue("@TenLoaiVe", obj.TenLoaiVe);
                cmd.Parameters.AddWithValue("@PhuThu", obj.PhuThu);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Sua(LoaiVe obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrEmpty(obj.MaLoaiVe))
                throw new ArgumentException("Mã loại vé không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE LoaiVe SET TenLoaiVe = @TenLoaiVe, PhuThu = @PhuThu WHERE MaLoaiVe = @MaLoaiVe",
                    conn);
                cmd.Parameters.AddWithValue("@MaLoaiVe", obj.MaLoaiVe);
                cmd.Parameters.AddWithValue("@TenLoaiVe", obj.TenLoaiVe);
                cmd.Parameters.AddWithValue("@PhuThu", obj.PhuThu);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Xoa(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Mã loại vé không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM LoaiVe WHERE MaLoaiVe = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}