using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DoAnDAL : DBConnect
    {
        public static List<DoAn> LayTatCa()
        {
            List<DoAn> list = new List<DoAn>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM DoAn", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new DoAn
                        {
                            MaDoAn = reader["MaDoAn"].ToString(),
                            TenDoAn = reader["TenDoAn"].ToString(),
                            Gia = Convert.ToDecimal(reader["Gia"]),
                            MoTa = reader["MoTa"]?.ToString()
                        });
                    }
                }
            }
            return list;
        }

        public static void Them(DoAn obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrEmpty(obj.MaDoAn))
                throw new ArgumentException("Mã đồ ăn không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO DoAn (MaDoAn, TenDoAn, Gia, MoTa) VALUES (@MaDoAn, @TenDoAn, @Gia, @MoTa)",
                    conn);
                cmd.Parameters.AddWithValue("@MaDoAn", obj.MaDoAn);
                cmd.Parameters.AddWithValue("@TenDoAn", obj.TenDoAn);
                cmd.Parameters.AddWithValue("@Gia", obj.Gia);
                cmd.Parameters.AddWithValue("@MoTa", (object)obj.MoTa ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public static void CapNhat(DoAn obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrEmpty(obj.MaDoAn))
                throw new ArgumentException("Mã đồ ăn không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE DoAn SET TenDoAn = @TenDoAn, Gia = @Gia, MoTa = @MoTa WHERE MaDoAn = @MaDoAn",
                    conn);
                cmd.Parameters.AddWithValue("@MaDoAn", obj.MaDoAn);
                cmd.Parameters.AddWithValue("@TenDoAn", obj.TenDoAn);
                cmd.Parameters.AddWithValue("@Gia", obj.Gia);
                cmd.Parameters.AddWithValue("@MoTa", (object)obj.MoTa ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Xoa(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Mã đồ ăn không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM DoAn WHERE MaDoAn = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
        public static DoAn LayTheoMa(string maDoAn)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM DoAn WHERE MaDoAn = @MaDoAn", conn);
                cmd.Parameters.AddWithValue("@MaDoAn", maDoAn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    DoAn doAn = new DoAn
                    {
                        MaDoAn = reader["MaDoAn"].ToString(),
                        TenDoAn = reader["TenDoAn"] != DBNull.Value ? reader["TenDoAn"].ToString() : null,
                        Gia = Convert.ToDecimal(reader["Gia"]),
                        MoTa = reader["MoTa"] != DBNull.Value ? reader["MoTa"].ToString() : null
                    };
                    return doAn;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy đồ ăn '{maDoAn}': {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}