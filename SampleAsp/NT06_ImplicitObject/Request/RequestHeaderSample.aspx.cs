/**
 *@title SelfAspNet / SampleAsp / NT06_ImplicitObject / RequestHeaderSample.aspx.cs
 *@target RequestHeaderSample.aspx
 *@source GridView.DataSource = this.Dictionary<string,string>
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第６章 組み込みオブジェクト 6.1 Request / p300 / List 6-1, 6-2, 6-3
 *         implicit [英]暗黙的
 *         
 *@subject RequestHeaderを取得/表示する
 */
#region -> ==== Request. API Reference ====
/*@subject NameValueCollection Request.Form  //HTMLタグ <form>, <input>, <select>
 *         NameValueCollection Request.QueryString
 *         
 *@subject ◆Request.Property (Request Header)
 *         string[] Request.AcceptTypes
 *         string   Request.ContentType
 *         Encoding Request.ContentEncoding
 *         int      Request.ContentLength
 *         string   Request.HttpMethod
 *         bool     Request.IsAuthenticated
 *         bool     Request.IsLocal
 *         bool     Request.IsSecureConnection
 *         Uri      Request.UrlReferrer
 *         string   Request.UserAgent
 *         string   Request.UserHostAddress
 *         string   Request.UserHostName
 *         string[] Request.UserLanguages
 *
 *@subject ◆Request.Property (Path)
 *         string Request.ApplicationPath,
 *         string Request.CurrentExecutionFilePath,
 *         string Request.FilePath,
 *         string Request.Path,
 *         string Request.PathInfo,
 *         string Request.PhysicalApplicationPath,
 *         string Request.PhysicalPath,
 *         string Request.RawUrl,
 *         Uri    Request.Url
 *
 *@subject ◆Request.ServerVariables[] (Request Header)
 *         System.Collections.Specialized.
 *         NameValueCollection Request.ServerVariables;
 *         string              Request.ServerVariables[string item]
 */
#endregion
/*
 *@subject ◆GridViewに Dictionary, List, DataSet, DataReaderにバインド可
 *         object BaseDataBoundControl.DataSource = (上記);
 *         Page Control.Page
 *         void Control.DataBind() //DataSourceをBind
 *
 *@see RequestHeaderSample.jpg
 *@author shika
 *@date 2022-01-16
 */
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT06_ImplicitObject
{
    public partial class RequestHeaderSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //---- Request.Xxxxx (RequestHeader) ----
            string[] mimeAry = Request.AcceptTypes;
            string mimeStr = String.Join(", ", mimeAry);
            
            string[] langAry = Request.UserLanguages;
            string langStr = String.Join(", ", langAry);

            var reqPropDic = new Dictionary<string, string>()
            {
                ["AcceptTypes"] = mimeStr,
                ["ContentType"] = Request.ContentType,
                ["ContentEncoding"] = Request.ContentEncoding.ToString(),
                ["ContentLength"] = Request.ContentLength.ToString(),
                ["HttpMethod"] = Request.HttpMethod,
                ["IsAuthenticated"] = Request.IsAuthenticated.ToString(),
                ["IsLocal"] = Request.IsLocal.ToString(),
                ["IsSecureConnection"] = Request.IsSecureConnection.ToString(),
                ["UrlReferrer"] = Request.UrlReferrer?.ToString() ?? "Null",
                ["UserAgent"] = Request.UserAgent,
                ["UserHostAddress"] = Request.UserHostAddress,
                ["UserHostName"] = Request.UserHostName,
                ["UserLanguages"] = langStr,
            };
            gridReqProp.DataSource = reqPropDic;
            
            //---- Request.Xxxxx (Path) ----
            var reqPathDic = new Dictionary<string, string>()
            { 
                ["ApplicationPath"] = Request.ApplicationPath,
                ["CurrentExecutionFilePath"] = Request.CurrentExecutionFilePath,
                ["FilePath"] = Request.FilePath,
                ["Path"] = Request.Path,
                ["PathInfo"] = Request.PathInfo,
                ["PhysicalApplicationPath"] = Request.PhysicalApplicationPath,
                ["PhysicalPath"] = Request.PhysicalPath,
                ["RawUrl"] = Request.RawUrl,
                ["Url"] = Request.Url.ToString(),
            };
            gridReqPath.DataSource = reqPathDic;

            //---- Request.ServerVariables[] ----
            NameValueCollection reqHeaders = Request.ServerVariables;
            var reqHeaderDic = new Dictionary<string, string>();
            foreach (object item in reqHeaders)
            {
                reqHeaderDic.Add(item.ToString(), reqHeaders[item.ToString()]);
            }
            gridReqHeader.DataSource = reqHeaderDic;

            Page.DataBind();
        }//Page_Load()
    }//class
}

