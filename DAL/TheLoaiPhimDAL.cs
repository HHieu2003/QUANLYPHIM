using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class TheLoaiPhimDAL : DBConnect
    {
        public static List<TheLoaiPhim> LayTatCa()
        {
            List<TheLoaiPhim> list = new List<TheLoaiPhim>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TheLoaiPhim", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new TheLoaiPhim
                {
                    MaTheLoai = reader["MaTheLoai"].ToString(),
                    TenTheLoai = reader["TenTheLoai"].ToString()
                });
            }
            conn.Close();
            return list;
        }

        public static void Them(TheLoaiPhim obj)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TheLoaiPhim (MaTheLoai, TenTheLoai) VALUES (@MaTheLoai, @TenTheLoai)", conn);
            cmd.Parameters.AddWithValue("@MaTheLoai", obj.MaTheLoai);
            cmd.Parameters.AddWithValue("@TenTheLoai", obj.TenTheLoai);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void CapNhat(TheLoaiPhim obj)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE TheLoaiPhim SET TenTheLoai=@TenTheLoai WHERE MaTheLoai=@MaTheLoai", conn);
            cmd.Parameters.AddWithValue("@MaTheLoai", obj.MaTheLoai);
            cmd.Parameters.AddWithValue("@TenTheLoai", obj.TenTheLoai);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void Xoa(string id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM TheLoaiPhim WHERE MaTheLoai = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
