using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class NguoiDungDAL : DBConnect
    {
        public static List<NguoiDung> LayTatCa()
        {
            List<NguoiDung> list = new List<NguoiDung>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM NguoiDung", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NguoiDung
                        {
                            MaNguoiDung = reader["MaNguoiDung"].ToString(),
                            TenDangNhap = reader["TenDangNhap"].ToString(),
                            MatKhau = reader["MatKhau"].ToString(),
                            VaiTro = reader["VaiTro"].ToString(),
                            NgayTao = Convert.ToDateTime(reader["NgayTao"])
                        });
                    }
                }
            }
            return list;
        }

        public static NguoiDung TimKiemTheoTenDangNhap(string tenDangNhap)
        {
            if (string.IsNullOrEmpty(tenDangNhap))
                throw new ArgumentException("Tên đăng nhập không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM NguoiDung WHERE TenDangNhap = @TenDangNhap", conn);
                cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new NguoiDung
                        {
                            MaNguoiDung = reader["MaNguoiDung"].ToString(),
                            TenDangNhap = reader["TenDangNhap"].ToString(),
                            MatKhau = reader["MatKhau"].ToString(),
                            VaiTro = reader["VaiTro"].ToString(),
                            NgayTao = Convert.ToDateTime(reader["NgayTao"])
                        };
                    }
                    return null;
                }
            }
        }

        public static void Them(NguoiDung obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrEmpty(obj.MaNguoiDung))
                throw new ArgumentException("Mã người dùng không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO NguoiDung (MaNguoiDung, TenDangNhap, MatKhau, VaiTro, NgayTao) VALUES (@MaNguoiDung, @TenDangNhap, @MatKhau, @VaiTro, @NgayTao)",
                    conn);
                cmd.Parameters.AddWithValue("@MaNguoiDung", obj.MaNguoiDung);
                cmd.Parameters.AddWithValue("@TenDangNhap", obj.TenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", obj.MatKhau);
                cmd.Parameters.AddWithValue("@VaiTro", obj.VaiTro);
                cmd.Parameters.AddWithValue("@NgayTao", obj.NgayTao);
                cmd.ExecuteNonQuery();
            }
        }

        public static void CapNhat(NguoiDung obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrEmpty(obj.MaNguoiDung))
                throw new ArgumentException("Mã người dùng không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE NguoiDung SET TenDangNhap = @TenDangNhap, MatKhau = @MatKhau, VaiTro = @VaiTro, NgayTao = @NgayTao WHERE MaNguoiDung = @MaNguoiDung",
                    conn);
                cmd.Parameters.AddWithValue("@MaNguoiDung", obj.MaNguoiDung);
                cmd.Parameters.AddWithValue("@TenDangNhap", obj.TenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", obj.MatKhau);
                cmd.Parameters.AddWithValue("@VaiTro", obj.VaiTro);
                cmd.Parameters.AddWithValue("@NgayTao", obj.NgayTao);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Xoa(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Mã người dùng không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM NguoiDung WHERE MaNguoiDung = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}