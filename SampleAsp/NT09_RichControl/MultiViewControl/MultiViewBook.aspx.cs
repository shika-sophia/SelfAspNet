/** <!--
 *@title SelfAspNet / SampleAsp / NT09_RichControl /
 *       MultiViewControl / MultiViewBook.aspx.cs
 *@target MultiViewBook.aspx
 *@source SelfAspDB / Book_tb
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第９章 / 9.3 MultiView / 章末問題４ / p461, p482
 *         MultiView (GridView, FormView) を Bookで作成
 *         
 *@subject MultiView =>〔MultiViewSample.aspx.cs〕
 *
 *@subject 題意「GridViewの表示列は title, publisherのみ」
 *         DataKeyNames="isbn"を入れないと WHERE句を利用できないので、
 *         SqlDataSourceでの SELECT文では isbnを含む前列を検索。
 *         <Columuns>配下で表示する列のみ記述。
 *
 *@subject 画像URLの動的生成
 *        「.aspx」〔サンプルコード /Chap09/MultiViewBook〕
 *         <asp:Image ID="imageView2" runat="server"
 *                ImageUrl='<%# Eval("isbn", "https://wings.msn.to/books/{0}/{0}.jpg") %>'
 *                Width="100px" Height="160px"
 *                AlternateText='<%# Eval("title") %>'/><br />
 *
 *@see MultiViewSample.aspx.cs
 *@see MultiViewBook.jpg
 *@author shika
 *@date 2022-06-07
 * -->
 */

using System;

namespace SelfAspNet.SampleAsp.NT09_RichControl.MultiViewControl
{
    public partial class MultiViewBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grid_SelectedIndexChanged(object sender, EventArgs e)
        {
            multi.ActiveViewIndex = 1;
        }
    }//class
}