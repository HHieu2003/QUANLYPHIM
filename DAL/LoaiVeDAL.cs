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
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM LoaiVe", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new LoaiVe
                    {
                        MaLoaiVe = reader["MaLoaiVe"].ToString(),
                        TenLoaiVe = reader["TenLoaiVe"].ToString(),
                        PhuThu = (decimal)reader["PhuThu"]
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách loại vé: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }
    }
}