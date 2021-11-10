using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp
{
    public partial class HelloAsp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSend_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtName.Text))
            {
                LbGreet.Text = "名前を入力してください";
            }
            else
            {
                LbGreet.Text = $"Hello, {TxtName.Text}さん";
            }

        }//BtnSend_Click()
    }//partial class
}