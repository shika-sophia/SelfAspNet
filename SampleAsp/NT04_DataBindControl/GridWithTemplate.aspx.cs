/**
 *@title SelfAspNet / SampleAsp / GridWithTemplate.aspx.cs
 *@target GridTemplate.aspx
 *@target SelfAspDB / Album
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content GridViewControl with TemplateField / p160 - 171 /
 *@subject GridViewに TemplateFieldを追加
 *
 *@prepare SelfAspNet/Image 
 *         配布SampleCodeからコピー、アプリroot直下に配置。
 *         
 *@see GridViewSample.aspx
 *@see SampleSql / Alubum_tb.sql
 *@see ResultFile / 
 *@author shika
 *@date 2021-11-30
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT04_DataBindControl
{
    public partial class GridWithTemplate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gridTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}