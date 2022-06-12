/** <!--
 *@title SelfAspNet / SampleAsp / NT10_FlagmentObject /
 *       MasterPageDiv / PracticeContent.aspx.cs
 *@target PracticeContent.aspx
 *@master MasterPageSample.master
 *@source SelfAspDB / Book_tb
 *@reference NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content NT 第10章 10.3 Master Page / 練習問題 10-2 / p511
 *         マスターページのコンテンツページを作成
 *        【設計】
 *         ・Wingsサイトの画像一覧を表示
 *           https://wings.msn.to/books/{0}/{0}.jpg // {0}: isbn
 *         ・画像URLを List<string>に保存〔未完成〕
 *           コードビハインドで DB接続して List<string>に格納すれば保存可能。
 *         ・各画像を  ListViewで表示
 *         
 *@subject ListView
 *         ・タグ内に何か記述すると、
 *           タスク[>] -> 並べて表示などのレイアウト編集ができなくなる。
 *         ・タグ内に記述したものが消えてもいいなら、[スキーマの編集]をすると
 *           再編集が可能になる。
 *           レイアウト内の <table>などを自動編集してくれるので有用。
 *          〔Group化 => NT04_DataBindControl / ListViewGroup.aspx〕
 *           
 *         ・コードビハインドで List.DataSource = listImageUrl;としたかったが
 *           一度、データバインドした Listの要素を「.aspx」側で値を取り出せず、
 *           普通に DataSourceControlを付けて <%# Eval() %>で値を取得するよう変更。
 *
 *@subject MasterPageでの Page.Header.Titleなどは
 *         各ページの Page_Load()で Page.Header.Titleをするより優先される。
 *         結果画像のTitleが「SqlDataSource」となっているのは、
 *         MasterPageで、Web.sitemapから読み込んだ Titleが反映されているから。
 *         
 *@subject <asp:Image> AlternateText=""
 *         Eval値を 5文字以内に整形し左寄せしたかったのだが、
 *         String.Format(string format)のように、alignなどはできない様子。
 *         [×] <%# Eval("title", "{0,-5}") %>
 *         
 *         値の整形については今後の課題とす。
 *         
 *@NOTE【エラー】
 *     「.aspx」で <asp:ListView>, <asp:Image>を認識してくれない問題
 *      エラーメッセージ:「xxxxは不明な要素です。
 *      コンパイルエラーか Web.configが存在しない場合に発生します」
 *      デザインView, コードビハインドでは ちゃんと認識している。
 *     
 *      ・ListViewの namespaceをインポートしても解決せず。
 *      <%@ Import namespace="System.Web.UI.WebControls" %>
 *      
 *      ・Web.configをつけても解決せず。
 *      
 *      ・ListViewDataBind()内で
 *          var source = listView.DataSource = imageUrlList;
 *          source = imageUrlList;
 *          としていた。(注意メッセージ: 不必要な代入)
 *             ↓
 *          listView.DataSource = imageUrlList;
 *          と改めると、ListView, Imageへの認識は解決。
 *          (明確なコンパイルエラーでなくても、
 *           コードへの注意で「不明な要素」が起こることが分った)
 *           
 *@author shika
 *@date 2022-06-11
 * -->
 */
using System;

namespace SelfAspNet.SampleAsp.NT10_FlagmentObject.MasterPageDiv
{
    public partial class PracticeContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //【註】ここに Header要素を記述しても、MasterPageのほうが優先される
            //Page.Header.Title = "PrcticeContnt";
            //Page.Header.Keywords = "Wings, Book, image";
            //Page.Header.Description = "/books内の画像";
        }//Page_Load()
       
    }//class
}