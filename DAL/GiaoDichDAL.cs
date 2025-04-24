using System;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class GiaoDichDAL : DBConnect
    {
        public static void Them(GiaoDich giaoDich)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO GiaoDich (MaGiaoDich, MaXacNhan, MaKhachHang, MaDonHang, NgayGiaoDich, TongTien, TrangThai) " +
                    "VALUES (@MaGiaoDich, @MaXacNhan, @MaKhachHang, @MaDonHang, @NgayGiaoDich, @TongTien, @TrangThai)", conn);
                cmd.Parameters.AddWithValue("@MaGiaoDich", giaoDich.MaGiaoDich);
                cmd.Parameters.AddWithValue("@MaXacNhan", giaoDich.MaXacNhan);
                cmd.Parameters.AddWithValue("@MaKhachHang", giaoDich.MaKhachHang);
                cmd.Parameters.AddWithValue("@MaDonHang", (object)giaoDich.MaDonHang ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NgayGiaoDich", giaoDich.NgayGiaoDich);
                cmd.Parameters.AddWithValue("@TongTien", giaoDich.TongTien);
                cmd.Parameters.AddWithValue("@TrangThai", "ChuaXuLy"); // Đảm bảo cột TrangThai đã được thêm vào bảng
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm giao dịch '{giaoDich.MaGiaoDich}': {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool KiemTraTonTai(string maGiaoDich)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM GiaoDich WHERE MaGiaoDich = @MaGiaoDich", conn);
                cmd.Parameters.AddWithValue("@MaGiaoDich", maGiaoDich);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi kiểm tra giao dịch '{maGiaoDich}': {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }

        public static GiaoDich LayTheoMaXacNhan(string maXacNhan)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM GiaoDich WHERE MaXacNhan = @MaXacNhan", conn);
                cmd.Parameters.AddWithValue("@MaXacNhan", maXacNhan);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    GiaoDich giaoDich = new GiaoDich
                    {
                        MaGiaoDich = reader["MaGiaoDich"].ToString(),
                        MaXacNhan = reader["MaXacNhan"].ToString(),
                        MaKhachHang = reader["MaKhachHang"].ToString(),
                        MaDonHang = reader["MaDonHang"] != DBNull.Value ? reader["MaDonHang"].ToString() : null,
                        NgayGiaoDich = Convert.ToDateTime(reader["NgayGiaoDich"]),
                        TongTien = Convert.ToDecimal(reader["TongTien"]),
                        TrangThai = reader["TrangThai"].ToString()
                    };
                    return giaoDich;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy giao dịch '{maXacNhan}': {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }

        public static void CapNhatTrangThai(string maXacNhan, string trangThai)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE GiaoDich SET TrangThai = @TrangThai WHERE MaXacNhan = @MaXacNhan", conn);
                cmd.Parameters.AddWithValue("@MaXacNhan", maXacNhan);
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                    throw new Exception("Không tìm thấy giao dịch để cập nhật!");
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật trạng thái '{maXacNhan}': {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}