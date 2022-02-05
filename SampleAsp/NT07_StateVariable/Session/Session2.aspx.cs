/**
 * @see Session1.aspx.cs
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT07_StateVariable.Session
{
    public partial class Session2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["title"] == null)
            {
                lblSeeion2.Text = "なし";
            }
            else
            {
                lblSeeion2.Text = Session["title"].ToString();
            }
            //Session.Remove("title");
        }
    }//class
}