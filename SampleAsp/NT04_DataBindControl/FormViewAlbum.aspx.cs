/**
 *@title SelfAspNet / SampleAsp / FormViewAlbum.aspx.cs
 *@target FormViewAlbum.aspx
 *@source SelfAspDB / Album_tb
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content NT 第４章 DataBind / 章末問題 4-6 / p200
 *@subject 問 Album_tbを FormViewで展開
 *         ・HeaderText="私のアルバム (単票)"
 *         ・Paging, Edit, Delete機能
 *         ・個々のラベルを日本語にする
 *         ・idから画像生成 Eval("Id", "~/Image/{0}.jpg")
 *         ・最終更新日を「yyyy/MM/dd」形式に整形
 *         
 *@subject Edit, Delete, Insert機能は
 *         <LinkButton>を配置後
 *         CommandName="" Edit | Delete | New が必要
 *
 *@NOTE 【考察】
 *       ImageUrl='<%# Eval("Id", "~/Image/{0}.jpg") %>'
 *       ImageUrl="" 「"」だとコンパイルエラー
 *       ImageUrl='' 「'」にすると解決
 *
 *@see ResultFile / FormViewAlbum.jpg
 *@author shika
 *@date 2022-04-24
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT04_DataBindControl
{
    public partial class FormViewAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }//class
}