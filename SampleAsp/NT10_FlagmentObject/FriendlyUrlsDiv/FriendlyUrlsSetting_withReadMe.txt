PM> Install-Package Microsoft.AspNet.FriendlyUrls

'.NETFramework,Version=v4.8' を対象とするプロジェクト 'SelfAspNet' に関して、
パッケージ 'Microsoft.AspNet.FriendlyUrls.1.0.2' の依存関係情報の収集を試行しています
依存関係情報の収集に 1.67 sec かかりました

DependencyBehavior 'Lowest' で
パッケージ 'Microsoft.AspNet.FriendlyUrls.1.0.2' の依存関係の解決を試行しています
依存関係情報の解決に 0 ms かかりました

パッケージ 'Microsoft.AspNet.FriendlyUrls.1.0.2' をインストールするアクションを解決しています
パッケージ 'Microsoft.AspNet.FriendlyUrls.1.0.2' をインストールするアクションが解決されました
'C:\Users\xxxx\source\repos\SelfAspNet\packages' に
パッケージ 'Microsoft.AspNet.FriendlyUrls 1.0.2' が見つかりました。
'C:\Users\xxxx\source\repos\SelfAspNet\packages' に
パッケージ 'Microsoft.AspNet.FriendlyUrls.Core 1.0.2' が見つかりました。
パッケージ 'Microsoft.AspNet.FriendlyUrls.Core.1.0.2' は
既にフォルダー 'C:\Users\xxxx\source\repos\SelfAspNet\packages' に存在します
パッケージ 'Microsoft.AspNet.FriendlyUrls.Core.1.0.2' を 'packages.config' に追加しました

'Microsoft.AspNet.FriendlyUrls.Core 1.0.2' が SelfAspNet に正常にインストールされました

パッケージ 'Microsoft.AspNet.FriendlyUrls.1.0.2' は
既にフォルダー 'C:\Users\xxxx\source\repos\SelfAspNet\packages' に存在します
パッケージ 'Microsoft.AspNet.FriendlyUrls.1.0.2' を 'packages.config' に追加しました
'Microsoft.AspNet.FriendlyUrls 1.0.2' が SelfAspNet に正常にインストールされました

NuGet の操作の実行に 2.35 sec かかりました
経過した時間: 00:00:05.2384101

=> ~/App_Start/RouteConfig.cs を生成
=> SelfAspNet/packages/Microsoft.AspNet.FriendlyUrls.1.0.2/readme.txt を生成
   (SelfAspNetは .sln (=solution))
    
//==== readme.txt ====
==========================================================
ASP.NET Friendly URLs v1.0.1
==========================================================

----------------------------------------------------------
Overview
----------------------------------------------------------
ASP.NET Friendly URLs provides a simple way to remove the
need for file extensions on URLs for registered file
handler types, e.g. .aspx.

For more information see http://go.microsoft.com/fwlink/?LinkID=264514&clcid=0x409

----------------------------------------------------------
Setup
----------------------------------------------------------

If your app didn't have a RouteConfig class before
installing ASP.NET Friendly URLs package:
----------------------------------------------------------
  The package includes a RouteConfig class that contains
  the call required to enable Friendly URLs. This call must
  be made from the Application_Start handler in your app's
  Global.asax file.

  Add the following to your Global.asax.cs file:

	using System.Web.Routing;
	...
    protected void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
    }


If your app had a RouteConfig class before installing
ASP.NET Friendly URLs package:
----------------------------------------------------------
  You'll need to update your RouteConfig class to enable
  Friendly URLs.

  Call EnableFriendlyUrls() in your RegisterRoutes method
  *before* any existing route registrations:

    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.EnableFriendlyUrls();

        // Put any additional route registrations here.
    }

