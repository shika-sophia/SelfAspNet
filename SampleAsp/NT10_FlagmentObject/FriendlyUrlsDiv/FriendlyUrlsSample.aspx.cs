/**
 *@title SelfAspNet / SampleAsp /NT10_FlagmentObject/
 *       FriendlyUrlsDiv/FriendlyUrlsSample.aspx.cs
 *@target FriendlyUrlsSample.aspx.
 *@reference NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content NT 第10章 部品化 / 10.4.6 FriendlyUrlsモジュール / p529
 *         ■ FriendlyUrlsモジュール
 *         ・MapPageRoute()の簡易版
 *         ・RouteTableを定義せずに利用できる
 *         ・URLが「.aspx」のファイル名か、パラメータかを自動判定
 *           最も深い階層から順にファイルが存在しているかをチェックする。
 *           最初に見つかった「.aspx」ファイルを実行する。
 *         ・「.aspx」ファイル以下の文字列をパラメータと見なす
 *           (ファイル名とパラメータ名の重複に注意:
 *            「Blog/Yamada/Travel.aspx」が存在すると
 *            「Blog.aspx」に Yamada, Travelというパラメータは渡せない)
 *
 *@prerare PM> Install-Package Microsoft.AspNet.FriendlyUrls
 *         =>〔FriendlyUrlsSetting_withReadMe.txt〕
 *         
 *@subject ◆FriendlyUrlsを有効化
 *         Application_Start()
 *           RouteTable.Routes.EnableFriendlyUrls();
 *             || or
 *           RouteConfig.RegisterRoutes(RouteTable.Routes);
 *           =>〔~/App_Start/RouteConfig.cs〕
 *         
 *@sybject ◆構成ファイルの分離
 *        「~/App_Start/RouteConfig.cs」
 *         public static class RouteConfig
 *         {
 *             public static void RegisterRoutes(RouteCollection routes)
 *             {
 *                var settings = new FriendlyUrlSettings();
 *                settings.AutoRedirectMode = RedirectMode.Permanent;
 *                routes.EnableFriendlyUrls(settings);
 *             }
 *         }//class
 *         
 *@subject ◆URLセグメントを表示
 *          URLセグメント: FriendlyUrlsで取得したパラメータ
 *            URL「https:// ... /<「.aspx」ファイル名>/<パラメータ１>/<パラメータ２>/ ...」
 *            ASPページのファイル名: https:// ... /<「.aspx」ファイル名>
 *            URLセグメント:        <パラメータ１>/<パラメータ２>/ ...
 *          
 *        「.aspx」〔ListView: NT45 | Itemtype="": NT85〕
 *         <asp:ListView ... ItemType="String"> 
 *           <ItemTemplate>
 *             ・<%#: Item %><br />
 *           </ItemTemplate>
 *         
 *@subject「.aspx.cs」Page_Load() 〔DataSource, DataBind: NT42〕
 *          object BaseDataBoundControl.DataSource 
 *          void   BaseDataBoundControl.DataBind();
 *          IList<string> Request.GetFriendlyUrlSegments()
 *          
 *@NOTE 【実行】SelfAspNetプロパティ 開始動作「URLから実行」
 *       [https://localhost:44377/SampleAsp/NT10_FlagmentObject/FriendlyUrlsDiv/FriendlyUrlsSample/Yamada/Hobby/Tennis]
 *
 *       => 結果 〔FriendlyUrls_Segments.jpg〕
 *       Yamada, Hobby, Tennisを箇条書で表示
 *       
 *@see ~/App_Start/RouteConfig.cs
 *@see Global_asax_FriendlyUrls.txt
 *@see FriendlyUrls_Segments.jpg
 *@see FriendlyUrlsSetting_withReadMe.txt
 *
 *@author shika
 *@date 2022-05-16
 */
using Microsoft.AspNet.FriendlyUrls;
using System;

namespace SelfAspNet.SampleAsp.NT10_FlagmentObject.FriendlyUrlsDiv
{
    public partial class FriendlyUrlsSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            list.DataSource = Request.GetFriendlyUrlSegments();
            list.DataBind();
        }
    }//class
}