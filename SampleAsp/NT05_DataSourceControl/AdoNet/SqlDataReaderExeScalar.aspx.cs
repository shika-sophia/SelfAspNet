/*
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 5.2 ADO.NET / p245 / List 5-9
 *@subject 接続型アクセス SELECT 集計関数 (= 戻り値が 単一の値)
 *         object sqlCmd.ExecuteScalar()
 *         
 *@see SplDataReaderSample.aspx.cs
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
    public partial class SqlDataReaderExeScalar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConnectionStringSettings setting =
                ConfigurationManager.ConnectionStrings["SelfAspDB"];

            using (var conn = new SqlConnection(setting.ConnectionString))
            {
                string sqlStr = "SELECT COUNT(*) FROM Book";
                var sqlCmd = new SqlCommand(sqlStr, conn);
                
                conn.Open();
                Response.Write($"Book_tb レコード数: {sqlCmd.ExecuteScalar()}");
                conn.Close();
            }//using
        }//Page_Load()
    }//class
}

/*
//==== Result ====
Book_tb レコード数: 12

 */