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
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM NguoiDung", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new NguoiDung
                {
                    MaNguoiDung = reader["MaNguoiDung"].ToString(),
                    TenDangNhap = reader["TenDangNhap"].ToString(),
                    MatKhau = reader["MatKhau"].ToString(),
                    VaiTro = reader["VaiTro"].ToString(),
                    NgayTao = (DateTime)reader["NgayTao"]
                });
            }
            conn.Close();
            return list;
        }

        public static void Them(NguoiDung obj)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO NguoiDung (MaNguoiDung, TenDangNhap, MatKhau, VaiTro, NgayTao) VALUES (@MaNguoiDung, @TenDangNhap, @MatKhau, @VaiTro, @NgayTao)", conn);
            cmd.Parameters.AddWithValue("@MaNguoiDung", obj.MaNguoiDung);
            cmd.Parameters.AddWithValue("@TenDangNhap", obj.TenDangNhap);
            cmd.Parameters.AddWithValue("@MatKhau", obj.MatKhau);
            cmd.Parameters.AddWithValue("@VaiTro", obj.VaiTro);
            cmd.Parameters.AddWithValue("@NgayTao", obj.NgayTao);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void CapNhat(NguoiDung obj)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE NguoiDung SET TenDangNhap=@TenDangNhap, MatKhau=@MatKhau, VaiTro=@VaiTro, NgayTao=@NgayTao WHERE MaNguoiDung=@MaNguoiDung", conn);
            cmd.Parameters.AddWithValue("@MaNguoiDung", obj.MaNguoiDung);
            cmd.Parameters.AddWithValue("@TenDangNhap", obj.TenDangNhap);
            cmd.Parameters.AddWithValue("@MatKhau", obj.MatKhau);
            cmd.Parameters.AddWithValue("@VaiTro", obj.VaiTro);
            cmd.Parameters.AddWithValue("@NgayTao", obj.NgayTao);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void Xoa(string id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM NguoiDung WHERE MaNguoiDung = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
