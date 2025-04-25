using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class BaoCaoDAL : DBConnect
    {
        public static List<BaoCao> LayTatCa()
        {
            List<BaoCao> list = new List<BaoCao>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BaoCao", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new BaoCao
                {
                    MaBaoCao = reader["MaBaoCao"].ToString(),
                    TieuDe = reader["TieuDe"].ToString(),
                    NoiDung = reader["NoiDung"].ToString(),
                    NgayTao = (DateTime)reader["NgayTao"],
                    NguoiTao = reader["NguoiTao"].ToString()
                });
            }
            conn.Close();
            return list;
        }

        public static void Them(BaoCao obj)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO BaoCao (MaBaoCao, TieuDe, NoiDung, NgayTao, NguoiTao) VALUES (@MaBaoCao, @TieuDe, @NoiDung, @NgayTao, @NguoiTao)", conn);
            cmd.Parameters.AddWithValue("@MaBaoCao", obj.MaBaoCao);
            cmd.Parameters.AddWithValue("@TieuDe", obj.TieuDe);
            cmd.Parameters.AddWithValue("@NoiDung", obj.NoiDung);
            cmd.Parameters.AddWithValue("@NgayTao", obj.NgayTao);
            cmd.Parameters.AddWithValue("@NguoiTao", obj.NguoiTao);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void Xoa(string id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM BaoCao WHERE MaBaoCao = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
