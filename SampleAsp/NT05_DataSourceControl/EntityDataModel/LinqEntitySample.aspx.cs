/** <!--
 *@title SelfAspNet / SampleAsp / NT05_DataSourceControl
 *       / EntityDataModel / LinqEntitySample.aspx.cs
 *@target LinqEntitySample.aspx
 *@source Models / Book.cs, SelfAspEntityModel.cs
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 5.4 Model Binding / p278 / List 5-17
 *         EDM: Entity Data Modelを DataSourceにして、
 *         Code-Behind「.aspx.cs」に LINQ to Entitiesを用いて
 *         データバインドするプログラム
 *         
 *@prepare Data Modelの作成
 *         [VS] SelfAspNet / Models 右クリック -> [追加] -> [新しい項目]
 *         -> [データ] - [ADO.NET Entity Data Model]
 *         -> クラス名:"SelfAspEntityModel"記入
 *         -> DBから Code First -> DB接続: SelfAspDB
 *         -> Table - dbo - Book 選択 -> [完了]
 *       => Book.cs, SelfAspEntityModel.cs 自動生成される。
 *         
 *@subject 「.aspx.cs」 GetBooks()
 *         ■LINQ to Entities
 *         ◆IQueryable<T> : IEnumerable (System.Linq.)
 *             ・DB接続, DBアクセスの結果を列記
 *             ・遅延実行: 戻り値の時点では DBアクセスを実行せず。
 *                        GridViewで Sorting, Paging機能を追加後に DBアクセスする。
 *                        Sorting, Pagingは DB内で完結するので
 *                        ServerControlのオーバーヘッドを軽減できる。
 *
 *@subject 「.aspx」 GridView
 *         <asp:GridView ID="gridLinqEntitySample" runat="server"
 *              SelectMethod="gridLinqEntitySample_GetBooks"
 *              DataKeyNames="isbn"
 *              AllowSorting="true"
 *              AllowPaging="true"
 *              PageSize="3">
 *         この記述だけで、DataBind, Paging, Sorting機能の実装が完了する
 *
 *@see ResultFile / LinqEntitySample.jpg
 *@author shika
 *@date 2022-01-12
 * -->
 */
using SelfAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT05_DataSourceControl.EntityDataModel
{
    public partial class LinqEntitySample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // 戻り値の型は IEnumerable に変更できますが、
        // のページングと並べ替えをサポートするには、次のパラメーターを追加する必要があります:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Book> gridLinqEntitySample_GetBooks()
        {
            var db = new SelfAspEntityModel();
            IQueryable<Book> qBook
                = from b in db.Book
                  orderby b.isbn
                  select b;
            return qBook;
        }//GetBooks()
    }//class
}