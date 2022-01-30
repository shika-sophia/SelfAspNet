/**
 *@title SelfAspNet / SampleAsp / NT06_ImplicitObject / ResponseStatusSample.aspx.cs
 *@target ResponseStatusSample.aspx
 *@source
 *@reference DS 山田祥寛『独習 Java Server-side 新版』翔泳社, 2013
 *@reference NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content NT 第６章 組込オブジェクト 6.2 Response / p310, p319 / List 6-5, 6-8
 *@subject ◆Response
 *         HttpResponse Page.Response
 *         int          Response.StatusCode
 *         string       Response.StatusDescription
 *         void         Response.Write(string)
 *         
 *@subject リダイレクトと、フォワード 
 *         void Response.Redirect(string url)          //一時的
 *         void Response.RedirectPermanent(string url) //永続的
 *         void Server.Transfer(string path) 
 *         void Transfer(string path, bool preserveForm);
 *              //フォワード: Request情報(POSTデータ, Query, ViewState等を引き継ぐ)
 *              //第２引数 falseで Request情報を破棄
 *        => @see 〔NT04_DataBindControl / FormViewSample.aspx.cs〕
 *        
 *@subject ◆HTTP Status Code (summary)〔NT90 / p311〕
 *         200: OK            //成功
 *         304: Not Modified　//リソースが更新されていない。
 *         401: Unauthorized  //HTTP認証を要求
 *         403: Forbidden     //アクセスを拒否
 *         404: Not Found     //リソースが見つからない
 *         405: Method Not Allowed    //HTTPメソッドが不許可
 *         500: Internal Server Error //サーバー処理のエラー
 *         501: Not Implemented       //応答に必要な機能が未実装
 */
#region -> ◆HTTP Status Code (more detail) 〔DS6 詳細 / p85〕
/*         ＊100s Information
 *         100: Continue
 *         101: Switching Protocols
 *         
 *         ＊200s Success
 *         200: OK
 *         201: Created
 *         202: Accepted
 *         203: Non-Authoritative Information
 *         204: No Content
 *         205: Reset Content
 *         206: Partial Content
 *         
 *         ＊300s Redirect Error
 *         300: Multiple Choices
 *         301: Moved Permanently
 *         302: Found
 *         303: See Other
 *         304: Not Modified
 *         305: Use Proxy
 *         
 *         ＊400s Client Error
 *         400: Bad Request
 *         401: Unauthorized
 *         402: Payment Required
 *         403: Forbidden
 *         404: Not Found
 *         405: Method Not Allowed
 *         406: Not Acceptable
 *         407: Proxy Authentication Required
 *         408: Request Timeout
 *         409: Conflict
 *         410: Gone
 *         411: Length Required
 *         412: Precondition Failed
 *         413: Request Entity Too Large
 *         414: Request-Uri Too Long
 *         415: Unsupported Media Type
 *         416: Requested Range Not Satisfiable
 *         417: Expectation Failed
 *         
 *         ＊Server Error
 *         500: Internal Server Error
 *         501: Not Implemented
 *         502: Bad Gateway
 *         503: Service Unavailable
 *         504: Gateway Timeout
 *         505: Http Version Not Supported
 */
#endregion
/*
 *@author shika
 *@date 2022-01-17
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT06_ImplicitObject
{
    public partial class ResponseStatusSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int[] statusAry = new[]
            { 
                100, 101,                          //100s Information
                200, 201, 202, 203, 204, 205, 206, //200s Success
                300, 301, 302, 303, 304, 305,      //300s Redirect Error
                400, 401, 402, 403, 404, 405, 406, 407, 408, 409, 410,
                411, 412, 413, 414, 415, 416, 417, //400s Client Error
                500, 501, 502, 503, 504, 505,      //500s Server Error
            };

            Response.Write("◆HTTP Status Code <br />");
            foreach (int code in statusAry)
            {
                Response.StatusCode = code;
                Response.Write(
                    $"{Response.StatusCode}: {Response.StatusDescription} <br />");
            }//foreach

            Response.End();
        }//Page_Load()
    }//class
}

/*
200: OK
304: Not Modified
401: Unauthorized
403: Forbidden
404: Not Found
405: Method Not Allowed
500: Internal Server Error
501: Not Implemented

◆HTTP Status Code
100: Continue
101: Switching Protocols
200: OK
201: Created
202: Accepted
203: Non-Authoritative Information
204: No Content
205: Reset Content
206: Partial Content
300: Multiple Choices
301: Moved Permanently
302: Found
303: See Other
304: Not Modified
305: Use Proxy
400: Bad Request
401: Unauthorized
402: Payment Required
403: Forbidden
404: Not Found
405: Method Not Allowed
406: Not Acceptable
407: Proxy Authentication Required
408: Request Timeout
409: Conflict
410: Gone
411: Length Required
412: Precondition Failed
413: Request Entity Too Large
414: Request-Uri Too Long
415: Unsupported Media Type
416: Requested Range Not Satisfiable
417: Expectation Failed
500: Internal Server Error
501: Not Implemented
502: Bad Gateway
503: Service Unavailable
504: Gateway Timeout
505: Http Version Not Supported
 */