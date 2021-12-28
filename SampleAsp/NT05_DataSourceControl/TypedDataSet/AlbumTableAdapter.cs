/** <!--
 *@title SelfAspNet / SampleAsp / SampleAsp / NT05_DataSourceControl 
 *       / TypedDataSet / AlbumDataSetTableAdapters / AlbumTableAdapter.cs
 *@target partial AlbumDataSetTableAdapters.AlbumTableAdapter.cs
 *@source SelfAspDB / Album
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 5.3 DataAccessComponentの開発 / p264 / List 5-12 追補
 *@subject partial classで 自動生成コードに 自己定義コードを追加
 *         テキスト本文中 List 5-12は 「...中略...」となっていた部分を
 *         配布サンプルコードから追補。
 *         テキスト本文の説明通りだと、GetAlbumData()は
 *         引数なしのメソッドでしか定義できないので、
 *         Text Original:[ObjectParam2.aspx]を参照し
 *         => My Code:   [AlbumTypedDataSet.aspx]に
 *         ＊<asp:RadioButtonList>内
 *           <asp:ListItem Selected="True">(No Selected)</asp:ListItem>
 *           
 *         ＊<asp:GridView> - <asp:ObjectDataSource>内
 *           <SelectParameters>
 *             <asp:ControlParameter ControlID="list"
 *               Name="category"
 *               PropertyName="SelectedValue"
 *               Type="String" />
 *           </SelectParameters>
 *         を追補
 *         
 *@see ReaultFile / AlbumTypedDataSet.jpg
 *@author shika
 *@date 2021-12-28  
 * --> */
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
                    "SELECT id, comment, updated, favorite, category FROM Album";
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
            SqlCommand comm = this.Connection.CreateCommand();
            comm.CommandText = $"SELECT id, comment, updated, favorite, category FROM Album ORDER BY updated DESC OFFSET {startRowIndex} ROWS FETCH NEXT {maximumRows} ROWS ONLY";
            this.Adapter.SelectCommand = comm;
            AlbumDataSet ds = new AlbumDataSet();
            this.Adapter.Fill(ds, "Album");
            return ds.Album;
        }
    }//class
}