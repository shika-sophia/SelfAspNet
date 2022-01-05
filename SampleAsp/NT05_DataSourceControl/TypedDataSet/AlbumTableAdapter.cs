/**
 *@see AlubumTypedDataSet.aspx.cs
 *@see PagerSample.aspx.cs
 *
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static SelfAspNet.SampleAsp.NT05_DataSourceControl.TypedDataSet.AlbumDataSet;

namespace SelfAspNet.SampleAsp.NT05_DataSourceControl.TypedDataSet.AlbumDataSetTableAdapters
{
    public partial class AlbumTableAdapter
    {
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public DataSet GetAlbumData(string category)
        {
            ConnectionStringSettings setting =
                ConfigurationManager.ConnectionStrings["SelfAspDB"];
            var db = new SqlConnection(setting.ConnectionString);
            var comm = new SqlCommand();
            comm.Connection = db;
            if (category == "(No Selected)")
            {
                comm.CommandText = 
                    "SELECT id, comment, updated, favorite, category FROM Album ";
            }
            else
            {
                comm.CommandText = 
                    "SELECT id, comment, updated, favorite, category FROM Album WHERE category = @category";
                comm.Parameters.AddWithValue("@category", category);
            }

            var ds = new DataSet();
            var adapter = new SqlDataAdapter(comm);
            adapter.Fill(ds, "Album");
            return ds;
        }//GetAlbumData()

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AlbumDataTable GetAlbumPaging(int startRowIndex, int maximumRows)
        {
            //m～n件のレコード取得をする SELECT文
            SqlCommand comm = this.Connection.CreateCommand();
            comm.CommandText = 
                $"SELECT id, comment, updated, favorite, category FROM Album" +
                $" ORDER BY updated DESC" +
                $" OFFSET {startRowIndex} ROWS FETCH NEXT {maximumRows} ROWS ONLY";
            this.Adapter.SelectCommand = comm;

            //SELECT文を実行して、型付きDataSetに流し込む
            AlbumDataSet ds = new AlbumDataSet();
            this.Adapter.Fill(ds, "Album");
            return ds.Album;
        }
    }//class
}