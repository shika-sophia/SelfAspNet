/**
 * @content 10.4.4
 * @see Global_asax_UrlRouting.txt
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT10_FlagmentObject.Global_asax_Div
{
    public partial class UrlRoutingSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //---- instead of "<%$ RouteValue:xxxx %>" ----
            //ltrYear.Text = (string) RouteData.Values["year"];
            //ltrMonth.Text = (string) RouteData.Values["month"];
            //ltrDay.Text = (string) RouteData.Values["day"];
        }
    }
}