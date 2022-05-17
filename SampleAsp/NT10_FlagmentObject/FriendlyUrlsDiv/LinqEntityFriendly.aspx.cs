/** <!--
 *@title SelfAspNet / SampleAsp / NT10_FlagmentObject / 
 *       FriendlyUrlsDiv / LinqEntityFriendly.aspx.cs
 *@based NT05_DataSourceControl / EntityDataModel / LinqEntitySample.aspx.cs
 *@target LinqEntityFriendly.aspx
 *@source Models / Book.cs, SelfAspEntityModel.cs
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第10章 部品化 / 10.4.6 FriendlyUrlsモジュール / p529
 *         URLフラグメントをメソッド引数に渡す
 *         
 *@subject ◆Value Provider〔NT81〕
 *         =>〔NT05_DataSourceControl / EntityDataModel / LinqEntitySample.aspx.cs〕
 *         
 *         属性 [FriendlyUrlsSegments(int index)] 
 *           指定した indexに対応する URLセグメントを メソッド引数に渡す
 *           
 *         public IQueryable<Book> gridLinqEntityFriendly_GetBooksByPrice(
 *           [FriendlyUrlSegments(0)] int? priceMin)
 *        
 *         ◆メソッド内の処理: 引数 priceMin 以上の行を Book_tbから取得
 *           qBook = from b in db.Book
 *                   orderby b.isbn
 *                   where b.price >= priceMin
 *                   select b;
 *                   
 *@NOTE【実行】SelfAspNetプロパティ / 開始動作「URLの実行」
 *            ファイル名 LinqEntityFriendly(.aspx)の後ろに パラメータ 3000を付記。
 *            [https://localhost:44377/SampleAsp/NT10_FlagmentObject/FriendlyUrlsDiv/LinqEntityFriendly/3000]
 *            
 *            -> 結果 price 3000以上の行のみ表示
 *            =>〔LinqEntityFriendly_over3000price.jpg〕
 *            
 *@see NT05_DataSourceControl / EntityDataModel / LinqEntitySample.aspx.cs
 *@see LinqEntityFriendly_over3000price.jpg
 *@author shika
 *@date 2022-05-17
 * -->
 */
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using SelfAspNet.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.ModelBinding;

namespace SampleAsp.NT10_FlagmentObject.FriendlyUrlsDiv
{
    public partial class LinqEntityFriendly : System.Web.UI.Page
    {
        private SelfAspEntityModel db = new SelfAspEntityModel();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // 戻り値の型は IEnumerable に変更できますが、
        // のページングと並べ替えをサポートするには、次のパラメーターを追加する必要があります:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Book> gridLinqEntityFriendly_GetBooks()
        {
            //var db = new SelfAspEntityModel();
            IQueryable<Book> qBook
                = from b in db.Book
                  orderby b.isbn
                  select b;
            return qBook;
        }//GetBooks()

        public IQueryable<Book> gridLinqEntityFriendly_GetBooksByPrice(
            [FriendlyUrlSegments(0)] int? priceMin)
        {
            //var db = new SelfAspEntityModel();
            IQueryable<Book> qBook;

            if (priceMin.HasValue)
            {
                qBook = from b in db.Book
                        orderby b.isbn
                        where b.price >= priceMin
                        select b;
            }
            else
            {
                qBook = gridLinqEntityFriendly_GetBooks();
            }

            return qBook;
        }//GetBooksByPrice()

        public void gridLinqEntityFriendly_UpdateBook(Book b)
        {
            //var db = new SelfAspEntityModel();

            if (ModelState.IsValid)
            {
                db.Entry<Book>(b).State = EntityState.Modified;
                db.SaveChanges();
            }
        }//UpdateBook()
    }//class
}