using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication.Classes
{
    public class DBHelper
    {
        /* Strings de conexión */
        // DEBUG:           debugConnectionString

        // NL AC 152:       NLAC152ConnectionString
        // NL WH 277:       NLWH277ConnectionString

        // MX WH 279:       MXWH279ConnectionString

        readonly string connectionString = ConfigurationManager.ConnectionStrings["MXWH279ConnectionString"].ConnectionString;

        public bool AddLog()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_iic_add_log", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    connection.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        connection.Close();

                        return true;
                    }
                    else
                    {
                        connection.Close();

                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }


        public string GetLogsCount()
        {
            string result = "";

            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_iic_get_logs_count", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = reader[0].ToString();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return result + e;
            }


            return result;
        }

        public string GetLastLog()
        {
            string result = "";

            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_iic_get_last_log", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };


                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = reader[0].ToString();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return result + e;
            }


            return result;
        }

    }
}