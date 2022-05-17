/** <!--
 *@title SelfAspNet / SampleAsp / NT10_FlagmentObject
 *       FriendlyUrlsDiv / GridFriendly.aspx.cs
 *@target GridFriendly.aspx
 *@source SelfAspDB / Aibum_tb
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第10章 部品化 / 10.4.6 FirendlyUrlsモジュール / p529
 *         FriendlyUrlsの動的な生成 (=プログラムによる生成)
 *
 *@subject 「.aspx.cs」Page_Load()でも可
 *          string FriendlyUrl.Href(
 *                   string virtualPath, param object[] segments)
 *                   
 *          例: FriendlyUrl.Href("~/album", Eval("id")) 
 *          => 「~/album/A0001」などのURLを生成
 *              ↓
 *@subject 「.aspx」ASPページで直接出力
 *          ASPページで FriendlyUrlsクラスのメソッドを利用する場合は
 *          インポートが必要。
 *          
 *          <%@ Page ... %>
 *          <%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>
 *            ...
 *          <asp:TemplateField HeaderText="Id" SortExpression="Id">
 *            <EditItemTemplate>
 *              <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
 *            </EditItemTemplate>
 *            <ItemTemplate>
 *              <asp:HyperLink ID="link" runat="server"
 *                  NavigateUrl='<%#: FriendlyUrl.Href("~/album", Eval("id")) %>'
 *                  Text="<%#: Eval("id") %>"></asp:HyperLink>
 *            </ItemTemplate>
 *          </asp:TemplateField>
 *
 *NOTE 【実行】「GridFriendly.aspx」を実行
 *      -> GridViewに Album_tbが DataBind、IDが リンクになる
 *      -> リンクをクリックすると
 *        「localhost:44377/album/T0002」とURLが生成されている。
 *        Route設定していないので HTTP Error「404 Not Found」となる。
 *      =>〔GridFriendly_withLinkURL.jpg〕
 *      
 *NOTE 【註】バインド式 <%#: ... %>内のメソッド, Bind(), Eval()など
 *          引数にstringを指定するメソッドを利用時に、Eval("")と「"」を用いる。
 *          その場合 Text="" で「"」を使うと
 *          サーバーエラー「タグが正しく形成されていません」となる。
 *          
 *          => タグ・プロパティには Text='' のように
 *          「'」シングルクォートを利用すると解決。
 *          (このサーバーエラーをよく起こしがちだが、原因に気付きにくい。)
 *          
 *@see GridFriendly_withLinkURL.jpg
 *@author shika
 *@date 2022-05-17
 * -->
 */
using System;

namespace SelfAspNet.SampleAsp.NT10_FlagmentObject.FriendlyUrlsDiv
{
    public partial class GridFriendly : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }//class
}