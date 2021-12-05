/**
 *@title SelfAspNet / SampleAsp / NT04_DataBindControl / ListViewGroup.aspx.cs
 *@target ListViewGroup.aspx
 *@source SelfAspDB_ListViewGroup / Book_tb
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 4.5 ListView Grouping / p193 / List 4-21, 4-22
 *@subject [>]タスク -> ListViewの構成 -> レイアウトの選択 [並べて表示]
 *
 *@see ResultFile / ListViewGroup.jpg
 *@author shika
 *@date 2021-12-05
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT04_DataBindControl
{
    public partial class ListViewGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }//class
}

/*
【例外】〔ListViewSampleと同様〕
やはり、<asp:CheckBox>の InvalidCastExceptionは解決せず。

新規レコードを INSERTしたら、<ItemTemplate>のほうも これになった。
[SQL Server]には boolがなく、bit 0, 1で格納されており、
それを <asp:CheckBox Checked="<%# Eval(string column) %>" >
によって、内部的に true/false に変換していると思われ、
そこのキャストでの例外だろうか。

 */