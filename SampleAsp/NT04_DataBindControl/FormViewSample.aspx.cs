/**
 *@title SelfAspNet / SampleAsp / NT04_DataBindControl / FormViewSample.aspx.cs
 *@target FormViewSample.aspx
 *@source SelfAspDB_FormView / Book_tb
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第４章 DB / FormView / p175
 *@subject 単票(= Single Record)の表示
 *@subject 編集、削除、新規作成
 *@subject 更新後に画面を移動する
 *         void Response.Redirect(string url)
 *         
 *         FormViewMode formView.DefaultMode = FormViewMode.Xxxx;
 *            FormViewMode.Readonly: 表示モード (デフォルト)
 *            FormViewMode.Edit:     編集モード
 *            FormViewMode.Insert:   新規モード
 *            
 *@subject 実行時にパラメータを引き渡す
 *         FormViewUpdateEventArgs e
 *         IOrderedDictionary e.NewValues
 *         IOrderedDictionary e.OldValues
 *         
 *         Control control.FindControl(string controlID)
 *           Control: 全てのサーバーコントロールの rootクラス。キャストして利用。
 *
 *@see ResultFile / FormViewSample.jpg
 *@author shika
 *@date 2021-12-03
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT04_DataBindControl
{
    public partial class FormViewSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //更新後に画面を移動する
        protected void formViewSample_ItemUpdated(
            object sender, FormViewUpdatedEventArgs e)
        {
            Response.Redirect("GridViewSample.aspx");
            //formViewSample.DefaultMode = FormViewMode.Insert;
        }

        //実行時にパラメータを引き渡す
        protected void formViewSample_ItemUpdating(
            object sender, FormViewUpdateEventArgs e)
        {
            //priceが負数なら 元の値に戻す
            if(Int32.Parse(e.NewValues["price"].ToString()) <= 0)
            {
                e.NewValues["price"] = e.OldValues["price"];
            }

            //同じ処理
            TextBox txtPrice = (TextBox)formViewSample.FindControl("priceTextBox");
            if(Int32.Parse(txtPrice.Text) <= 0)
            {
                e.NewValues["price"] = e.OldValues["price"];
            }
        }

    }//class
}

/*
【例外】Insertの値が nullのとき (未対応)
例外発生:
Cannot insert the value NULL into column 'isbn',
table 'C:\USERS\SOPHIA\SOURCE\REPOS\SELFASPNET\SELFASPNET\APP_DATA\SELFASPDB.MDF.dbo.Book';
column does not allow nulls. INSERT fails.
The statement has been terminated.
 */