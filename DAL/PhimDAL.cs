using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class PhimDAL : DBConnect
    {
        public static List<Phim> LayTatCa()
        {
            List<Phim> list = new List<Phim>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Phim", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Phim
                {
                    MaPhim = reader["MaPhim"].ToString(),
                    TenPhim = reader["TenPhim"].ToString(),
                    MaTheLoai = reader["MaTheLoai"].ToString(),
                    ThoiLuong = (int)reader["ThoiLuong"],
                    MoTa = reader["MoTa"].ToString()
                });
            }
            conn.Close();
            return list;
        }

        public static void Them(Phim obj)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Phim (MaPhim, TenPhim, MaTheLoai, ThoiLuong, MoTa) VALUES (@MaPhim, @TenPhim, @MaTheLoai, @ThoiLuong, @MoTa)", conn);
            cmd.Parameters.AddWithValue("@MaPhim", obj.MaPhim);
            cmd.Parameters.AddWithValue("@TenPhim", obj.TenPhim);
            cmd.Parameters.AddWithValue("@MaTheLoai", obj.MaTheLoai);
            cmd.Parameters.AddWithValue("@ThoiLuong", obj.ThoiLuong);
            cmd.Parameters.AddWithValue("@MoTa", obj.MoTa);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void CapNhat(Phim obj)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Phim SET TenPhim=@TenPhim, MaTheLoai=@MaTheLoai, ThoiLuong=@ThoiLuong, MoTa=@MoTa WHERE MaPhim=@MaPhim", conn);
            cmd.Parameters.AddWithValue("@MaPhim", obj.MaPhim);
            cmd.Parameters.AddWithValue("@TenPhim", obj.TenPhim);
            cmd.Parameters.AddWithValue("@MaTheLoai", obj.MaTheLoai);
            cmd.Parameters.AddWithValue("@ThoiLuong", obj.ThoiLuong);
            cmd.Parameters.AddWithValue("@MoTa", obj.MoTa);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void Xoa(string id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Phim WHERE MaPhim = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }


      
    }
}
