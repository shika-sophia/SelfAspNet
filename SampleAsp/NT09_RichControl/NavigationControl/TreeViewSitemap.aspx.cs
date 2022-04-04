
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
    }
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

【考察】Windowsデフォルトの SiteMapProviderが 指定されているらしいので
Machine.configを変更するのは避けておく。

現アプリの Web.configに DefaultSiteMapProviderを指定
◆Web.config
<system.web>
  <siteMap enabled="true" defaultProvider="DefaultSiteMapProvider">
	<providers>
		<add name="DefaultSiteMapProvider" 
			type="System.Web.XmlSiteMapProvider"
			siteMapFile="Web.sitemap" />
	</providers>
  </siteMap>
</system.web>

HTTP Error 403.14 - Forbidden
The Web server is configured to not list the contents of this directory.

【考察】サイトマップに記述したURLにそのページが存在しない。というエラーかも。
デモデータでそのページを作るしかない。
(サンプルコードには階層構造に対応したファイルが存在する)

 */