/** <!--
 *@title SelfAspNet / SampleAsp / NT05_DataSourceControl / SqlPlaceHolder.aspx
 *@target SqlPlaceHolder.aspx
 *@source SelfAspDB_SqlPlaceHolder     / Album / SELECT category
 *@source SelfAspDB_SqlPlaceHolderGrid / Album / SELECT *
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 5.1 SQLプレースホルダー設定 / p204
 *         入力用・出力用のコントロール双方にデータソースをバインドする。
 *         同一DBでも、SELECT文が異なるので、接続IDは別にする。
 *         
 *         出力用 SELECT WHERE ([category] = @category) の
 *         「@xxxx」がプレースホルダー
 *         
 *@subject SQL文にユーザー選択の文字列をいれて SELECT WHERE
 *         ◆入力用 <asp:RadioButtonList 
 *                    Items="(No Select)"
 *                    AppendDataBoundItems="True" 
 *                      <asp:ListItem Selected="True">(No Select)</asp:ListItem>
 *                 >
 *                 <asp:SqlDataSource
 *                    ID="SelfAspDB_SqlPlaceHolder"
 *                    SelectCommand="
 *                       SELECT DISTINCT [category] FROM [Album]
 *                       ORDER BY [category]" >
 *                       
 *         ◆出力用 <asp:GridView
 *                    EmptyDataText="Please Select Category">
 *                 <asp:SqlDataSource
 *                    ID="SelfAspDB_SqlPlaceHolderGrid"
 *                    SelectCommand="
 *                      SELECT [Id], [category], [comment], [updated], [favorite]
 *                      FROM [Album] 
 *                      WHERE ([category] = @category) 
 *                      ORDER BY [updated]" >
 *                      
 *@see ResultFile / SqlPlaceHolder.jpg
 *@author shika
 *@date 2021-12-06
 * -->
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT05_DataSourceControl
{
    public partial class SqlPlaceHolder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }//class
}