using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class KhachHangDAL : DBConnect
    {
        public List<KhachHang> LayTatCa()
        {
            List<KhachHang> list = new List<KhachHang>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM KhachHang", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new KhachHang
                    {
                        MaKhachHang = reader["MaKhachHang"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        Email = reader["Email"].ToString()
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách khách hàng: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

        public KhachHang LayTheoMa(string maKhachHang)
        {
            KhachHang khachHang = null;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM KhachHang WHERE MaKhachHang = @MaKhachHang", conn);
                cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    khachHang = new KhachHang
                    {
                        MaKhachHang = reader["MaKhachHang"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        Email = reader["Email"].ToString()
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin khách hàng: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return khachHang;
        }

        public KhachHang TimKiemTheoSoDienThoai(string soDienThoai)
        {
            KhachHang khachHang = null;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM KhachHang WHERE SoDienThoai = @SoDienThoai", conn);
                cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    khachHang = new KhachHang
                    {
                        MaKhachHang = reader["MaKhachHang"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        Email = reader["Email"].ToString()
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm khách hàng theo số điện thoại: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return khachHang;
        }

        public void Them(KhachHang khachHang)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO KhachHang (MaKhachHang, HoTen, SoDienThoai, Email) VALUES (@MaKhachHang, @HoTen, @SoDienThoai, @Email)",
                    conn
                );
                cmd.Parameters.AddWithValue("@MaKhachHang", khachHang.MaKhachHang);
                cmd.Parameters.AddWithValue("@HoTen", khachHang.HoTen);
                cmd.Parameters.AddWithValue("@SoDienThoai", khachHang.SoDienThoai);
                cmd.Parameters.AddWithValue("@Email", (object)khachHang.Email ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm khách hàng: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void CapNhat(KhachHang khachHang)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE KhachHang SET HoTen = @HoTen, SoDienThoai = @SoDienThoai, Email = @Email WHERE MaKhachHang = @MaKhachHang",
                    conn
                );
                cmd.Parameters.AddWithValue("@MaKhachHang", khachHang.MaKhachHang);
                cmd.Parameters.AddWithValue("@HoTen", khachHang.HoTen);
                cmd.Parameters.AddWithValue("@SoDienThoai", khachHang.SoDienThoai);
                cmd.Parameters.AddWithValue("@Email", (object)khachHang.Email ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật khách hàng: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void Xoa(string maKhachHang)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM KhachHang WHERE MaKhachHang = @MaKhachHang", conn);
                cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa khách hàng: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}