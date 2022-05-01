/**
 *@title SelfAspNet / SampleAsp / NT09_RichControl /
 *       NavigationControl / MenuViewSample.aspx.cs
 *@target MenuViewSample.aspx
 *@source Web.sitemap
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第９章 9.1.3 MenuView / p432 
 *         動的Menu (dynamic menu): サブメニューをマウスポイント時に展開
 *         静的Menu (static menu):  常に静的表示。
 *                                  表示する階層幅はプロパティで設定
 *                                  
 *@subject ◆MenuView 〔NT138〕
 *         int StaticDiplayLevels="" 静的メニューの表示階層数 / デフォルト: 0
 *                                   1以上にすると増やすことができる
 *         int MaximumDynamicDisplayLevels=""
 *            //MenuView全体の表示階層 = StaticDisplayLevels + MaximumDynamicDisplayLevels
 *            //この値を越える階層は非表示
 *         int Operation="" 階層表示の方向 Horizontal | Virtical
 *         
 *         ◆SiteMapDataSource
 *         bool ShowStartingNode="" トップノードを表示するか / デフォルト: True
 *
 *@author shika
 *@date 2022-05-02
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT09_RichControl.NavigationControl
{
    public partial class MenuViewSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}