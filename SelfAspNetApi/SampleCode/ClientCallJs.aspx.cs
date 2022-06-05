/** <!--
 *@title SelfAspNetApi / SampleCode / ClientCallJs.aspx.cs
 *@target ClientCallJs.aspx
 *@source BookSearch.js
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第11章 Ajax / 11.4.3 ASP.NET Web API + jQuery / p597
 *         Web API 呼出のクライアントページ + jQuery
 *         
 *@subject jQueryの導入
 *         => SelfAspNetWebApi_Setting.txt
 *         
 *@subject BookSearch.js
 *         ◆jQueryメソッド
 *         $.getJSON(string URL, コールバック関数)
 *         $( ).val() セレクタの値を取得
 *         
 *         ◆コールバック関数 function(data)
 *         ・Web APIのアクセス完了時に呼び出される関数
 *         ・引数「data」: 戻り値を自動セット
 *          (ここでは JSON形式の Book_tbの各レコードを取得)
 *          
 *@subject「.aspx」
 *         ・ScriptManager <Script> <ScriptReference Path="">で JSファイルを登録
 *         ・HTMLコントロール: VS[ツールボックス] - [HTML]内に
 *           普通の HTML部品を配置するコントロールが収録されている。
 *           jQuery(JavaScript)利用時は、ASP.NETサーバーコントロールだと不具合の可能性がある。
 *           サーバーコントロールの機能を利用しないなら、なるべく HTMLコードを利用すべき。
 *           
 *         <asp:ScriptManager ID="ScriptManager1" runat="server"
                 EnableCdn="true"
                 AjaxFrameworkMode="Disabled">
               <Scripts>
                  <asp:ScriptReference Name="jquery" />
                  <asp:ScriptReference Path="~/SampleCode/BookSearch.js" />
               </Scripts>
           </asp:ScriptManager>
           <input id="txtIsbn" type="text" />&nbsp;
           <input id="btnSearch" type="button" value="Search" /><br />
           <div id="result">
           </div>

 *@author shika
 *@date 2022-06-05
 * -->
 */
/* <!-- 
 *@NOTE Error Search」ボタンを押しても何も表示されない。
 *      ブラウザ(Google Chrome)の「検証」で ErrorMessageを確認し原因を探す。
 *      
 *@Error Uncaught ReferenceError: $ is not defined at BookSearch.js:1:1
 *    => <Scripts> 
 *        <asp:ScriptRefernce Name="">
 *        <asp:ScriptRefernce Path="">を２つ定義すると解決
 *        
 *@Error Failed to load resource: the server responded with a status of 404 ()
 *    => 「BookController.cs」
 *        new SelAspNetDB() を new SelAspDB()に変更で解決
 *       「~/App_Data/SelfAspDB.mdf」を入れているので読み込めなかった様子。
 *      
 *Error jquery-3.6.0.js:10109  GET https://localhost:44378/SampleCode/api/book/978-4-7981-5112-0 404
 *    => 「https://localhost:44378/」と「api/book/978-4-7981-5112-0」の間に
 *       「/SampleCode」が挿入されている。
 *       「.aspx」ページのあるカレントフォルダ名が自動的に挿入されるようなので、
 *       プロジェクト直下に「ClientCallJs.aspx」を移動(namespaceも修正)すると解決。
 *
 *@subject ソースコードの位置を変更 / Routing, Pathを修正
 *      => プロジェクト直下にソースコードを置きたくないので、
 *        「/SampleCode」に「ClientCallJs.aspx」を戻し、
 *        「~/App_Start/WebApiConfig.cs」 
 *         routeTemplate: "SampleCode/api/{controller}/{id}" に変更
 *         
 *      => 「BookSearch.js」も「/Scripts」ではなく「/SampleCode」に置きたいので
 *         「.aspx」
 *           <Scripts> 
 *             <ScriptReference Path="~/SampleCode/BookSearch.js" />
 *          に変更。
 *
 *@NOTE【結果】
 *      => ClientCallJs_withBookSearch_js.jpg
 * -->
 */
using System;

namespace SelfAspNetApi.SampleCode
{
    public partial class ClientCallJs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }//class
}