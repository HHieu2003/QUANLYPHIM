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
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Ve", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
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
                                : default(DateTime),
                            MaGiaoDich = reader["MaGiaoDich"] != DBNull.Value ? reader["MaGiaoDich"].ToString() : null

                        });
                    }
                }
            }
            return list;
        }

        public static void Them(Ve ve)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Ve (MaVe, MaLichChieu, MaLoaiVe, MaKhachHang, SoGhe, NgayDat, MaGiaoDich) " +
                    "VALUES (@MaVe, @MaLichChieu, @MaLoaiVe, @MaKhachHang, @SoGhe, @NgayDat, @MaGiaoDich)", conn);
                cmd.Parameters.AddWithValue("@MaVe", ve.MaVe);
                cmd.Parameters.AddWithValue("@MaLichChieu", ve.MaLichChieu);
                cmd.Parameters.AddWithValue("@MaLoaiVe", ve.MaLoaiVe);
                cmd.Parameters.AddWithValue("@MaKhachHang", ve.MaKhachHang);
                cmd.Parameters.AddWithValue("@SoGhe", ve.SoGhe);
                cmd.Parameters.AddWithValue("@NgayDat", ve.NgayDat);
                cmd.Parameters.AddWithValue("@MaGiaoDich", (object)ve.MaGiaoDich ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm vé '{ve.MaVe}': {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }



        public static List<Ve> LayTheoGiaoDich(string maGiaoDich)
        {
            List<Ve> veList = new List<Ve>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Ve WHERE MaGiaoDich = @MaGiaoDich", conn);
                cmd.Parameters.AddWithValue("@MaGiaoDich", maGiaoDich);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Ve ve = new Ve
                    {
                        MaVe = reader["MaVe"].ToString(),
                        MaLichChieu = reader["MaLichChieu"].ToString(),
                        MaLoaiVe = reader["MaLoaiVe"].ToString(),
                        MaKhachHang = reader["MaKhachHang"].ToString(),
                        SoGhe = reader["SoGhe"].ToString(),
                        NgayDat = Convert.ToDateTime(reader["NgayDat"]),
                        MaGiaoDich = reader["MaGiaoDich"] != DBNull.Value ? reader["MaGiaoDich"].ToString() : null
                    };
                    veList.Add(ve);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách vé '{maGiaoDich}': {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
            return veList;
        }

        public static void Xoa(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Mã vé không được để trống!");

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Ve WHERE MaVe = @id", conn);
                cmd.Parameters.AddWithValue("@id", Guid.Parse(id));
                cmd.ExecuteNonQuery();
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
                            : default(DateTime),
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