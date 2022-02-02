/**
 *@title SelfAspNet / SampleAsp / NT06_ImplicitObject
 *       / Response / WriteFileSample.aspx.cs
 *@target WriteFileSample.aspx
 *@source ~/Image/A0001.jpg
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 6.2 Resopnse / 6.2.7 Writefile() / p325 / List 6-11
 *@subject 任意のファイルをそのまま出力する
 *         void   Response.WriteFile(string fileName)
 *         string Server.MapPath(string path)
 *         bool   User.IsInRole(string role)
 *         
 *         ファイルの内容を変更しない場合、
 *         「ファイルの読み込み -> ファイルの書き込み」
 *         という処理を記述しなくて済む。
 *         ブラウザ側でダウンロードして表示する。
 *         
 *@author shika
 *@date
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT06_ImplicitObject.Response
{
    public partial class WriteFileSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "image/jpeg";
            Response.WriteFile(Server.MapPath("~/Image/A0001.jpg"));
            Response.End();
        }
    }//class
}