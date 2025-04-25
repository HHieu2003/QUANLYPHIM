using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class ChiTietDoAnDAL : DBConnect
    {
        public static List<ChiTietDoAn> LayTheoDon(string maDon)
        {
            if (string.IsNullOrEmpty(maDon))
                throw new ArgumentException("Mã đơn hàng không được để trống!");

            List<ChiTietDoAn> list = new List<ChiTietDoAn>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ChiTietDoAn WHERE MaDonHang = @ma", conn);
                cmd.Parameters.AddWithValue("@ma", maDon);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ChiTietDoAn
                        {
                            MaChiTiet = reader["MaChiTiet"].ToString(),
                            MaDonHang = reader["MaDonHang"].ToString(),
                            MaDoAn = reader["MaDoAn"].ToString(),
                            SoLuong = Convert.ToInt32(reader["SoLuong"]),
                            Gia = Convert.ToDecimal(reader["Gia"]),
                            ThanhTien = Convert.ToDecimal(reader["ThanhTien"])
                        });
                    }
                }
            }
            return list;
        }

        public static void Them(ChiTietDoAn obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrEmpty(obj.MaChiTiet))
                throw new ArgumentException("Mã chi tiết không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO ChiTietDoAn (MaChiTiet, MaDonHang, MaDoAn, SoLuong, Gia, ThanhTien) VALUES (@MaChiTiet, @MaDonHang, @MaDoAn, @SoLuong, @Gia, @ThanhTien)",
                    conn);
                cmd.Parameters.AddWithValue("@MaChiTiet", obj.MaChiTiet);
                cmd.Parameters.AddWithValue("@MaDonHang", obj.MaDonHang);
                cmd.Parameters.AddWithValue("@MaDoAn", obj.MaDoAn);
                cmd.Parameters.AddWithValue("@SoLuong", obj.SoLuong);
                cmd.Parameters.AddWithValue("@Gia", obj.Gia);
                cmd.Parameters.AddWithValue("@ThanhTien", obj.ThanhTien);
                cmd.ExecuteNonQuery();
            }
        }

        public static void CapNhat(ChiTietDoAn obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrEmpty(obj.MaChiTiet))
                throw new ArgumentException("Mã chi tiết không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE ChiTietDoAn SET MaDonHang = @MaDonHang, MaDoAn = @MaDoAn, SoLuong = @SoLuong, Gia = @Gia, ThanhTien = @ThanhTien WHERE MaChiTiet = @MaChiTiet",
                    conn);
                cmd.Parameters.AddWithValue("@MaChiTiet", obj.MaChiTiet);
                cmd.Parameters.AddWithValue("@MaDonHang", obj.MaDonHang);
                cmd.Parameters.AddWithValue("@MaDoAn", obj.MaDoAn);
                cmd.Parameters.AddWithValue("@SoLuong", obj.SoLuong);
                cmd.Parameters.AddWithValue("@Gia", obj.Gia);
                cmd.Parameters.AddWithValue("@ThanhTien", obj.ThanhTien);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Xoa(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Mã chi tiết không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM ChiTietDoAn WHERE MaChiTiet = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}