/**
 *@title SelfAspNet / SampleAsp / NT09_RichControl / CalendarControl / CalendarSample.aspx.cs
 *@target CalendarSample.aspx
 *@source None
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第９章 9.4 Calendarコントロール / p465 / List 9-10         
 *         Calendarの表示 / 日付クリックで string取得し表示
 *         
 *@subject 「.aspx」ASPページ
 *          TextBox ID="txtDate"
 *          Calendar ID='calen"
 *                   OnSelectionChanged="calen_SelectionChanged"
 *
 *@subject 「aspx.cs」イベントハンドラー
 *          DateTime calen.SelectedDate
 *
 *@see CalendarSample.jpg
 *@author shika
 *@date 2022-04-25
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT09_RichControl.CalendarControl
{
    public partial class CalendarSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void calen_SelectionChanged(object sender, EventArgs e)
        {
            txtDate.Text = calen.SelectedDate.ToString("yyyy/MM/dd");
        }
    }//class
}