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
                        PhuThu = Convert.ToDecimal(reader["PhuThu"])
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

        public static LoaiVe LayTheoMa(string maLoaiVe)
        {
            LoaiVe loaiVe = null;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM LoaiVe WHERE MaLoaiVe = @MaLoaiVe", conn);
                cmd.Parameters.AddWithValue("@MaLoaiVe", maLoaiVe);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    loaiVe = new LoaiVe
                    {
                        MaLoaiVe = reader["MaLoaiVe"].ToString(),
                        TenLoaiVe = reader["TenLoaiVe"].ToString(),
                        PhuThu = Convert.ToDecimal(reader["PhuThu"])
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin loại vé: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return loaiVe;
        }

        public static void Them(LoaiVe obj)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO LoaiVe (MaLoaiVe, TenLoaiVe, PhuThu) VALUES (@MaLoaiVe, @TenLoaiVe, @PhuThu)", conn);
                cmd.Parameters.AddWithValue("@MaLoaiVe", obj.MaLoaiVe);
                cmd.Parameters.AddWithValue("@TenLoaiVe", obj.TenLoaiVe);
                cmd.Parameters.AddWithValue("@PhuThu", obj.PhuThu);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm loại vé: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void Xoa(string id)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM LoaiVe WHERE MaLoaiVe = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa loại vé: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void Sua(LoaiVe obj)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE LoaiVe SET TenLoaiVe = @TenLoaiVe, PhuThu = @PhuThu WHERE MaLoaiVe = @MaLoaiVe", conn);
                cmd.Parameters.AddWithValue("@MaLoaiVe", obj.MaLoaiVe);
                cmd.Parameters.AddWithValue("@TenLoaiVe", obj.TenLoaiVe);
                cmd.Parameters.AddWithValue("@PhuThu", obj.PhuThu);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi sửa loại vé: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}