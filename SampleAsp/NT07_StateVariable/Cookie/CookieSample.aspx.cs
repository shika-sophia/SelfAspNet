/**
 *@title SelfAspNet / SampleAsp / NT07_StateVariable
 *       / Cookie / CookieSample.aspx.cs
 *@target CookieSample.aspx
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第７章 7.2 Cookie / p339 / List 7-2, 7-3
 *@subject
 *
 *@author shika
 *@date 2022-02-08
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT07_StateVariable.Cookie
{
    public partial class CookieSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if(Request.Cookies["email"] != null){
                    txtMail.Text = Request.Cookies["email"].Value;
                }
            }
        }//Page_Load()

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(txtMail.Text == "")
            {
                lblCookie.Text = "＜!＞ Required to input in TextBox.";
                return;
            }
            var cookie = new HttpCookie("email", txtMail.Text);
            cookie.Expires = DateTime.Now.AddDays(15);
            Response.AppendCookie(cookie);

            lblCookie.Text = 
                $"Response Cookie: {Response.Cookies["email"].Value}";
        }
    }//class
}