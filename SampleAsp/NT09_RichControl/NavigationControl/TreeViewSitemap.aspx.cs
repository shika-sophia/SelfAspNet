/**
 *@title SelfAspNet / SampleAsp / NT09_RichControl / 
 *       NavigationControl / TreeViewSitemap.aspx.cs
 *@target TreeViewSitemap.aspx
 *@source Web.Sitemap
 *@reference NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第９章 Rich / 9.1 Navigation / p426
 *
 *@subject Web.sitemapファイルの作成
 *@subject TreeView (未完成) => 〔下記 サーバーエラー参照〕
 *
 *@see ErrorSolved_Machine_congig.txt
 *@author shika
 *@date 2022-04-30
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT09_RichControl.NavigationControl
{
    public partial class TreeViewSitemap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }//class
}

/*
//---- ServerError ----
パーサー エラー メッセージ:
  The connection string name is missing for the MySqlSiteMapProvider
ソース エラー:
行 273:    <siteMap>
行 274:      <providers>
行 275:        <add name="MySqlSiteMapProvider" type="MySql.Web.SiteMap.MySqlSiteMapProvider, MySql.Web, Version=8.0.20.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d" connectionStringName="LocalMySqlServer" applicationName="/" />
行 276:      </providers>
行 277:    </siteMap>
ソース ファイル: C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\machine.config    行: 275

【考察】.NET Frameworkデフォルトの SiteMapProviderが 指定されているらしいので
Machine.configを変更するのは避けておく。

現アプリの Web.configに DefaultSiteMapProviderを指定
◆Web.config 〔NT p435 /List 9-2〕
<system.web>
  ...
  <siteMap enabled="true" defaultProvider="DefaultSiteMapProvider">
	<providers>
		<add name="DefaultSiteMapProvider" 
			type="System.Web.XmlSiteMapProvider"
			siteMapFile="Web.sitemap" />
	</providers>
  </siteMap>
  ...
</system.web>

HTTP Error 403.14 - Forbidden
The Web server is configured to not list the contents of this directory.

【考察】サイトマップに記述したURLにそのページが存在しない。というエラーかも。
デモデータでそのページを作るしかない。
(サンプルコードには階層構造に対応したファイルが存在する)
  ↓
確認したが、サンプルコードは一部のファイルしか存在していない。
それに、ファイルが見つからない場合は「404 Not Found」になるはず。
「403 Forbidden」はサーバーによるアクセス拒否
アクセス権限がないファイルからスタートした場合などが原因で起こる。
  ↓
Web.configからスタートしたらしい。
「.aspx」からスタートすると「403 Forbidden」は起こらない。(これは解決)

上記(未解決) Web.configに defaultProvider="DefaultSiteMapProvider"を追加しても、
同じエラーが起きる。
エラーメッセージ: 
The connection string name is missing for the MySqlSiteMapProvider.
〔connectionStringNameに指定されている「MySqlSiteMapProvider」は存在しない〕
と言っている。

◆解決 => [ErrorSolved_Machine_congig.txt]
<providers>
  <clear /> ← これを追加する
  <add ...>
</prividers>
 */