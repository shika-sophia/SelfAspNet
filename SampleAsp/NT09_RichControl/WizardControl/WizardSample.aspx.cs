/**
 *@title SelfAspNet / SampleAsp / NT09_RichControl / WizardControl
 *@target WizardSample.aspx
 *@source AspNetDB / Quest_tb
 *@style ValidStyle.css
 *
 *@reference NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content NT 第９章 Rich / Wizard Control / p449 / List 9-7, 9-8
 *@subject Wizard Control サンプルコード
 *
 *@see SqlSample / Quest_tb.sql
 *@see WizardSample.jpg
 *@author shika
 *@date 2022-04-18
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT09_RichControl.WizardControl
{
    public partial class WizardSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void wiz_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            if (!Page.IsValid)
            {
                e.Cancel = true;
            }
        }//wiz_NextButtonClick()

        protected void wiz_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            if (Page.IsValid)
            {
                sdsWiz.Insert();
            }
            else
            {
                e.Cancel = true;
            }
        }//wiz_FinishButtonClick()

        protected void sdsWiz_Inserting(object sender, SqlDataSourceCommandEventArgs e)
        {
            e.Command.Parameters["@name"].Value = txtName.Text;
            e.Command.Parameters["@email"].Value = txtEmail.Text;
            e.Command.Parameters["@purpose"].Value = dropPurpose.SelectedValue;
            e.Command.Parameters["@evalute"].Value = radioEvalute.SelectedValue;
            e.Command.Parameters["@free"].Value = txtFree.Text;
            e.Command.Parameters["@mailNews"].Value = chkMailNews.Checked;
        }//sdsWiz_Inserting()

        protected void sdsWiz_Inserted(object sender, SqlDataSourceStatusEventArgs e)
        {
            if(e.Exception != null)
            {
                e.ExceptionHandled = true;
                ltlResult.Text = "＜！＞ エラーが発生しました。";

                //メール送信コード
            }
        }//sdsWiz_Inserted()
    }//class
}