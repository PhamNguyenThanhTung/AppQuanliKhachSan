using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BTL_QLKhachSan.myClass
{
    class Database
    {
        // 🔹 Chuỗi kết nối (chỉnh theo máy bạn)
        private readonly string connectionString = @"Data Source=LOMG\SQLEXPRESS;Initial Catalog=QLKhachSan;Integrated Security=True";

        /// <summary>
        /// Hàm thực thi câu lệnh SELECT và trả về DataTable
        /// </summary>
        public DataTable GetData(string sqlQuery, List<SqlParameter> parameters = null)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    // ✅ Luôn tạo bản sao tham số để tránh lỗi "already contained"
                    if (parameters != null)
                    {
                        foreach (SqlParameter p in parameters)
                        {
                            cmd.Parameters.Add(new SqlParameter(p.ParameterName, p.Value));
                        }
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi truy vấn CSDL: " + ex.Message);
                throw new Exception("Lỗi khi tải dữ liệu: " + ex.Message);
            }

            return dt;
        }

        /// <summary>
        /// Hàm thực thi câu lệnh INSERT / UPDATE / DELETE
        /// </summary>
        public void ExecuteNonQuery(string sqlQuery, List<SqlParameter> parameters = null)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    if (parameters != null)
                    {
                        foreach (SqlParameter p in parameters)
                        {
                            cmd.Parameters.Add(new SqlParameter(p.ParameterName, p.Value));
                        }
                    }

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thực thi CSDL: " + ex.Message);
                throw new Exception("Lỗi khi thực thi CSDL: " + ex.Message);
            }
        }

        /// <summary>
        /// Hàm thực thi câu lệnh trả về 1 giá trị duy nhất (VD: COUNT, SUM, MAX, ...)
        /// </summary>
        public object GetScalar(string sqlQuery, List<SqlParameter> parameters = null)
        {
            object result = null;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    if (parameters != null)
                    {
                        foreach (SqlParameter p in parameters)
                        {
                            cmd.Parameters.Add(new SqlParameter(p.ParameterName, p.Value));
                        }
                    }

                    con.Open();
                    result = cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thực thi Scalar: " + ex.Message);
                throw new Exception("Lỗi khi thực thi Scalar: " + ex.Message);
            }

            return result;
        }
    }
}
