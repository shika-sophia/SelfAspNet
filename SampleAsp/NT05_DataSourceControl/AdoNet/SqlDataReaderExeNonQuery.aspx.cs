/*
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 5.2 ADO.NET / p244 / List 5-8
 *@subject 接続型アクセス UPDATE文
 *         int affected = sqlCmd.ExecuteNonQuery();
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
    public partial class SqlDataReaderExeNonQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConnectionStringSettings setting =
                ConfigurationManager.ConnectionStrings["SelfAspDB"];

            using(var conn = new SqlConnection(setting.ConnectionString))
            {
                string sqlStr =
                    "UPDATE Book SET title = @title WHERE isbn = @isbn";
                var sqlCmd = new SqlCommand(sqlStr, conn);
                SqlParameterCollection paraDic = sqlCmd.Parameters;
                paraDic.AddWithValue("@title", "JavaScript逆引きレシピ 第２版");
                paraDic.AddWithValue("@isbn", "978-4-7981-5757-3");

                conn.Open();
                int affected = sqlCmd.ExecuteNonQuery();
                conn.Close();

                Response.Write(
                    $"SQL Command: {sqlStr.Substring(0, sqlStr.IndexOf(" "))}<br />"
                    + $"{affected} row affected.<br />");
            }//using
        }//Page_Load
    }//class
}

/*
SQL Command: UPDATE
1 row affected.

978-4-7981-5757-3   JavaScript逆引きレシピ 第２版	 2800	翔泳社	2018/10/15	False
 */