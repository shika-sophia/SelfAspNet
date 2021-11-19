/** 
 *@title SelfAspNet / SampleAsp / NT03_ServerControl / CustomValidSample.aspx.cs
 *@target CustomValidSample.aspx 
 *@target ValidSample_Style.css
 *@reference YAMADA Yoshihiro『Self-Learn ASP.NET ６th Edition』Shoueisha, 2020
 *@content Chapter 3 ServerControl / 3.4.9 CustomValidator / p115 /
 *         Fig 3-36, Matrix 3-26, List 3-10, 3-11
 *@subject Self-Define Validation 
 *  ◆[.aspx] CustomValidator
 *      ClientValidationFunction="MyValid"
 *      ControlToValidate="txtName"
 *      CssClass="validSample"
 *      ErrorMessage=""
 *
 *  ◆[.aspx.cs] CusName_ServerValidate(
 *          object source, ServerValidateEventArgs args)
 *      ＊Arguments
 *      source: CustomVaridator
 *      args: ServerValidateEventArgs
 *      
 *      ＊Properties
 *      bool args.IsValid
 *      T    args.Value
 *      int  string Length
 *      
 *  ◆[.aspx] JavaScript: function MyValid(source, args)
 *  
 *@see ResultFile / CustomValid_server.jpg
 *@see ResultFile / CustomValid_JavaScript.jpg
 *@author shika
 *@date 2021-11-20
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp
{
    public partial class CustomValidSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CusName_ServerValidate(
            object source, ServerValidateEventArgs args)
        {
            args.IsValid = (args.Value.Length <= 20);
        }//CusName_ServerValidate()

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                LbResult.Text = "<○> All input can be accepted.";
            }
            else
            {
                LbResult.Text = "<！> Your input cannot be accepted.";
            }
        }//BtnSubmit_Click()

    }//class
}

/*
【Note】Client-side / Server-side
@see ResultFile / CustomValid_server.jpg
@see ResultFile / CustomValid_JavaScript.jpg

＊Server-side:
Server-side was executed CustomValidator with
EnableClientValidation="false".
There was "<！> Your input cannot be accepted."

＊Client-side: JavaScript ValidationFunction
There was not "<！> Your input cannot be accepted."
But I knew that the validation was executed in JavaScript too.
*/