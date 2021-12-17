/**
 *@title SelfAspNet / SampleAsp / NT05_DataSourceControl
 *       / AdoNet / SqlDataReaderSample.aspx.cs
 *@target SqlDataReaderSample.aspx
 *@source SelfAspDB / Book_tb
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 5.2 ADO.NET / p231 / List 5-7
 *         ■ System.Data.SqlClient 名前空間
 *         [SQL Server]専用の DB接続/操作クラス群を収録
 *         
 *@subject 接続型アクセス SELECT文
 *         ◆DB接続
 *         ConnectionStringSettings setting =
 *           ConfigurationManager.ConnectionStrings["SelfAspDB"]
 *             [Web.config]にアプリケーション全体で利用する DB接続名を登録。
 *             その接続名を指定して、[Web.config]から、
 *             <configuration> - <connectionStrings>全体を参照。
 *             
 *         string setting.ConnectionString 
 *         
 *         new SqlConnection(string connStr)
 *           using()内でのコンストラクタ呼出により、例外発生時も確実に 
 *           conn.Dispose() オブジェクト破棄(解放)してくれる。
 *         
 *         void conn.Open()  DB接続を実行
 *         void conn.Close() DB接続を切断(解放)
 *         
 *         ◆SQL文のコマンドオブジェクトを生成
 *         new SqlCommand(string splStr, SqlConnection conn)
 *         SqlParameterCollection sqlCmd.Parameters
 *           SQL文中にあるプレースホルダー(=パラメータ)の集合を Dictionary形式で取得
 *         SqlParameter           paraDic.AddWithValue(string paraName, object value)
 *           SQL文中にあるプレースホルダー(=パラメータ)に 値 valueを代入。
 *         
 *         SqlDataReader splCmd.ExecuteReader() SELECT文を実行
 *         int affected  sqlCmd.ExecuteNonQuery() INSERT, UPDATE, DELETE文を実行
 *         object        sqlCmd.ExecuteScalar() SELECT文の結果が単一の値の場合に実行
 *         
 *         ◆結果セットの読み取り
 *         SqlDataReader splCmd.ExecuteReader() SELECT文を実行
 *         bool reader.Read()  次の行を読み込み、次の行が存在しない場合 false
 *         T    reader[string columnName]
 *         T    reader[int index]
 *         Xxxx reader.GetXxxx(int index)
 *
 *@see SqlDataReaderExeNonQuery.aspx.cs
 *@see SqlDataReaderExeScalar.aspx.cs
 *@author shika
 *@date 2021-12-17
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT05_DataSourceControl.AdoNet
{
    public partial class SqlDataReaderSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConnectionStringSettings setting =
                ConfigurationManager.ConnectionStrings["SelfAspDB"];

            using(var conn = new SqlConnection(setting.ConnectionString))
            {
                string sqlStr = "SELECT * FROM Book WHERE publisher = @publisher";
                var sqlCmd = new SqlCommand(sqlStr, conn);
                sqlCmd.Parameters.AddWithValue("@publisher", "翔泳社");

                conn.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                    Response.Write($"{reader["title"]}<br />");
                }//while
                conn.Close();
            }//using
        }//Page_Load()
    }//class
}

/*
//---- [publisher = "翔泳社"] の titleを検索 ----
独習Java 新版
Docker教科書
JavaScript逆引きレシピ
Androidアプリ開発の教科書
実践ドメイン駆動設計 DDD入門
独習 ASP.NET 第６版
 */