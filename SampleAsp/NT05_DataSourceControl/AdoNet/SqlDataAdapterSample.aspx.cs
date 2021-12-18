/**
 *@title SelfAspNet / SampleAsp / NT05_DataSourceControl
 *       / AdoNet / SqlDataAdapterSample.aspx.cs
 *@target SqlDataAdapterSample.aspx
 *@source SelfAspDB / Book
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 5.2.8 非接続型アクセス SELECT / p247 / List 5-10
 *@subject ◆DB接続準備
 *           using System.Configuration;
 *         ConnectionStringsSetting
 *             ConfigurationManager.ConnectionStrings["SelfAspDB"];
 *         string setting.ConnectionString
 *         
 *         ◆SQL文準備とDB接続
 *           using System.Data.SqlClient;
 *         new SqlDataAdapter(string sqlStr, string connStr)
 *         SqlCommand             adapter.SqlCommand
 *         SqlParameterCollection sqlCmd.Parameters
 *         SqlParameter           paraDic.AddWithValue(
 *                                    string paraName, object value)
 *         ◆DataSetにデータ流入、DataSetから値の取得 
 *           using System.Data;
 *         new DataSet()
 *         void adapter.Fill(DataSet, string tableName)
 *           //adapterで接続したDBデータを DataSetに流し込む。
 *           //tableNameは DataSet内のテーブル名 (DBのテーブル名と異なっても良い)
 *         DataTableCollection ds.Tables
 *         DataTable           ds.Tables[string tableName]
 *         DataRowCollection   tb.Rows
 *         DataRow             tb.Rows[int index]
 *         object              tb.Rows[int index][string columnName]
 *         object              row[string columnName]
 *         object[]            row.ItemArray
 *         
 *@author shika
 *@date
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT05_DataSourceControl.AdoNet
{
    public partial class SqlDataAdapterSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var setting = ConfigurationManager.ConnectionStrings["SelfAspDB"];
            string sqlStr = "SELECT * FROM Book WHERE publisher = @publisher";

            var adapter = new SqlDataAdapter(sqlStr, setting.ConnectionString);
            adapter.SelectCommand.Parameters
                .AddWithValue("@publisher", "翔泳社");

            var ds = new DataSet();
            adapter.Fill(ds, "Book");

            for(int i = 0; i < ds.Tables["Book"].Rows.Count; i++)
            {
                Response.Write(
                    $"{ds.Tables["Book"].Rows[i]["title"]}<br />");
            }
        }//Page_Load()
    }//class
}

/*
//==== Result ====
//SELECT * FROM Book WHERE publisher = @publisher; 
//AddWithValue("@publisher", "翔泳社");

独習Java 新版
Docker教科書
JavaScript逆引きレシピ 第２版
Androidアプリ開発の教科書
実践ドメイン駆動設計 DDD入門
独習 ASP.NET 第６版
 */