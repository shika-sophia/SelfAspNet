/** <!--
 *@title SelfAspNet / SampleAsp / NT09_RichControl / 
 *       NavigationControl / TreeViewSitemap.aspx.cs
 *@target TreeViewSitemap.aspx
 *@source Web.Sitemap
 *@reference NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第９章 Rich / 9.1 Navigation / p426
 *         TreeViewの表示
 *         
 *@subject [Web.sitemap]ファイルの作成 (XML形式)
 *         <sitemap>
 *           xmlns="http://schemas.microsoft.com/AspNet/SiteMap-File-1.0" (固定値)
 *             └ <siteMapNode> 親ノード
 *               url="" / title="" / description=""
 *                 └ <siteMapNode> 子ノード
 *              
 *@subject [Web.config] に Sitemapファイルを登録
 *         <system.web>
 *           <siteMap enabled="true" defaultProvider="DefaultSiteMapProvider">
 *             <providers>
 *               <clear />  //【重要】.NET Frameworkのデフォルト設定を無効化〔下記〕
 *               <add name="DefaultSiteMapProvider"
 *                    type="System.Web.XmlSiteMapProvider"
 *                    siteMapFile="Web.sitemap" />
 *                    
 *               //複数設定時
 *               <add name="NextSiteMapProvider"
 *                    type="System.Web.XmlSiteMapProvider"
 *                    siteMapFile="Web2.sitemap" />
 *             </providers>
 *           </siteMap>
 *
 *@subject ◆DB連携 [Web.config] <system.web>内
 *         <siteMap enabled="true" defaultProvider="SqlSiteMapProvider">
 *           <clear />
 *           <providers>
 *             <add name="SqlSiteMapProvider"
 *                  type="SelfAspNet.SampleAsp.NT09_RichControl.NaviSqlProvider.SplSiteMapProviderSample
 *                  connectName="SelfAspDB" />
 *           </providers>
 *         </siteMap>
 *         
 *@subject ◆TreeView 
 *         string DataSourceID="smds" //SiteMapDataSourceのID
 *         int    NodeIndent=""       //インデントの幅 px
 *         bool   ShowLines=""        //階層ラインを表示するか
 *         
 *         ◆SiteMapDataSource ID="smds"
 *
 *see Web_config_NT09Navigation.txt
 *see Web_sitemap.txt
 *@see ErrorSolved_Machine_congig.txt
 *@author shika
 *@date 2022-04-30, 05-02
 * -->
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

上記 Web.configに defaultProvider="DefaultSiteMapProvider"を追加しても、
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

[machine.config] .NET Framework全体(他アプリも含む)のデフォルト設定を定義。
(C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\machine.config)
上記 <clear />でデフォルト設定を解除してからアプリ固有の設定をする。

 */