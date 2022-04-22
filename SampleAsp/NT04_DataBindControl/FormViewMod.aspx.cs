/**
 *@title SelfAspNet / SampleAsp / NT04_DataBindControl / FormViewMod.aspx.cs
 *@based  FormViewSample.aspx
 *@target FormViewMod.aspx
 *@source SelfAspDB_FormView / Book_tb
 *@reference NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content NT 第４章 DataBind / FormView 練習問題 4-4 / p184
 *
 *@subject 問 FormViewの新規登録Formをカスタマイズ
 *         ＊検証機能の追加
 *           ・ISBN: RegularExpressionValidator
 *           ・price: RangeValidator 0 - 10000
 *           ・publisherData: CompareValidator Type="Date"
 *           ・ValidationSummary: output in same FormView
 *           ・output only「*」at each Validater
 *         ＊出版社の入力欄は選択ボックスに変更
 *           選択肢はデータベースからバインド
 *
 *@see FormViewSample.aspx.cs
 *@author shika
 *@date 2022-04-22
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT04_DataBindControl
{
    public partial class FormViewMod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //更新後に画面を移動する
        protected void formViewMod_ItemUpdated(
            object sender, FormViewUpdatedEventArgs e)
        {
            Response.Redirect("ListViewGroup.aspx");
            //formViewSample.DefaultMode = FormViewMode.Insert;
        }

        //実行時にパラメータを引き渡す
        protected void formViewMod_ItemUpdating(
            object sender, FormViewUpdateEventArgs e)
        {
            //priceが負数なら 元の値に戻す
            if(Int32.Parse(e.NewValues["price"].ToString()) <= 0)
            {
                e.NewValues["price"] = e.OldValues["price"];
            }

            //同じ処理
            TextBox txtPrice = (TextBox)formViewMod.FindControl("priceTextBox");
            if(Int32.Parse(txtPrice.Text) <= 0)
            {
                e.NewValues["price"] = e.OldValues["price"];
            }
        }

        protected void btnListView_Click(object sender, EventArgs e)
        {
            //Response.Redirect("ListViewGroup.aspx");
            //Response.RedirectPermanent("ListViewGroup.aspx");
            Server.Transfer("ListViewGroup.aspx");
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