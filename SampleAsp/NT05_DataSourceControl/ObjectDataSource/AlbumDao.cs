using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SelfAspNet.SampleAsp.NT05_DataSourceControl.ObjectDataSource
{
    public class AlbumDao
    {
        private static readonly ConnectionStringSettings setting =
            ConfigurationManager.ConnectionStrings["SelfAspDB"];
        private readonly SqlConnection conn = 
            new SqlConnection(AlbumDao.setting.ConnectionString);

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public DataSet GetAlbumData(string category)
        {
            //---- SQL Command ----
            string sqlStr = 
                "SELECT id, comment, updated, favorite, category FROM Album";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conn;

            if(category == "(No Selected)")
            {
                sqlCmd.CommandText = sqlStr;
            }
            else
            {
                sqlCmd.CommandText = $"{sqlStr} WHERE category = @category";
                sqlCmd.Parameters.AddWithValue("@category", category);
            }

            //---- DataSet ----
            var ds = new DataSet();
            var adapter = new SqlDataAdapter(sqlCmd);
            adapter.Fill(ds, "AlbumDs");

            return ds;
        }//GetAlbumData()

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteAlbumData(string id)
        {
            int result;

            using (conn)
            {
                //---- SQL Command ----
                string sqlStr = "DELETE FROM Album Where id = @id";
                var sqlCmd = new SqlCommand(sqlStr, conn);
                sqlCmd.Parameters.AddWithValue("@id", id);

                //---- SQL Execute ----
                conn.Open();
                    result = sqlCmd.ExecuteNonQuery();
                conn.Close();
            }//using

            return result;
        }//DeleteAlbumData()

    }//class
}