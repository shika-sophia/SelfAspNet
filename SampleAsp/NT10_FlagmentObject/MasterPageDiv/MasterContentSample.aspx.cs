/**
 * @see MasterPageSample.master
 * ImageUrl = "https://www.web-deli.com/image/logo.gif"
 *   ↓
 * ImageUrl = "~/Image/webDeli_logo.gif" 上記よりコピーして保存
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT10_FlagmentObject.MasterPageDiv
{
    public partial class MasterContentSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MasterPage master = Page.Master;
            Image image = (Image)master.FindControl("image1");
            image.ImageUrl = "~/Image/webDeli_logo.gif";
        }

        protected void grid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }//class
}