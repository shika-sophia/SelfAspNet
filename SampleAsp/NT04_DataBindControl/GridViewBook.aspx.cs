/**
 *@title SelfAspNet / SampleAsp / NT04_DataBindControl / GridViewBook.aspx.cs
 *@target GridViewBook.aspx
 *@source SelfAspDB / Book_tb
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第４章 DataBind 練習問題 4-3 / p172 
 *         問 Book_tbを GridViewで表示
 *         ・Sort, Paging, Edit, Delete機能を有効にする
 *         ・タイトル行を日本語にする
 *         ・ISBNコードをリンクにする
 *         ・発売日「yy/MM/dd」, 単価「0,000円」
 *         
 *@subject ◆XxxxFieldのみで実装
 *         HyperLinkField
 *         BoundField
 *         CheckBoxField
 *         CommandField
 *         
 *NOTE 【考察】         
 *      ・Link / Sort, Paging, Edit, Delete機能は 
 *        イベントハンドラーを一切記述することなく動作する。
 *      ・<Button> OnClientClick="" は未定義で
 *        ItemTemplateにする必要がある。
 *        
 *@see ResultFile / GridViewBook.jpg     
 *@author shika
 *@date 2022-04-21
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT04_DataBindControl
{
    public partial class GridViewBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }//class
}