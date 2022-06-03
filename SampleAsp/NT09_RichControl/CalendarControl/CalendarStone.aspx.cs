/**
 *@title SelfAspNet / SampleAsp / NT09_RichControl / 
 *       CalendarControl / CalendarStone.aspx.cs
 *@target CalendarStone.aspx
 *@source private stoneAry
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第９章 Rich / 章末問題３ / ｐ481
 *         Calendarコントロールに VisibleMonthChangedイベントを付加
 *         
 *@subject (ID)_VisibleMonthChangedイベント
 *         => 〔CalendarSchedule.aspx.cs〕
 *
 *@author shika
 *@date 2022-06-03
 */

using System;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT09_RichControl.CalendarControl
{
    public partial class CalendarStone : System.Web.UI.Page
    {
        private string[] stoneAry = new string[]
        {
            "ガーネット", "アメジスト", "アクアマリン", "ダイアモンド", "エメラルド", "パール",
            "ルビー", "ペリドット", "サファイア", "オパール", "トパーズ", "ターコイス",
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            SelectStone(DateTime.Now.Month);
        }

        protected void calen_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            SelectStone(e.NewDate.Month);
        }

        private void SelectStone(int month)
        {
            calen.Caption = $"今月の誕生石: {stoneAry[month - 1]}";
        }
    }//class
}