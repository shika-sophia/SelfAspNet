/** <!--
 *@title SelfAspNet / SampleAsp / NT11_AjaxDevelop
 *       jQueryDiv / jQuerySample.aspx.cs
 *@target jQuerySample.aspx
 *@source https://wings.msn.to/books/{0}/{0}_logo.jpg | {0}: isbn
 *
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content jQueryの利用
 *
 *@prepare 事前にインストールが必要だが、ValidatorControlで実行済
 *@prepare jQueryをインストール
 *         PM> Install jquery
 *         -> 「~/Scripts」に jquery-x.x.x.xxx.js 
 *         => 〔NT03_ServerControl / ValidSample.aspx.cs〕
 *         
 *@prepare 「Global.asax」Application_Start()
 *          => jQueryの保存場所を登録 〔同上 | p100 | NT20〕
 *
 *@subject ScriptManager
 *         ・JavaScriptを扱う場合は必須で配置
 *         ・CDN: Contents Delivery Network
 *                ライブラリ, CSS(=スタイルシート), 画像リソースなど
 *                コンテンツ配信に特化したネットワーク。
 *                特別な準備は不要で、レスポンスに優れるので優先的に利用。
 *         
 *         ＊階層
 *         <asp:ScriptManager>
 *           └ EnableCdn=""         CDNを利用するか / True* | False / *: デフォルト
 *           └ AjaxFrameworkMode="" Enabled* | Disabled | Explicit(=明示的)
 *           |                      ASP.NET AJAX関連のコードをダウンロードするか
 *           |
 *           └ <Scripts>            includeするスクリプト
 *              └ <asp:ScriptReference>
 *                 └ Name=""        「Global.asax」に登録したスクリプト名: jquery
 *         
 *         ＊例「.aspx」
 *         <asp:ScriptManager ID="ScriptManager1" runat="server"
 *             AjaxFrameworkMode="Disabled"
 *             EnableCdn="True">
 *             <Scripts>
 *               <asp:ScriptReference Name="jquery" />
 *             </Scripts>
 *         </asp:ScriptManager>
 *   
 *@subject セレクター関数 (×ここだけの名前)
 *         $( ... ) 引数を jQueryオブジェクトに変換
 *         
 *@subject セレクター記法
 *         $('xxxx')        HTML要素
 *         $('#id')         id="id"
 *         $('.clazz')      class="clazz"
 *         $('A B')         要素A 配下の すべての要素B
 *         $('A > B')       要素A 直下の すべての要素B
 *         $('[key = value]')     属性 key 値 valueのすべての要素
 *         $('xxx [key = value]') 属性 key 値 valueのすべてのxxx要素
 *         $('<li>リスト項目</li>').appendTo('ul')
 *                          HTML文字列をセレクタにすることも可
 *         $(document.body) JavaScript標準オブジェクト。「'」なし
 *           例: $(document.body).css("background-color", "lavender");
 *         
 *@subject 匿名関数
 *         ・jQueryの構文はすべてこの function内に記述
 *         ・すべてのページ読取完了後に処理される
 *           (function内の <div>などのHTMLタグは function実行時に読み取れない)
 *         
 *         ＊構文
 *         <script>
 *         $(function(){
 *           //処理内容
 *         });
 *         </script>
 *         
 *         ＊例「.aspx」
 *         <script>
 *         $(function(){
 *           $('#menu img.other'.fadeOut(5000);
 *         });
 *         </script>
 *
 *@subject jQueryメソッド 
 *         ・戻り値: ほぼ jQueryオブジェクト
 *         ・データ型は JavaScriptで厳密ではないが、ここではC#のデータ型で表記しておく
 *         ・メソッドチェーン: 戻り値は ほぼ jQueryオブジェクトなので連結処理可
 *         ・繰り返し処理: 対象オブジェクトが複数ある場合、すべての要素にメソッド処理を行う
 *                        (foreachしなくても繰り返し処理)
 *                        
 *         ＊attribute 属性
 *         $( ).attr(string name, [T value]) 属性名 nameに 値valを設定 
 *                                           属性名 nameのみなら 値取得
 *             .removeAttr(name)             属性名 nameを削除
 *             .addClass(string clazz)       class="clazz"を追加
 *             .removeClass(clazz)           class="clazz"を削除
 *             .toggleClass(clazz)           class="clazz"がなければ追加 / あれば削除
 *             .css(string name, [string value]) style="name : value" / nameのみなら値取得
 *              
 *         ＊element 要素
 *         $( ).html(string)   要素本体 <xxxx>本体</xxxx> に HTML文字列を追加
 *             .text(string)   要素本体にプレーンテキストを追加 (HTML予約文字はエスケープ処理)
 *         $(親).append(子)    親要素の子要素末尾に引数要素を追加
 *         $(子).appendTo(親)  引数の親要素の末尾に 対象オブジェクトの子要素を追加
 *             .prepend(要素c) 要素cを 子要素先頭に追加
 *             .after(c)       要素cを 後方に追加
 *             .before(c)      要素cを 前方に追加
 *             .replaceWith(c) 要素cを 対象オブジェクトの要素と置換
 *             .empty()        対象オブジェクト配下のすべての子要素を削除
 *             
 *         ＊effect 効果 / dur: duration 時間間隔(ミリ秒)
 *         $( ).show(long? dur) 非表示状態 -> 表示状態
 *             .hide(dur)       表示状態 -> 非表示状態
 *             .toggle(dur)     表示状態 -> 非表示状態 / 非表示状態 -> 表示状態
 *             .slideDown(dur)  スライドダウン (=縮小していく)
 *             .slideUp(dur)    スライドアップ (=拡大していく)
 *             .fadeIn(dur)     フェイドイン  (=だんだん濃くなる)
 *             .fadeOut(dur)    フェイドアウト(=だんだん薄くなる)
 *             
 *@subject メソッドチェーン
 *         ・メソッドの戻り値は ほぼ jQueryオブジェクトなので、
 *           メソッドを連結して処理可能
 *         
 *         $('#menu img.other')
 *              .fadeOut(5000)
 *              .fadeIn(5000)
 *              .slideUp(5000);
 *
 *@subject イベント関数 (×ここだけの名前)
 *         ＊構文
 *         $('要素名').イベント名(function () {
 *             $(this).メソッド(引数);
 *         });
 *         
 *         $(this): イベント発生元の要素オブジェクトを表す = $('要素名')
 *                  $( )で jQueryオブジェクトに変換しないと、jQueryメソッドは利用できない
 *         
 *         ＊例「.aspx」
 *         $('img').click(function () {
 *             $(this).fadeToggle(5000);
 *         });
 *         
 *@subject jQueryのイベント
 *         ＊マウス
 *         click      クリック時
 *         dbclick    ダブルクリック時
 *         mousemove  要素の中をマウスポインタが移動したとき
 *         mouseover  要素にマウスポインタが乗ったとき
 *         mouseout   要素にマウスポインタが外れたとき
 *         mouseup    マウスボタンを押したとき
 *         
 *         ＊key
 *         keydown    keyを押したとき
 *         keypress   keyを押し続けているとき
 *         keyup      keyを離したとき
 *         
 *         ＊focus
 *         focusin  マウスや|Tab|でフォーカスしたとき
 *         focusout マウスや|Tab|でフォーカスが外れたとき
 *         
 *         ＊form
 *         blur     要素からフォーカスを外したとき
 *         change   要素の値を変更したとき <input> <select> <textarea>など
 *         focus    要素にフォーカスされたとき
 *         select   クリックやカーソル移動でテキストを選択したとき <input> <textarea>
 *         submit   <form>送信したとき
 *         
 *         ＊others
 *         resize   ウィンドウのサイズを変更したとき
 *         scroll   ページ要素をスクロールしたとき
 *         unload   ページをアンロードしたとき
 *         
 *@see jQuerySample_withFadeout.jpg
 *@see jQuerySample_withSlideDown.jpg
 *@copyTo AjaxDevelop_analysis.txt
 *@author shika
 *@date 2022-05-29, 05-30
 * -->
 */
using System;

namespace SelfAspNet.SampleAsp.NT11_AjaxDevelop.jQueryDiv
{
    public partial class jQuerySample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }//class
}