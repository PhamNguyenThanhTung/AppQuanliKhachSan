using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BTL_QLKhachSan.myClass
{
    class Database
    {
        // !!! THAY THẾ DÒNG NÀY BẰNG CHUỖI KẾT NỐI CỦA BẠN !!!
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QLKhachSan_btl;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // Hàm dùng để thực thi các câu lệnh SELECT và trả về một DataTable
        public DataTable GetData(string sqlQuery, List<SqlParameter> parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                    {
                        // Thêm các tham số (parameters) nếu có
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters.ToArray());
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt); // Đổ dữ liệu vào DataTable
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (ví dụ: ghi log, hiển thị thông báo)
                Console.WriteLine("Lỗi khi truy vấn CSDL: " + ex.Message);
            }
            return dt;
        }
        public void ExecuteNonQuery(string sqlQuery, List<SqlParameter> parameters = null)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                    {
                        // Thêm các tham số (parameters) nếu có
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters.ToArray());
                        }

                        cmd.ExecuteNonQuery(); // Thực thi lệnh
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (ví dụ: ghi log, hiển thị thông báo)
                Console.WriteLine("Lỗi khi thực thi CSDL: " + ex.Message);
                // Bạn có thể ném lại lỗi để lớp gọi xử lý
                throw new Exception("Lỗi khi thực thi CSDL: " + ex.Message);
            }
        }
    }
}