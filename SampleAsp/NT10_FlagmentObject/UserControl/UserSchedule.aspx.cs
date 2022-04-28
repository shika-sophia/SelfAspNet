/** <!--
 *@title SelfAspNet / SampleAsp / NT10_FlagmentObject / UserControl / UaerSchedule.aspx.cs
 *@target UserSchedule.aspx
 *@source SelfAspDB / Schedule_tb
 *@reference NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content NT 第10章 10.1 Userコントロール / p484 
 *
 *@based 9.4.2 Calendarと DB連携
 *       カレンダーに任意の情報を埋め込む
 *       => NT09_RichControl / Calendar / CalendarSchedule.aspx.cs
 *
 *@subject 
 *
 *@see NT09_RichControl / Calendar / CalendarSchedule.aspx.cs
 *@author shika
 *@date 2022-04-28
 * -->
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT10_FlagmentObject.UserControl
{
    public partial class UserSchedule : System.Web.UI.Page
    {
        private DataView schedule;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.schedule =
                (DataView)sds.Select(DataSourceSelectArguments.Empty);
        }//Page_Load()

        protected void calenSche_DayRender(object sender, DayRenderEventArgs e)
        {
            schedule.RowFilter = 
                $"scheduleDate = '{e.Day.Date:yyyy/MM/dd}'";
            
            foreach(DataRowView row in schedule)
            {
                var literal = new Literal();
                literal.Text = $"<br /> {row["item"]}";
                e.Cell.Controls.Add(literal);
            }
        }//calenSche_DayRender()
    }//class
}