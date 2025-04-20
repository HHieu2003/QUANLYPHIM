using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class VeDAL : DBConnect
    {
        public static List<Ve> LayTatCa()
        {
            List<Ve> list = new List<Ve>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Ve", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Ve
                    {
                        MaVe = reader["MaVe"].ToString(),
                        MaLichChieu = reader["MaLichChieu"].ToString(),
                        MaLoaiVe = reader["MaLoaiVe"].ToString(),
                        MaKhachHang = reader["MaKhachHang"].ToString(),
                        SoGhe = reader["SoGhe"].ToString(),
                        NgayDat = reader["NgayDat"] != DBNull.Value
                            ? Convert.ToDateTime(reader["NgayDat"])
                            : default(DateTime)
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách vé: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

        public static void Them(Ve obj)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Ve (MaVe, MaLichChieu, MaLoaiVe, MaKhachHang, SoGhe, NgayDat) VALUES (@MaVe, @MaLichChieu, @MaLoaiVe, @MaKhachHang, @SoGhe, @NgayDat)", conn);
                cmd.Parameters.AddWithValue("@MaVe", obj.MaVe);
                cmd.Parameters.AddWithValue("@MaLichChieu", obj.MaLichChieu);
                cmd.Parameters.AddWithValue("@MaLoaiVe", obj.MaLoaiVe);
                cmd.Parameters.AddWithValue("@MaKhachHang", obj.MaKhachHang);
                cmd.Parameters.AddWithValue("@SoGhe", obj.SoGhe);
                cmd.Parameters.AddWithValue("@NgayDat", obj.NgayDat == default(DateTime)
                    ? (object)DBNull.Value
                    : obj.NgayDat);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm vé: " + ex.Message);
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
                SqlCommand cmd = new SqlCommand("DELETE FROM Ve WHERE MaVe = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa vé: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<Ve> LayTheoLichChieu(string maLichChieu)
        {
            List<Ve> list = new List<Ve>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Ve WHERE MaLichChieu = @MaLichChieu", conn);
                cmd.Parameters.AddWithValue("@MaLichChieu", maLichChieu);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Ve
                    {
                        MaVe = reader["MaVe"].ToString(),
                        MaLichChieu = reader["MaLichChieu"].ToString(),
                        MaLoaiVe = reader["MaLoaiVe"].ToString(),
                        MaKhachHang = reader["MaKhachHang"].ToString(),
                        SoGhe = reader["SoGhe"].ToString(),
                        NgayDat = reader["NgayDat"] != DBNull.Value
                            ? Convert.ToDateTime(reader["NgayDat"])
                            : default(DateTime)
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách vé theo lịch chiếu: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }
    }
}