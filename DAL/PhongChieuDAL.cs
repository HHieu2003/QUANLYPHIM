using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class PhongChieuDAL : DBConnect
    {
        public static List<PhongChieu> LayTatCa()
        {
            List<PhongChieu> list = new List<PhongChieu>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM PhongChieu", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new PhongChieu
                    {
                        MaPhong = reader["MaPhong"].ToString(),
                        TenPhong = reader["TenPhong"].ToString(),
                        SoLuongGhe = (int)reader["SoLuongGhe"],
                        TrangThai = reader["TrangThai"].ToString()
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách phòng chiếu: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }



        public static PhongChieu LayTheoMa(string maPhong)
        {
            PhongChieu phongChieu = null;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM PhongChieu WHERE MaPhong = @MaPhong", conn);
                cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    phongChieu = new PhongChieu
                    {
                        MaPhong = reader["MaPhong"].ToString(),
                        TenPhong = reader["TenPhong"].ToString(),
                        SoLuongGhe = Convert.ToInt32(reader["SoLuongGhe"]),
                        TrangThai = reader["TrangThai"].ToString()
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin phòng chiếu: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return phongChieu;
        }
        public static void Them(PhongChieu obj)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO PhongChieu (MaPhong, TenPhong, SoLuongGhe, TrangThai) VALUES (@MaPhong, @TenPhong, @SoLuongGhe, @TrangThai)", conn);
                cmd.Parameters.AddWithValue("@MaPhong", obj.MaPhong);
                cmd.Parameters.AddWithValue("@TenPhong", obj.TenPhong);
                cmd.Parameters.AddWithValue("@SoLuongGhe", obj.SoLuongGhe);
                cmd.Parameters.AddWithValue("@TrangThai", obj.TrangThai);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm phòng chiếu: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void CapNhat(PhongChieu obj)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE PhongChieu SET TenPhong=@TenPhong, SoLuongGhe=@SoLuongGhe, TrangThai=@TrangThai WHERE MaPhong=@MaPhong", conn);
                cmd.Parameters.AddWithValue("@MaPhong", obj.MaPhong);
                cmd.Parameters.AddWithValue("@TenPhong", obj.TenPhong);
                cmd.Parameters.AddWithValue("@SoLuongGhe", obj.SoLuongGhe);
                cmd.Parameters.AddWithValue("@TrangThai", obj.TrangThai);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật phòng chiếu: " + ex.Message);
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
                SqlCommand cmd = new SqlCommand("DELETE FROM PhongChieu WHERE MaPhong = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) when (ex.Number == 547) // Lỗi khóa ngoại
            {
                throw new Exception("Không thể xóa phòng chiếu vì có lịch chiếu liên quan!");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa phòng chiếu: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}