/*
◆Request.Property (Request Header)
Key	Value
AcceptTypes	text/html, application/xhtml+xml, application/xml;q=0.9, image/avif, image/webp, image/apng, ＊/＊;
q = 0.8, application / signed - exchange; v = b3; q = 0.9
ContentType
ContentEncoding	System.Text.UTF8Encoding
ContentLength	0
HttpMethod	GET
IsAuthenticated	False
IsLocal	True
IsSecureConnection	True
UrlReferrer	Null
UserAgent	Mozilla/5.0 (Windows NT 10.0; Win64; x64) 
  AppleWebKit / 537.36(KHTML, like Gecko) 
  Chrome / 97.0.4692.71 Safari / 537.36
UserHostAddress::1
UserHostName::1
UserLanguages ja, en-US; q = 0.9, en; q = 0.8

◆Request.Property (Path)
Key	Value
ApplicationPath	/
CurrentExecutionFilePath	/SampleAsp/NT06_ImplicitObject/RequestHeaderSample.aspx
FilePath	/SampleAsp/NT06_ImplicitObject/RequestHeaderSample.aspx
Path	/SampleAsp/NT06_ImplicitObject/RequestHeaderSample.aspx
PathInfo	 
PhysicalApplicationPath	C:\Users\sophia\source\repos\SelfAspNet\SelfAspNet\
PhysicalPath	C:\Users\sophia\source\repos\SelfAspNet\SelfAspNet\SampleAsp\NT06_ImplicitObject\RequestHeaderSample.aspx
RawUrl	/SampleAsp/NT06_ImplicitObject/RequestHeaderSample.aspx
Url	https://localhost:44377/SampleAsp/NT06_ImplicitObject/RequestHeaderSample.aspx

◆Request.ServerVariables[] (Request Header)
Key	Value
ALL_HTTP	HTTP_CONNECTION:close 
HTTP_ACCEPT:text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,＊/＊;;
q = 0.8,application / signed - exchange; v = b3;
q = 0.9 HTTP_ACCEPT_ENCODING: gzip, deflate, br

HTTP_ACCEPT_LANGUAGE:ja,en - US;
q = 0.9,en; q = 0.8

HTTP_HOST: localhost: 44377

HTTP_USER_AGENT: Mozilla / 5.0(Windows NT 10.0; Win64; x64)
AppleWebKit / 537.36(KHTML, like Gecko)
Chrome / 97.0.4692.71 Safari / 537.36 HTTP_SEC_CH_UA: " Not;A Brand";
v = "99", "Google Chrome"; v = "97", "Chromium"; v = "97"

HTTP_SEC_CH_UA_MOBILE:? 0 
HTTP_SEC_CH_UA_PLATFORM:"Windows" 
HTTP_UPGRADE_INSECURE_REQUESTS: 1 
HTTP_SEC_FETCH_SITE: none 
HTTP_SEC_FETCH_MODE:navigate 
HTTP_SEC_FETCH_USER:? 1 
HTTP_SEC_FETCH_DEST: document

ALL_RAW Connection: close 
Accept: text / html,application / xhtml + xml,application / xml;
q = 0.9,image / avif,image / webp,image / apng,＊/＊;
q=0.8,application/signed-exchange;v=b3;q=0.9 
Accept-Encoding: gzip, deflate, br 
Accept-Language: ja,en-US;q=0.9,en;q=0.8 
Host: localhost:44377 
User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) 
AppleWebKit/537.36 (KHTML, like Gecko) 
Chrome/97.0.4692.71 
Safari/537.36 sec-ch-ua: " Not;A Brand";
v="99", "Google Chrome";v="97", "Chromium";v="97"
sec-ch-ua-mobile: ?0 sec-ch-ua-platform: "Windows"
upgrade-insecure-requests: 1 
sec-fetch-site: none 
sec-fetch-mode: navigate 
sec-fetch-user: ?1 
sec-fetch-dest: document

APPL_MD_PATH	/LM/W3SVC/2/ROOT
APPL_PHYSICAL_PATH	C:\Users\sophia\source\repos\SelfAspNet\SelfAspNet\
AUTH_TYPE	 
AUTH_USER	 
AUTH_PASSWORD	 
LOGON_USER	 
REMOTE_USER	 
CERT_COOKIE	 
CERT_FLAGS	 
CERT_ISSUER	 
CERT_KEYSIZE	256
CERT_SECRETKEYSIZE	2048
CERT_SERIALNUMBER	 
CERT_SERVER_ISSUER	CN=localhost
CERT_SERVER_SUBJECT	CN=localhost
CERT_SUBJECT	 
CONTENT_LENGTH	0
CONTENT_TYPE	 
GATEWAY_INTERFACE	CGI/1.1
HTTPS	on
HTTPS_KEYSIZE	256
HTTPS_SECRETKEYSIZE	2048
HTTPS_SERVER_ISSUER	CN=localhost
HTTPS_SERVER_SUBJECT	CN=localhost
INSTANCE_ID	2
INSTANCE_META_PATH	/LM/W3SVC/2
LOCAL_ADDR	::1
PATH_INFO	/SampleAsp/NT06_ImplicitObject/RequestHeaderSample.aspx
PATH_TRANSLATED	C:\Users\sophia\source\repos\SelfAspNet\SelfAspNet\SampleAsp\NT06_ImplicitObject\RequestHeaderSample.aspx
QUERY_STRING	 
REMOTE_ADDR	::1
REMOTE_HOST	::1
REMOTE_PORT	58736
REQUEST_METHOD	GET
SCRIPT_NAME	/SampleAsp/NT06_ImplicitObject/RequestHeaderSample.aspx
SERVER_NAME	localhost
SERVER_PORT	44377
SERVER_PORT_SECURE	1
SERVER_PROTOCOL	HTTP/1.1
SERVER_SOFTWARE	Microsoft-IIS/10.0
URL	/SampleAsp/NT06_ImplicitObject/RequestHeaderSample.aspx

HTTP_CONNECTION	close
HTTP_ACCEPT	text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,＊/＊;
q = 0.8,application / signed - exchange; v = b3; q = 0.9
HTTP_ACCEPT_ENCODING gzip, deflate, br
HTTP_ACCEPT_LANGUAGE	ja, en-US; q = 0.9,en; q = 0.8
HTTP_HOST localhost:44377
HTTP_USER_AGENT Mozilla/5.0 (Windows NT 10.0; Win64; x64) 
AppleWebKit / 537.36(KHTML, like Gecko) 
Chrome / 97.0.4692.71 Safari / 537.36
HTTP_SEC_CH_UA " Not;A Brand"; 
v = "99", "Google Chrome"; 
v = "97", "Chromium"; v = "97"
HTTP_SEC_CH_UA_MOBILE ? 0
HTTP_SEC_CH_UA_PLATFORM "Windows"
HTTP_UPGRADE_INSECURE_REQUESTS 1
HTTP_SEC_FETCH_SITE none
HTTP_SEC_FETCH_MODE	navigate
HTTP_SEC_FETCH_USER	?1
HTTP_SEC_FETCH_DEST	document

*/