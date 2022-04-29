/** <!--
 *@title SelfAspNet / SampleAsp / NT10_FlagmentObject
 *       UserControl / UserControlSample.ascx.cs
 *@target UserControlSample.ascx
 *@target UserSchedule.aspx
 *@source SelfAspDB / Schedule_tb
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content NT 第10章 10.1 Userコントロール / p484 
 *         ユーザーコントロールを利用して ASPページを部品化
 *         実行前に Uid="yamada" / Uid="kanata"を切替て表示が変わるかを確認
 *
 *@subject【ユーザーコントロールの利点】サーバー #Include を利用しない理由
 *        ＊デフォルトで第三者(ブラウザ)からの直接アクセスを禁止
 *        ＊C#プロパティ構文によって記述可
 *        ＊フラグメントCacheを利用できる
 *        ＊VS[デザインView]で編集可
 *        
 *@based 9.4.2 Calendarと DB連携
 *       カレンダーに任意の情報を埋め込む
 *       => NT09_RichControl / Calendar / CalendarSchedule.aspx.cs
 *
 *@subject 「.aspx」UserSchedule.aspx
 *          <Calendar>.<SqlDataSource> -> [UserControlSample.ascx]へ切り取り
 *          
 *          ＊ユーザーコントロールの登録
 *          <%@ Register src="UserControlSample.ascx"
 *                 tagname="UserControlSample" tagprefix="uc1" %>
 *
 *          ＊ユーザーコントロールの利用
 *          <form>内
 *              <uc1:UserControlSample
 *                ID="UserControlSample" runat="server"
 *                Uid="yamada"/> 
 *              //Uid="kanata"に切替
 *                
 *@subject 「.aspx.cs」
 *          Page_Load(), calenSche_DayRender() -> [UserControlSample.ascx.cs]へ切り取り
 *
 *@subject 「.ascx」UseControlSample.ascx
 *          VS フォルダ右クリック -> [追加] -> [新しい項目]
 *          -> Visual C# / Web / Webフォーム / WebForm ユーザーコントロール
 *          -> <ファイル名>記述 -> [OK]
 *          
 *          <%@ Control Language="C#" AutoEventWireup="true"
 *                CodeBehind="UserControlSample.ascx.cs"
 *                Inherits="SelfAspNet.SampleAsp.NT10_FlagmentObject.UserControl.UserControlSample" %>
 *                
 *          上記のみのファイルを自動生成
 *          <Calendar>.<SqlDataSource> のみコピーペースト
 *          
 *          ※ <!DOCTYPE html>, <head runat="server">, <body>
 *          <form><div>などは記述しない。(「.aspx」に記述してあるから)
 *          
 *          => ASPページのタグを部分的に切り出して部品として再利用できる
 *          
 *@subject フラグメントCache (=断片的なキャッシュ) 
 *        「.ascx」内に記述
 *         <%@ OutputCache Duration="120" VaryByParam="*" %>
 *          
 *@subject 「.ascx.cs」
 *          フィールド private DataView schedule;
 *          Page_Load(), calenSche_DayRender()をコピーペースト
 *          
 *          プロパティの get, setを挿入
 *          (sds.SelectParameters["uid"].DefaultValueに保持するので
 *          このクラスでの private変数(フィールド)は不要)
 *
 *@NOTE 【考察】
 *       ＊「.ascx」に <head runat="server">, <form>があると
 *         「１つのページに１つだけ定義できます」というコンパイルエラー
 *         実行時に <uc1: UserControlSample>の位置に 
 *         「.ascx」の内容がインクルードされるので、
 *         ユーザーコントロール「.ascx」には部品として切り出すタグだけを記述
 *        
 *        ＊「.ascx」を選択した状態で Serverスタートすると
 *        「403 Forbidden」サーバーによるアクセス拒否 (単体での実行は不可)
 *        => 「.aspx」スタートすることで解決
 *        
 *@see NT09_RichControl / Calendar / CalendarSchedule.aspx.cs
 *@see UserSchedule.aspx
 *@see UserControlSample.jpg
 *@author shika
 *@date 2022-04-29
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
    public partial class UserControlSample : System.Web.UI.UserControl
    {
        private DataView schedule;

        public string Uid
        {
            get { return sds.SelectParameters["uid"].DefaultValue; }
            set { sds.SelectParameters["uid"].DefaultValue = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.schedule =
                (DataView)sds.Select(DataSourceSelectArguments.Empty);
        }//Page_Load()

        protected void calenSche_DayRender(object sender, DayRenderEventArgs e)
        {
            schedule.RowFilter =
                $"scheduleDate = '{e.Day.Date:yyyy/MM/dd}'";

            foreach (DataRowView row in schedule)
            {
                var literal = new Literal();
                literal.Text = $"<br /> {row["item"]}";
                e.Cell.Controls.Add(literal);
            }
        }//calenSche_DayRender()        
    }//class
}