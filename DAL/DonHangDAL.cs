using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DonHangDAL : DBConnect
    {
        public static List<DonHang> LayTatCa()
        {
            List<DonHang> list = new List<DonHang>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM DonHang", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new DonHang
                        {
                            MaDonHang = reader["MaDonHang"].ToString(),
                            MaKhachHang = reader["MaKhachHang"]?.ToString(),
                            NgayTao = Convert.ToDateTime(reader["NgayTao"]),
                            TongTien = Convert.ToDecimal(reader["TongTien"])
                        });
                    }
                }
            }
            return list;
        }
        public static bool KiemTraTonTai(string maKhachHang)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM KhachHang WHERE MaKhachHang = @MaKhachHang", conn);
                cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi kiểm tra khách hàng '{maKhachHang}': {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
        public static DonHang LayTheoMa(string maDonHang)
        {
            if (string.IsNullOrEmpty(maDonHang))
                throw new ArgumentException("Mã đơn hàng không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM DonHang WHERE MaDonHang = @MaDonHang", conn);
                cmd.Parameters.AddWithValue("@MaDonHang", maDonHang);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new DonHang
                        {
                            MaDonHang = reader["MaDonHang"].ToString(),
                            MaKhachHang = reader["MaKhachHang"]?.ToString(),
                            NgayTao = Convert.ToDateTime(reader["NgayTao"]),
                            TongTien = Convert.ToDecimal(reader["TongTien"])
                        };
                    }
                    return null;
                }
            }
        }

        public static void Them(DonHang obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrEmpty(obj.MaDonHang))
                throw new ArgumentException("Mã đơn hàng không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO DonHang (MaDonHang, MaKhachHang, NgayTao, TongTien) VALUES (@MaDonHang, @MaKhachHang, @NgayTao, @TongTien)",
                    conn);
                cmd.Parameters.AddWithValue("@MaDonHang", obj.MaDonHang);
                cmd.Parameters.AddWithValue("@MaKhachHang", (object)obj.MaKhachHang ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NgayTao", obj.NgayTao);
                cmd.Parameters.AddWithValue("@TongTien", obj.TongTien);
                cmd.ExecuteNonQuery();
            }
        }

        public static void CapNhat(DonHang obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrEmpty(obj.MaDonHang))
                throw new ArgumentException("Mã đơn hàng không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE DonHang SET MaKhachHang = @MaKhachHang, NgayTao = @NgayTao, TongTien = @TongTien WHERE MaDonHang = @MaDonHang",
                    conn);
                cmd.Parameters.AddWithValue("@MaDonHang", obj.MaDonHang);
                cmd.Parameters.AddWithValue("@MaKhachHang", (object)obj.MaKhachHang ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NgayTao", obj.NgayTao);
                cmd.Parameters.AddWithValue("@TongTien", obj.TongTien);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Xoa(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Mã đơn hàng không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM DonHang WHERE MaDonHang = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}