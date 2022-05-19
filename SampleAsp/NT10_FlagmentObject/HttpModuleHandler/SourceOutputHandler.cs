/** <!--
 *@title SelfAspNet / SampleAsp / NT10_FlagmentObject /
 *       HttpModuleHandler / SourceOutputHandler.cs 
 *@inherits IHttpHandler
 *@source LoggingModule.cs
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第10章 部品化 / 10.5 HTTP Handler / p538
 *         10.5.2 自己定義 HTTP Handlerを作成し登録する
 *         
 *@subject ◆HTTP Handler
 *         ・クライアントからの Requestをサーバー処理するためのクラス
 *         ・Request内の拡張子に基づいて構成ファイル「Web.config」を検索し、
 *           対応する HTTP Handlerで ファイルを処理する。
 *         ・(HTTPモジュールは Requestのイベントを処理)
 *         
 *@subject ◆IHttpHandler インターフェイス
 *         ・ハンドラーを使用するには「Web.config」でこのハンドラーを設定し、
 *           IIS (Web Server) に登録する必要がある。
 *         ・詳細: https://go.microsoft.com/?linkid=8101007
 *         
 *         bool IsReusable 
 *           // 別のRequestに再利用できるか。
 *           // Requestごとに保存された状態情報がある場合、false
 *         void ProcessRequest(HttpContext context)
 *           // //ハンドラーの実装を記述
 *
 *@subject System.Web.HttpContextクラス 
 *         組込オブジェクト Request, Response, Serverなどにアクセスできるクラス
 *         
 *@subject System.IO.Pathクラス〔CS36〕
 *         string Path.GetFileName(string path) 
 *           // ファイル名を取得。拡張子も含む。
 *         string Path.GetFileNameWithoutExtension(string path)
 *           // ファイル名を取得。拡張子は付けない。
 *         string Path.GetDirectoryName(string path)
 *         string Path.Combine(string path1, string path2)
 *         string Path.Combine(param string[] paths)
 *         
 *@subject System.IO.StreamReaderクラス〔CS33〕
 *         new StreamReader(
 *              string path, [Encoding, [bool BOM, [int bufferSize]]] )
 *         string reader.ReadLine()  １行ずつ読込
 *         bool   reader.EndOfStream ファイルポインタが末尾かどうか
 *         int    reader.Peek()      次の文字を表す整数を返す。
 *                                   存在しない or 非対応のとき: -1
 *         string ReadToEnd()         全行を読込
 *       ( FileStream File.OpenRead(string path) 〔CS36, NT122 app5〕)
 *       
 *@subject HTMLエンコード (HTMLエスケープ) 〔NT17〕
 *         「<」「>」「&」など HTML予約文字をタグとして機能させず、
 *         文字参照「&lt;」「&gt;」「&amp;」に変換し文字列として正しく表示する。
 *         string Server.HtmlEncode(string)
 *         string Server.HtmlDecode(string)
 *         
 *@subject 10.5.1 System.Web.HttpForbiddenHandler
 *         ・特定拡張子へのアクセス禁止
 *         ・「/App_Data」に入れると HTTP経由のアクセスは禁止できる。
 *           拡張子に関係なくアクセス禁止する場合は、こちらを一般利用する。
 *         ・デフォルトで提供されている Handler
 *         ・「Web.config」への登録が必要〔下記〕
 *         
 *@subject 「Web.cofig」要素階層
 *          <configuration>
 *            └ <system.webServer>
 *                └ <modules>  HTTPモジュールを登録
 *                └ <handlers> HTTPハンドラーを複数格納
 *                   └ <add>   HTTPハンドラーを追加
 *                       name="" 一意の Handler名
 *                       verb="" HTMLメソッド: GET, POST, PUT, HEAD, DEBUG
 *                       path="" 実在クラスに付記する拡張子 or 特定ファイル名
 *                         「*」ワイルドカード / 例: 「*.txt」など
 *                       type="" Handkerの型。以下の形式。
 *                         完全修飾クラス名, [アセンブリ名], 
 *                         [Version=番号], [Culture=値], [PublicKeyToken=値]
 *                         
 *@subject「Web.cofig」例
 *         <system.webServer>
 *           <handlers>
 *             <add name="HttpForbiddenHandler"
 *                  verb="*" path="*.txt"
 *                  type="System.Web.HttpForbiddenHandler" />
 *             <add name="SourceOutputHandler" 
 *                  verb="GET" path="*.src"
 *                  type="SelfAspNet.SampleAsp.NT10_FlagmentObject.HttpModuleHandler.SourceOutputHandler" />
 *           </handlers>
 *           <modules>
 *             <add name="LoggingModuleSample"
 *                  type="SelfAspNet.SampleAsp.NT10_FlagmentObject.HttpModuleHandler.LoggingModuleSample" />
 *           </modules>
 *         </system.webServer>
 *                         
 *@NOTE【実行】SelfAspNetのプロパティ 開始動作「URLの実行」
 *            [https://localhost:44377/SampleAsp/NT10_FlagmentObject/HttpModuleHandler/LoggingModuleSample.cs.src]
 *            実在するファイルのURL(=アプリルートからのpath)に「.src」を付記して実行。
 *            「.src」付きのファイルは実在していなくてもいい。
 *           (「.src」は SorceOutoutHandlerで処理する)
 *            
 *     【結果】「LoggingModule.cs」のソースコードを HTML表示
 *             =>〔SourceOutputHandler_withLoggingModule.jpg〕
 *
 *@see LoggingModuleSample.cs
 *@see SourceOutputHandler_withLoggingModule.jpg
 *@author shika
 *@date 2022-05-19
 * -->
 */
using System;
using System.IO;
using System.Text;
using System.Web;

namespace SelfAspNet.SampleAsp.NT10_FlagmentObject.HttpModuleHandler
{
    public class SourceOutputHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string originalPath = context.Request.PhysicalPath;
            string fileName = Path.GetFileNameWithoutExtension(originalPath);
            string srcPath = Path.Combine(
                Path.GetDirectoryName(originalPath), fileName);

            BuildResponse(context, fileName, srcPath);            
        }//ProcessRequest()

        private void BuildResponse(HttpContext context, string fileName, string srcPath)
        {
            using (var reader = new StreamReader(srcPath, Encoding.UTF8))
            {
                HttpResponse Response = context.Response;
                Response.Write("<html>");
                Response.Write($"<head><title>{fileName}</title></head>");
                Response.Write("<body>");
                Response.Write($"<h1>{fileName}</h1>");
                Response.Write("<table border='0'>");

                int count = 1;
                while(reader.Peek() > -1)
                {
                    string line = context.Server.HtmlEncode(reader.ReadLine());
                    line = line.Replace(" ", "&nbsp;");

                    Response.Write("<tr>");
                    Response.Write($"<th align='right'>{count}</th>");
                    Response.Write($"<td>{line}</td>");
                    Response.Write("</tr>");

                    count++;
                }//while

                Response.Write("</body>");
                Response.Write("</html>");

                reader.Close();
            }//using
        }//ReadSource()
    }//class
}
