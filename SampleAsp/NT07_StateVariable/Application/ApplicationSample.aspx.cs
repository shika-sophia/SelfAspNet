/**
 *@title SelfAspNet / SampleAsp / NT07_StateVariable.
 *       / Application / ApplicationSample.aspx.cs
 *@target ApplicationSample.aspx
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第７章 7.4 Application / p352 / List 7-8, 7-9
 *@subject ◆Application
 *         HttpApplicationState Page.Application
 *         void   Application.Lock();
 *         void   Application.UnLock();
 *         object Application[string] = object value;
 *         void   Application.Remove(string);
 *         void   Application.RemoveAll();
 *         
 *@subject 「Global.asax」Application_Start()
 *          The whole Application Settings should be discribed there.
 *          
 *@author shika
 *@date 2022-02-07
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT07_StateVariable.Application
{
    public partial class ApplicationSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //---- Global.asax as whole Application settings ----
            Application.Lock();
            Application["title"] = "Self Learn ASP.NET Web-Form [6th Edition]";
            Application.UnLock();

            //---- each ASP Page ----
            lblApp.Text = $"Application: {Application["title"]}";
        }
    }//class
}