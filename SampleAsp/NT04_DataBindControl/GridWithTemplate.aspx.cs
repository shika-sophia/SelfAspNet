/**
 *@title SelfAspNet / SampleAsp / GridWithTemplate.aspx.cs
 *@target GridTemplate.aspx
 *@target SelfAspDB / Album
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content GridViewControl with TemplateField / p160 - 171 /
 *@subject GridViewの一部を TemplateFieldに変更
 *         分類: DropDownListを追加、選択できるようにする。
 *                 DetaSource: SelfAspDB_ListEditCat
 *         コメント:   編集時のTextBox.Columns="60"を追加
 *         最終更新日: 編集時に Date型検証 -> 更新時にアラート
 *                    <EditItemTemplate>内に CompareValidtorを追加
 *         削除ボタン: クリック時に Client側 confirm() 確認メッセージを出す。
 *                    <ItemTemplete>内の BtnDeleteに
 *                      OnClientClick="retrun cofirm('')" を追加
 *          
 *@subject GridViewイベント
 *         RowUpdatingイベント: 検証失敗時にキャンセル
 *         RowUpdated イベント: 例外発生時に例外メッセージを取得する
 *         RowCreated イベント: フッター行の末尾に総ページを表示
 *         
 *@subject ソート時のアイコン表示
 *         ＊「.aspx」<GridView>
 *          <SortAscendingHeaderStyle>内 CssClass="asc" -> CSS asc.pngの表示
 *          <SortDescendingHeaderStyle>内 CssClass="desc" -> CSS desc.pngの表示 
 *          
 *         ＊CSS「../NT03_ServerControl/ValidSample_Style.css」
 *          .asc {
 *              background: url(../../Image/asc.png) right no-repeat;
 *          }
 *          .desc {
 *              background: url(../../Image/desc.png) right no-repeat;
 *          }
 *          .asc a, desc a {
 *              padding: 10px;
 *          }
 *
 *@see GridViewSample.aspx
 *@see SampleAsp/NT03_ServerControl/ValidSample_Style.css
 *@see SampleSql / Alubum_tb.sql
 *@see ResultFile / GridWithTemplate.jpg
 *@author shika
 *@date 2021-11-30, 12-01
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

        //検証失敗時にキャンセル
        protected void gridTemplate_RowUpdating(
            object sender, GridViewUpdateEventArgs e)
        {
            if(!Page.IsValid)
            {
                e.Cancel = true;
            }
            else
            {
                //更新前の処理
            }
        }

        //例外発生時に例外メッセージを取得する
        protected void gridTemplate_RowUpdated(
            object sender, GridViewUpdatedEventArgs e)
        {
            if(e.Exception != null)
            {
                e.ExceptionHandled = true;
                Response.Write(e.Exception.Message);
            }
        }

        //フッター行の末尾に総ページを表示
        protected void gridTemplate_RowCreated(
            object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.Footer)
            {
                Literal lit = new Literal();
                lit.Text = $"総ページ数: {gridTemplate.PageCount}";
                e.Row.Cells[e.Row.Cells.Count - 1].Wrap = false;
                e.Row.Cells[e.Row.Cells.Count - 1].Controls.Add(lit);
            }
        }
    }//class
}