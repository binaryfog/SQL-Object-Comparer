using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BinaryFog.SqlObjectComparer.SqlServer
{
    public class SchemaGetter
    {

        public static string SaveSProcText(string connString, string dbName, string sprocName)
        {
            string str;
            SqlConnection conn = null;
            SqlDataReader rdr = null;
            SqlCommand cmd = null;
            string tempFilePath = null;
            string cs = "";
            try
            {
                try
                {
                    cs = string.Format(connString, dbName);
                    conn = new SqlConnection(cs);
                    conn.Open();
                    cmd = new SqlCommand("sp_helptext", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@objname", sprocName));
                    rdr = cmd.ExecuteReader();
                    List<string> lines = new List<string>();
                    while (rdr.Read())
                    {
                        string rawLine = (string)rdr["Text"];
                        string line = rawLine;
                        if (rawLine.Length > 2)
                        {
                            line = rawLine.Replace("\r\n", "");
                        }
                        lines.Add(line);
                    }
                    //if (lines.Count > 0)
                    //{
                    //    tempFilePath = Path.GetTempFileName();
                    //    File.WriteAllLines(tempFilePath, lines.ToArray<string>());
                    //}
                }
                catch (SqlException sqlException)
                {
                    SqlException e = sqlException;
                    str = null;
                    return str;
                }
                catch
                {
                    str = null;
                    return str;
                }
                return tempFilePath;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }
                if (conn != null)
                {
                    conn.Close();
                }
                if (rdr != null)
                {
                    rdr.Close();
                }
            }
            return str;
        }


    }
}
