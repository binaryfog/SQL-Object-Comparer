using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BinaryFog.SqlObjectComparer.DTO;

namespace BinaryFog.SqlObjectComparer.SqlServer
{
    public class SqlCodeGetter : ISqlCodeGetter
    {

        public string GetObjectSqlCode(string connString, string dbName, string objName)
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
                    cmd.Parameters.Add(new SqlParameter("@objname", objName));
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
