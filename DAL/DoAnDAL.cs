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
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM DoAn", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new DoAn
                {
                    MaDoAn = reader["MaDoAn"].ToString(),
                    TenDoAn = reader["TenDoAn"].ToString(),
                    Gia = (decimal)reader["Gia"],
                    MoTa = reader["MoTa"].ToString()
                });
            }
            conn.Close();
            return list;
        }

        public static void Them(DoAn obj)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO DoAn (MaDoAn, TenDoAn, Gia, MoTa) VALUES (@MaDoAn, @TenDoAn, @Gia, @MoTa)", conn);
            cmd.Parameters.AddWithValue("@MaDoAn", obj.MaDoAn);
            cmd.Parameters.AddWithValue("@TenDoAn", obj.TenDoAn);
            cmd.Parameters.AddWithValue("@Gia", obj.Gia);
            cmd.Parameters.AddWithValue("@MoTa", obj.MoTa);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void Xoa(string id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM DoAn WHERE MaDoAn = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
