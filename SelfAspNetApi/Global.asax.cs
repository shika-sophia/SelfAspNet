using System;
using System.Web;
using System.Web.Http;
using System.Web.UI;

namespace SelfAspNetApi
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // アプリケーションのスタートアップで実行するコードです
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //jQueryの登録
            ScriptManager.ScriptResourceMapping.AddDefinition(
                "jquery", null,
                new ScriptResourceDefinition()
                {
                    Path = "~/Scripts/jquery-3.6.0.min.js",
                    DebugPath = "~/Scripts/jquery-3.6.0.js",
                    CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-3.6.0.min.js",
                    CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-3.6.0.js"
                });
        }
    }//class
}