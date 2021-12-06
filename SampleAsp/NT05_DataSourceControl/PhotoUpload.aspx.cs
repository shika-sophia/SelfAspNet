/**
 *@title SelfAspNet / SampleAsp / NT05_DataSourceControl / PhotoUpload.aspx.cs 
 *@target PhotoUpload.aspx
 *@source SelfAspDB_PhotoUpload / Photo_tb
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 5.1.2 SqlDataSource / p212 / List 5-1
 *@subject SqlDataSourceで、BinaryデータをDBに保存
 *         <SqlDataSource>の ID=""は
 *         イベントハンドラーで暗黙オブジェクトとして利用できる。
 *         ここでは長いので sdsに代入。
 *         SqlDataSource sds = SelfAspDB_PhotoUpload;
 *         
 *@subject プロパティ / メソッド
 *         ParameterCollection sds.InsertParameters;
 *                               INSERT文の全列のオブジェクトを取得
 *         string              upFile.PostedFile.ContentType;
 *                               サブプロパティは イベントハンドラーでしか代入できない。
 *         int index           pc.Add(string paraName, [DBType] , string value);
 *                                            INSERT文のプレースホルダーに代入
 *         int affected        sds.Insert();  INSERT実行
 *         
 *@see SampleSql / Photo_tb.sql
 *@see ResultFile/ Scan γ4φ480.jpg
 *@author shika
 *@date 2021-12-07
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT05_DataSourceControl
{
    public partial class PhotoUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            SqlDataSource sds = SelfAspDB_PhotoUpload;
            ParameterCollection pc = sds.InsertParameters;
            string postType = upFile.PostedFile.ContentType;

            int index = pc.Add("type", postType);
            int exeRow = sds.Insert();
            Response.Write($"INSERT ID[{index + 1}] / {exeRow} rows affected.");
        }
    }//class
}

/*
@see SampleSql / Photo_tb.sql
-- SELECT * FROM Photo;
-- |ID| type     | data
-- | 1|image/jpeg| 0xFFD8FFE000104A46494600010201012C012C0000...
-- | 2|application/octet-stream | 0xEFBBBF 
 */