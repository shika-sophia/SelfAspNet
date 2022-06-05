/** <!--
 *@title SelfAspNetNetApi / SampleCode / ClientBundleJs.aspx.cs
 *@target ClientBundleJs.aspx
 *@source ~/ SampleCode / BookSearch.js
 *@source SelfAspDB / Book_tb
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第11章 Ajax / 11.4.4 Bundle, Minification / p599
 *         「BookSearch.js」の参照登録を
 *          各ページの ScriptManagerから「Global.asax」への登録に変更
 *          
 *@subject Bundle, Minification / バンドル, ミニフィケーション
 *         ・バンドル: 複数の「.js」「.css」への参照を束ねる(=bundle)こと
 *           Requestを１つにまとめることで、通信オーバーヘッドを軽減。
 *         ・ミニフィケーション: 圧縮すること。具体的には空白・改行・コメントを削除することで
 *           ファイルサイズを圧縮する仕組み。
 *         ・jQueryの CDNは圧縮済のファイルが提供されているので優先的に利用。
 *           (ここでは自己定義の BookSearch.js なので圧縮を利用)
 *           
 *         ・デバッグモードでは無効になる。
 *           空白・改行・コメントが削除されると可読性を損ない、デバッグに向かないため
 *           
 *           => デバッグモードでも強制的にバンドル, ミニフィケーションを有効化
 *           「Global.asax」
 *           BundleTable.EnableOptimizations = true;
 *           
 *           => デバッグモードを無効化
 *           「Web.config」
 *           <compilation debug="false" targetFramework="4.8" /> 
 *           この場合「Global.asax」
 *           BundleTable.EnableOptimizations = true;は不要
 *           
 *@prepare ◆パッケージマネージャーコンソール
 *         ・「空」プロジェクトのみ。テンプレートがある場合はデフォルトで設定されている。
 *         
 *         PM> Install-Package Microsoft.AspNet.Web.Optimization
 *         
 *         =>「package.config」に追加
 *            <package id="Microsoft.AspNet.Web.Optimization" version="1.1.3" targetFramework="net48" />
 *
 *         ◆「Global.asax」Application_Start()
 *         ＊BundleTableクラス (System.Web.Optimization.)
 *         BundleCollection BundleTable.Bundles
 *         void             BundleTable.Bundles.Add(Bundle)
 *         bool             BundleTable.EnableOptimizations
 *
 *         ＊Bundle / ScriptBundleクラス / StyleBundleクラス (System.Web.Optimization.)
 *         Bundle 
 *           └ new ScriptBundle(string virtualPath)
 *           └ new StyleBundle(string virtualPath)
 *           
 *         Bundle Bundle.Include(string virtualPath, param Itemtransform[])
 *                 // virtualString バンドル名となるpath (実際にフォルダ/ファイル構造がなくてもいい)
 *                 //「,」区切りで、いくつでも pathを連結可
 *         例：
 *         BundleTable.Bundles.Add(
 *               new ScriptBundle("~/bundles/mySetting")
 *               .Include("~/SampleCode/BookSearch.js")
 *         );
 *         BundleTable.EnableOptimizations = true;
 *
 *@subject「.aspx」
 *         ＊インポート
 *         <%@ Import Namespace="System.Web.Optimization" %>
 *         
 *         ＊Scpiptsクラス (System.Web.Optimization.)
 *         ・<asp:PlaceHolder>内に
 *         IHtmlString Scripts.Render(param string[] paths)
 *           //「Global.asax」で登録したバンドル名。「,」区切りで連結可。
 *           
 *         例:
 *         </asp:ScriptManager>
 *         <asp:PlaceHolder ID="PlaceHolder1" runat="server">
 *            <%: Scripts.Render("~/bundles/mySetting") %>
 *         </asp:PlaceHolder>
 *         
 *         ＊「BookSearch.js」への参照が重複するのでコメントアウト
 *         <asp:ScriptManager>
 *           <Scripts>
 *               <asp:ScriptReference Name="jquery" />
 *               <%-- <asp:ScriptReference Path="~/SampleCode/BookSearch.js" /> --%>            
 *           </Scripts>
 *         </asp:ScriptManager>
 *
 *@NOTE【実行】テキストボックスに「978-4-7981-5112-0」を入力、[Search]ボタンを押す。
 *@NOTE【結果】Book_tbのレコードが表示されることを確認。
 *      (ClientCallJs.aspxと同じ挙動であることを確認)
 *      => ClientCallJs_withBookSearch_js.jpg
 *      
 *@NOTE【結果】ブラウザ(Google Chrome)「検証」
 *      Pageタブ -> /bundle/mySetting?v=...
 *      -> 最小化できませんでした。最小化されていないコンテンツを返します。
 *      =>〔下記〕
 *      
 *@author shika
 *@date 2022-06-06
 * -->
 */
using System;

namespace SelfAspNetApi.SampleCode
{
    public partial class ClientBundleJs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }//class
}

/*
/* 
//---- ブラウザ(Google Chrome)「検証」Pageタブ/bundle/mySetting?v=... ----
最小化できませんでした。最小化されていないコンテンツを返します。
(8,19-20): run-time error JS1014: Invalid character: `
(8,30-31): run-time error JS1193: Expected ',' or ')': {
(8,51-52): run-time error JS1014: Invalid character: `
(8,52-53): run-time error JS1195: Expected expression: ,
(11,21-22): run-time error JS1014: Invalid character: `
(11,22-23): run-time error JS1195: Expected expression: <
(11,22-23): run-time error JS1195: Expected expression: <
(11,43-44): run-time error JS1002: Syntax error: }
(12,44-45): run-time error JS1002: Syntax error: }
(13,44-45): run-time error JS1002: Syntax error: }
(14,52-53): run-time error JS1002: Syntax error: }
(15,40-41): run-time error JS1197: Too many errors. The file might not be a JavaScript file: {
 */
/*
 *@see SampleCode / ClientCallJs.aspx.cs
 * 
 */
/*
$(function() {
  $('#btnSearch').click(function() {
    $.getJSON(`api / book /${$('#txtIsbn').val()}`,
      function(data) {
        let htmlText =
            `< li > ISBN: ${ data.isbn}</ li >
            < li > TITLE: ${ data.title}</ li >
            < li > PRICE: ${ data.price}</ li >
            < li > PUBLISHER: ${ data.publisher}</ li >
            < li > PUBLISH DATE: ${ data.publishDate}</ li >
            < li > CD - ROM: ${ data.cdrom}</ li >`;
        $('#result').html(htmlText);
      }//function(data)
    );//$.getJSON()
  });//$('#btnSearch').click()
}); 
*/