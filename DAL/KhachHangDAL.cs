using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class KhachHangDAL : DBConnect
    {
        public List<KhachHang> LayTatCa()
        {
            List<KhachHang> list = new List<KhachHang>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM KhachHang", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new KhachHang
                        {
                            MaKhachHang = reader["MaKhachHang"].ToString(),
                            HoTen = reader["HoTen"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            Email = reader["Email"]?.ToString()
                        });
                    }
                }
            }
            return list;
        }

        public KhachHang LayTheoMa(string maKhachHang)
        {
            if (string.IsNullOrEmpty(maKhachHang))
                throw new ArgumentException("Mã khách hàng không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM KhachHang WHERE MaKhachHang = @MaKhachHang", conn);
                cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new KhachHang
                        {
                            MaKhachHang = reader["MaKhachHang"].ToString(),
                            HoTen = reader["HoTen"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            Email = reader["Email"]?.ToString()
                        };
                    }
                    return null;
                }
            }
        }

        public KhachHang TimKiemTheoSoDienThoai(string soDienThoai)
        {
            if (string.IsNullOrEmpty(soDienThoai))
                throw new ArgumentException("Số điện thoại không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM KhachHang WHERE SoDienThoai = @SoDienThoai", conn);
                cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new KhachHang
                        {
                            MaKhachHang = reader["MaKhachHang"].ToString(),
                            HoTen = reader["HoTen"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            Email = reader["Email"]?.ToString()
                        };
                    }
                    return null;
                }
            }
        }

        public void Them(KhachHang khachHang)
        {
            if (khachHang == null)
                throw new ArgumentNullException(nameof(khachHang));
            if (string.IsNullOrEmpty(khachHang.MaKhachHang))
                throw new ArgumentException("Mã khách hàng không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO KhachHang (MaKhachHang, HoTen, SoDienThoai, Email) VALUES (@MaKhachHang, @HoTen, @SoDienThoai, @Email)",
                    conn);
                cmd.Parameters.AddWithValue("@MaKhachHang", khachHang.MaKhachHang);
                cmd.Parameters.AddWithValue("@HoTen", khachHang.HoTen);
                cmd.Parameters.AddWithValue("@SoDienThoai", khachHang.SoDienThoai);
                cmd.Parameters.AddWithValue("@Email", (object)khachHang.Email ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public void CapNhat(KhachHang khachHang)
        {
            if (khachHang == null)
                throw new ArgumentNullException(nameof(khachHang));
            if (string.IsNullOrEmpty(khachHang.MaKhachHang))
                throw new ArgumentException("Mã khách hàng không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE KhachHang SET HoTen = @HoTen, SoDienThoai = @SoDienThoai, Email = @Email WHERE MaKhachHang = @MaKhachHang",
                    conn);
                cmd.Parameters.AddWithValue("@MaKhachHang", khachHang.MaKhachHang);
                cmd.Parameters.AddWithValue("@HoTen", khachHang.HoTen);
                cmd.Parameters.AddWithValue("@SoDienThoai", khachHang.SoDienThoai);
                cmd.Parameters.AddWithValue("@Email", (object)khachHang.Email ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public void Xoa(string maKhachHang)
        {
            if (string.IsNullOrEmpty(maKhachHang))
                throw new ArgumentException("Mã khách hàng không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM KhachHang WHERE MaKhachHang = @MaKhachHang", conn);
                cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                cmd.ExecuteNonQuery();
            }
        }
    }
}