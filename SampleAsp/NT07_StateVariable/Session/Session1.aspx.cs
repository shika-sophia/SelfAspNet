/**　<!--
 *@title SelfAspNet / SampleAsp / NT07_StateVariable
 *       / Session / Session1.aspx.cs
 *@target Session1.aspx
 *@link   Session2.aspx
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第７章 状態管理 / 7.2 Session / p342 / List 7-2, 7-3
 *         Sessionを用いて、異なるページ間での情報維持。
 *         
 *@subject 「.aspx」
 *          Label ID="lblSession1"
 *          LinkButton ID="link"
 *          <a href=""> </a> も可だが、リンクColorは適用されない。
 *          
 *@subject 「.aspx.cs」Page_Load()
 *          ◆Session 
 *          System.Web.HttpSessionState Page.Session;  
 *          System.Web.SessionState Session: Page継承クラスでは暗黙オブジェクト
 *          
 *          object Session[string key] = object value; 
 *              //session変数 keyを取得/設定
 *          void   Session.Remove(string key) session変数 keyを削除
 *          void   Session.Remove()   全ての session変数を削除
 *          void   Session.Abandon()  Sessionオブジェクトを破棄
 *
 *@see Session2.aspx
 *@see Session_Links.jpg
 *@author shika
 *@date 2022-02-05
 * -->
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT07_StateVariable.Session
{
    public partial class Session1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["title"] == null)
            {
                Session["title"] = "Self Learn ASP.NET [6th Edition]";
                lblSession1.Text =
                    $"Session: {Session["title"]}<br />" +
                    "Session was registered.";      //[英] register: 登録する
            }
            else
            {
                lblSession1.Text = 
                    $"Session: {Session["title"]}<br />" +
                    "Session has retained still.";  //[英] retain: (今の状態を)維持する
            }
        }

        protected void link_Click(object sender, EventArgs e)
        {
            Server.Transfer("Session2.aspx");
        }
    }//class
}