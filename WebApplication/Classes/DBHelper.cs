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


        public List<Zone> GetZones()
        {
            List<Zone> results = new List<Zone>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("iic_sp_get_zones", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Zone zone = new Zone();

                            zone.Id = Convert.ToInt32(reader[0].ToString());
                            zone.Name = reader[1].ToString();
                            zone.Description = reader[2].ToString();

                            results.Add(zone);
                        }


                        return results;
                    }
                }
            }
            catch
            {
                return results;
            }
        }

        public List<Options> GetOptionsByZoneName(string zoneName)
        {
            List<Options> results = new List<Options>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("iic_sp_get_options_by_zone_name", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@ZoneName", zoneName);


                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Options options = new Options();

                            options.Id = Convert.ToInt32(reader[0].ToString());
                            options.Name = reader[1].ToString();
                            options.Description = reader[2].ToString();
                            options.IdZone = Convert.ToInt16(reader[3].ToString());


                            results.Add(options);
                        }


                        return results;
                    }
                }
            }
            catch
            {
                return results;
            }
        }

    }
}