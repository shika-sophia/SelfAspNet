/**
 *@title SelfAspNet / SampleAsp / NT09_RichControl
 *       / NavigationControl / SiteMapPathSample.aspz.cs
 *@target SiteMapPathSample.aspx
 *@source Web.sitemap
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第９章 9.1.4 SiteMapPath / p433
 *         パンくずリスト BreadcrumbList
 *         トピックパス TopicPath
 *         現在ページの位置を上位階層からのリンクリストで表示したもの
 *         
 *@subject SiteMapPathコントロール
 *         自動的に Web.sitemapを読込 
 *         (SiteMapDataSourceを配置する必要がない)
 *         現在ページが sitemapファイルに存在しないと機能しない。
 *         現在ページからルートノードに向けてのリンクリストを自動生成
 *
 *@see SiteMapPathSample.jpg
 *@author shika
 *@date 2022-05-03
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT09_RichControl.NavigationControl
{
    public partial class SiteMapPathSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}