/**
 *@title SelfAspNet / SampleAsp / GridViewSample.aspx.cs
 *@target GridViewSample.aspx
 *@target SelfAspDB / Album
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content GridViewControl / p143 - 154 /
 *@subject GridViewの設置, 画像、ボタンのカスタマイズ
 *
 *@prepare SelfAspNet/Image 
 *         配布SampleCodeからコピー、アプリroot直下に配置。
 *         
 *@see SampleSql / Alubum_tb.sql
 *@see ResultFile / GridViewSample_withImage.jpg
 *@author shika
 *@date 2021-11-26
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT04_DataBindControl
{
    public partial class GridViewSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}