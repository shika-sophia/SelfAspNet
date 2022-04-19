/**
 *@title SelfAspNet / SampleAsp / MultiViewSample.aspx.cs
 *@target MultiViewSample.aspx
 *@source SelfAspDB / Album_tb
 *@reference NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content NT 第９章 9.3 MultiView / p461 / List 9-9
 *@subject MultiView 一覧 / 詳細画面の切替 (未完成)
 *         別ページに遷移することなく、１つのページ内で定義できる。
 *         
 *NOTE 【考察】
 *      章末問題4-6 が必要 => 〔後日〕
 *      
 *      アプリケーションでサーバー エラーが発生しました。
 *      例外の詳細: System.InvalidOperationException:
 *      選択されたデータ キーを取得する前に、
 *      データ キーを GridView 'gridMulti' で指定しなければなりません。
 *      データ キーを指定するには、DataKeyNames プロパティを使用します。
 *      
 *@author shika
 *@date 2022-04-19
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT09_RichControl.MultiViewControl
{
    public partial class MultiViewSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gridMulti_SelectedIndexChanged(object sender, EventArgs e)
        {
            mv.ActiveViewIndex = 1;
        }
    }//class
}