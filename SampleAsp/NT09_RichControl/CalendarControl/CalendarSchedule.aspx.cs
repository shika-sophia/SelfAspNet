/** <!--
 *@title SelfAspNet / SampleAsp / NT09_RichControl / CalendarControl / CalendarSchedule.aspx.cs
 *@target CalendarSchedule.aspx
 *@source SelfAspDB / Schedule_tb
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第９章 9.4 Calendarコントロール / p465 / List 9-11
 *         9.4.2 Calendarと DB連携
 *         カレンダーに任意の情報を埋め込む
 *
 *@subject 「.aspx」
 *          <Calendar> ID="calenSche"
 *            OnDayRender="calenSche_DayRender" イベントハンドラー呼出
 *            VisibleDate="2019-12-01"          デフォルトの表示月
 *            
 *          <SqlDataSource> ID="sds"
 *            //SELECT文で表示用に整形、@uid: ここでは固定値 yamada
 *            SelectCommand=
 *             "SELECT [scheduleDate], [subject] + '' + [scheduleTime] + '～' AS item, [uid]
 *                FROM [Schedule]
 *                WHERE ([uid] = @uid)
 *                ORDER BY [scheduleDate], [scheduleTime]">
 *            <SelectParameters>
 *               <asp:Parameter Name="uid" DefaultValue="yamada" Type="String" />
 *            </SelectParameters>
 *            
 *@subject 「.aspx.cs」イベントハンドラー
 *         ◆CalendarControl Event
 *         void (ID)_SelectionChanged(object sender, EventArgs e)
 *           //カレンダ上の選択日付が変更されたタイミングで呼出
 *         void (ID)_DayRender(object sender, DayRenderEventArgs e)
 *           //カレンダ上の各日付が出力されるタイミング
 *         void (ID)_VisibleMonthChanged(object sender, VisibleMonthChangedEventArgs? e)
 *           //カレンダの表示月を変更したタイミング
 *
 *@subject ◆System.Dat.DataViewクラス : IEnumerable他
 *         ・SELECTの結果を格納する DataTableオブジェクトと同様
 *         ・別メソッドでも利用するので フィールド保持
 *          (これにより、DBアクセスは Page_Load時の一回で済む。
 *           データの加工処理はメモリ上の仮想テーブルで行っている。)
 *          
 *         IEnumerable sds.Select(DataSourceSelectArguments)
 *           DataSourceSelectArguments.Empty 空の引数 Select()
 *         
 *         string dataView.RowFilter   フィルタ条件
 *         class  dataView.RowDataView 各行を格納している inner class
 *           object DataRowView[string property] 
 *             //指定した列名 propertyの値を取得/設定
 *         
 *@subject ◆DayRenderEventArgsクラス e (System.Web.UI.WebControls.)
 *         CalendarDay e.Date
 *         TableCell   e.Cell
 *         
 *@subject ◆CalendarDayクラス  (System.Web.UI.WebControls.)
 *         DateTime e.Day.Date
 *         string   e.Day.DayNumberText
 *         bool     e.Day.IsSelectable
 *         bool     e.Day.IsSelected
 *         bool     e.Day.IsToday
 *         bool     e.Day.IsWeekend
 *         bool     e.Day.IsOtherMonth
 *         
 *@subject ◆TableCellクラス (System.Web.UI.WebControls.)
 *         ControlCollection e.Cell.Controls
 *         void              e.Cell.Controls.Add(Control)
 *
 *@subject ◆実装手順 calenSche_DayRender 
 *         VS[デザインビュー] カレンダー選択 ->
 *         [プロパティ・ウィンドウ] 雷アイコン(イベント) ->
 *         DayRender Wクリック -> 下記メソッド自動生成
 *
 *@see SampleSql / Schedule_tb.sql
 *@see CalendarSchedule.jpg
 *@author shika
 *@date 2022-04-25, 04-26
 * -->
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT09_RichControl.CalendarControl
{
    public partial class CalendarSchedule : System.Web.UI.Page
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