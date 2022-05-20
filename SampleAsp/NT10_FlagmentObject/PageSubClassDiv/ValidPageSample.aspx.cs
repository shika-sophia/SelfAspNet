/** 
 *@see ValidMessagePage.cs
 *
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT10_FlagmentObject.PageSubClassDiv
{
    public partial class ValidPageSample : ValidateMessagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                LblResult.Text = "<○> All input can be accepted.";
            }
        }
    }//class
}

