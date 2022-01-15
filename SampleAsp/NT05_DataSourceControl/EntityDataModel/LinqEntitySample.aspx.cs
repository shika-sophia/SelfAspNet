/** <!--
 *@title SelfAspNet / SampleAsp / NT05_DataSourceControl
 *       / EntityDataModel / LinqEntitySample.aspx.cs
 *@target LinqEntitySample.aspx
 *@source Models / Book.cs, SelfAspEntityModel.cs
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 5.4 Model Binding / p278 / List 5-17 ～ 5-22
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
 */
#region -> @subjects ==== Method Implementation ====
/*
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
 *@subject 下記のような Query「?priceMin=3000」を付けて実行 (= ユーザーの <form>入力)
 *         「where b.price >= priceMin」でフィルタリングした結果を出力
 *https://localhost:44377/SampleAsp/NT05_DataSourceControl/EntityDataModel/LinqEntitySample.aspx?priceMin=3000
 *
 *          ＊「.aspx.cs」 GetBooksByPrice([QueryString] int? priceMin)
 *          ◆Value Provider: ユーザー入力値から値を取得する仕組み
 *          ◆Value Provider Attribute []属性
 *          [QueryString([string key])]
 *          [Control(string id, [string propertyName])]
 *          [Form([string name])]
 *          [Cookie([string name])]
 *          [Session([string key])]
 *          [RouteData([string key])]
 *          [ViewState([string key])]
 *          
 *         ＊「.aspx」 GridView
 *         SelectMethod="gridLinqEntitySample_GetBooksByPrice"
 *         に変更
 *
 *@subject ◆データを更新する UPDATEメソッド
 *         ＊「aspx.cs」 UpdateBook(TEntity)
 *         引数: Entity-Type (= Tableをオブジェクト化したクラス) Book
 *               各列の入力値を Bookオブジェクトのプロパティに自動的にバインドしてくれる
 *         db: DbContext, T: TEntity
 *         DbEntityEntity<T> db.Entry<T>(T) 
 *             エンティティにアクセス / 操作できるオブジェクトを生成
 *         EntityState en.State エンティティの状態を取得/設定
 *         int         EntityState.Modified = 16 変更されたエンティティの状態
 *         int affected db.SaveChanges()  変更されたエンティティの状態を DBに保存
 *         
 *         ＊「.aspx」 GridView
 *         DataKeyNames="isbn"
 *         UpdateMethod="gridLinqEntitySample_UpdateBook"
 *         AutoGenerateEditButton="true"
 *         
 *@subject 「Book.cs」 Validation機能 (= 検証機能)
 *         ◆検証属性　System.ComponentModel.DataAnnotations        
 *         [Required()]              必須検証
 *         [StringLength(int max)]   文字列長検証
 *         [Range(int min, int max)] 値の範囲検証
 *         [Compare(string otherProperty)]          比較検証
 *         [RegularExpression(string regexPattern)]
 *                                   正規表現検証
 *         [DataType(enum DataType.Xxxx)]   データ型検証
 *         [CostomValidation(type, method)] 自己定義の検証メソッド
 *         
 *         ◆その他の属性
 *         [DisplayName(string)]     ヘッダ行の表示名
 *         [Key]                     primary keyを通知
 *         [Column(TypeName="")      データ型を指定
 *         ErrorMessage=""           ModelState.IsValid - false時に表示
 *           プレースホルダ 記述可
 *             {0}: プロパティの表示名
 *             {1}, {2}, ... 検証パラメタ
 *         
 *         ＊UpdateBook()の修正
 *         if(ModelState.IsValid) { } を追加
 *         
 *         bool ModelState.IsValid 検証できたか
 *                └ ModelStateDictionary Page.ModelState
 *                    検証状態を含むモデルの状態を表す Dictionaryオブジェクト
 *                    
 *@subject 「.aspx」ValidatationSummary
 *           ID="summaryLinqEntitySample" 
 *           HeaderText="Validation Error:"
 *           ShowSummary="true"
 *           
 *subject ◆型付きDataBindContorol ASP.NET 4.5-
 *         ItemType="" バインドされた型を指定
 *         
 *         ＊従来 => ASP.NET 4.5-
 *         <%#: Eval("isbn") %> => <%#: Item.isbn  %>
 *         <%#: Bind("isbn") %> => <%#: BindItem.isbn  %>
 *         
 *        ＊「.aspx」GridView
 *       <asp:GridView
 *            ItemType="SelfAspNet.Models.Book" >
 *         <Columns> １列目に挿入される
 *           <asp:TemplateField>
 *               <ItemTemplate>
 *                  <%#: Item.isbn  %> <= これでデータバインド
 *               </ItemTemplate>
 *           </asp:TemplateField>
 *         </Columns>
 *      </asp:GridView>
 */
#endregion
/*
 *@see ResultFile / LinqEntitySample.jpg
 *@see ResultFile / LinqEntitySample_withQueryString.jpg
 *@see ResultFile / LinqEntitySample_withValidation.jpg
 *@author shika
 *@date 2022-01-12, 01-13, 01-14
 * -->
 */
using SelfAspNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT05_DataSourceControl.EntityDataModel
{
    public partial class LinqEntitySample : System.Web.UI.Page
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
        public IQueryable<Book> gridLinqEntitySample_GetBooks()
        {
            //var db = new SelfAspEntityModel();
            IQueryable<Book> qBook
                = from b in db.Book
                  orderby b.isbn
                  select b;
            return qBook;
        }//GetBooks()

        public IQueryable<Book> gridLinqEntitySample_GetBooksByPrice(
            [QueryString] int? priceMin)
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
                qBook = gridLinqEntitySample_GetBooks();
            }

            return qBook;
        }//GetBooksByPrice()

        public void gridLinqEntitySample_UpdateBook(Book b)
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