/*
 *@see SelfAspNetApi / SampleCode / SelfAspNetApi_Setting.txt
 *@modified SelfAspNetApi / SampleCode / ClientCallJs.aspx.cs
 *@modified SelfAspNetApi / SampleCode / ClientBundleJs.aspx.cs
 */

using System;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.UI;

namespace SelfAspNetApi
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // アプリケーションのスタートアップで実行するコードです
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //---- jQueryの登録 ----
            ScriptManager.ScriptResourceMapping.AddDefinition(
                "jquery", null,
                new ScriptResourceDefinition()
                {
                    Path = "~/Scripts/jquery-3.6.0.min.js",
                    DebugPath = "~/Scripts/jquery-3.6.0.js",
                    CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-3.6.0.min.js",
                    CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-3.6.0.js"
                });

            //---- Bundle ----
            BundleTable.Bundles.Add(
                new ScriptBundle("~/bundles/mySetting")
                .Include("~/SampleCode/BookSearch.js")
            );

            BundleTable.EnableOptimizations = true;
        }//Application_Start()
    }//class
}