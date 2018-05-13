using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DAO
    {
        //Retriving connection String from app.config
        public static AppSettingsReader asr = new AppSettingsReader();

        public static SqlConnection GetConnection()
        {
            //SqlConnection con = new SqlConnection(asr.GetValue("StoreInventory", typeof(string)).ToString());
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            return con;
        }
        public static List<string> GetList()
        public static DataTable GetTable(string sql, SqlParameter[] pram, CommandType cmdType)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, GetConnection()))
                {
                    cmd.CommandType = cmdType;
                    if (pram != null && pram.Length != 0)
                    {
                        cmd.Parameters.AddRange(pram);
                    }
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }

            }
            catch (Exception)
            {

                return null;
            }

        }
        public static int IUD(string sql, SqlParameter[] pram, CommandType cmdType)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, GetConnection()))
                {
                    cmd.CommandType = cmdType;
                    if (pram != null && pram.Length != 0)
                    {
                        cmd.Parameters.AddRange(pram);
                    }
                    int i = cmd.ExecuteNonQuery();
                    return i;
                }
            }
            catch (Exception)
            {
                return 0;
                //throw Exception;

            }
        }
        public static int IUD(string sql, List<SqlParameter> pram, CommandType cmdType)
        {
            using (SqlCommand cmd = new SqlCommand(sql, GetConnection()))
            {
                cmd.CommandType = cmdType;
                if (pram != null && pram.ToArray().Length != 0)
                {
                    cmd.Parameters.AddRange(pram.ToArray());
                }
                int i = cmd.ExecuteNonQuery();
                return i;
            }
        }
    }
}
