/**
 *@title SelfAspNet / SampleAsp / NT04_DataBindControl / ListViewSample.aspx.cs
 *@target ListViewSample.aspx
 *@source SelfAspDB_ListView / Book_tb
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 4.5 ListView / p185 / List 4-19, 4-20
 *@subject
 *
 *@see ResultFile / ListViewSample.jpg
 *@author shika
 *@date 2021-12-04
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT04_DataBindControl
{
    public partial class ListViewSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }//class
}

/*
【例外】InvalidCastException: 94行
<AlternatingItemTemplate>内の <asp:CheckBox>が
なぜか「キャストできません」という例外発生。

<ItemTemplate>の <asp:CheckBox>は正常に出力。
それをコピーしてもダメ。
そもそも、ここは編集していない。
ここより上の自己編集した部分にタイプミスがあるのだろうか

 */