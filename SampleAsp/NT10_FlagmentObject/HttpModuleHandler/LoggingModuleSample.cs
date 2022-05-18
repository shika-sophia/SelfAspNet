/** <!--
 *@title SelfAspNet / SampleAsp / NT10_FlagmentObject
 *       HttpModuleHandler / LoggingModuleSample.cs
 *@inherits IHttpModule
 *@source SelfAspDB / AccessLog_tb
 *@reference NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content NT 第10章 部品化 / 10.4.7 HTTP Module / p533
 *@subject ◆HTTP Module
 *         ・ASPページを処理するイベントハンドラーを自己定義して割り込ませる機能
 *         ・「Global.asax」はアプリケーション全体のイベントハンドラーを定義。
 *           有効/無効の切替にはコードの変更が必要。
 *         ・「Web.config」で登録可。有効時のみフォルダに追加すればいい。
 *           (XML形式で記述、有効/無効の切替にコードを変更しなくて済む)
 *
 *@subject ◆IHttpModule インターフェイス
 *         ・自己定義クラス XxxxModule.cs に IHttpModuleを継承。
 *         ・モジュールを使用するには「Web.config」でモジュールを設定し、
 *           IIS (Web Server) に登録する必要がある。
 *         ・詳細:  https://go.microsoft.com/?linkid=8101007
 *         
 *         void Dispose() リソースの解放。不要時も省略不可。
 *         void Init(HttpApplication) リソースの確保 / イベントの追加
 *           <オブジェクト名>.<イベント名> += this.<メソッド名>;
 *           <オブジェクト名>.<イベント名> += new EventHandlar(<自己定義メソッド名>);
 *           
 *           delegate void EventHandlar(object sender, EventArgs e)
 *           
 *           例: context.LogRequest += new EventHandler(OnLogRequest);
 *          
 *@subject 追加イベント内
 *         HttpApplicationのメンバーにアクセスするためにキャスト。
 *         var req = ((HttpApplication) sender).Request;
 *         
 *         Application_EndRequest()内の内容は
 *        「Global_asax_AccessLog.txt」と同様
 *
 *@subject 「Web.config」
 *          <configuration>
 *           └ <system.webServer>
 *               └ <handlers> HTTPハンドラーを複数登録可
 *               └ <modules>  HTTPモジュールを複数登録可
 *                   <add>    HTTPモジュールを追加
 *                     └ name="" アプリ内で一意の名前
 *                     └ type="" モジュールの型。以下の形式。
 *                         完全修飾クラス名, [アセンブリ名], 
 *                         [Version=番号], [Culture=値], [PublicKeyToken=値]
 *          
 *         「Web.config」アプリルート直下 (フォルダ内に置くとDBに反映しない)
 *          <system.webServer>
 *            <modules>
 *              <add name="LoggingModuleSample"
 *                   type="SelfAspNet.SampleAsp.NT10_FlagmentObject.HttpModuleHandler.LoggingModuleSample" />
 *            </modules>
 *          </system.webServer>
 *          
 *@NOTE【実行】AccessLogModuleSample.aspx
 *     【結果】SelfAspDB / AccessLog_tb に アクセスログが登録される。
 *      =>〔AccessLogModule_withDB.jpg〕
 *      
 *      ※実行のたびに登録されるので アプリ直下の <modules>は削除。
 *        このフォルダ内の「Web.config」だと、DBに反映しない。
 *        
 *@see Global_asax_Div / Global_asax_cs_AccessLog.txt
 *@see AccessLogModuleSample.aspx
 *@see AccessLogModule_withDB.jpg
 *@author shika
 *@date 2022-05-18
 * -->
 */
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace SelfAspNet.SampleAsp.NT10_FlagmentObject.HttpModuleHandler
{
    public class LoggingModuleSample : IHttpModule
    {
        public void Dispose() { }

        public void Init(HttpApplication context)
        {
            context.EndRequest += this.Application_EndRequest;
        }

        public void Application_EndRequest(object sender, EventArgs e)
        {
            var req = ((HttpApplication) sender).Request;
            var setting = ConfigurationManager.ConnectionStrings["SelfAspDB"];

            using (var db = new SqlConnection(setting.ConnectionString))
            {
                var sql = new SqlCommand(
                    "INSERT INTO AccessLog" +
                    " (url, userAgent, referrer, accessTime)" +
                    " VALUES(@url, @userAgent, @referrer, @accessTime)"
                    , db);

                sql.Parameters.AddWithValue("@url", req.Url.ToString());
                sql.Parameters.AddWithValue("@userAgent", req.UserAgent.ToString());
                sql.Parameters.AddWithValue("@referrer",
                    req.UrlReferrer != null ? req.UrlReferrer.ToString() : "");
                sql.Parameters.AddWithValue("@accessTime", DateTime.Now.ToString());

                db.Open();
                sql.ExecuteNonQuery();
                db.Close();
            }//using
        }//Application_EndRequest()
    }//class
}
