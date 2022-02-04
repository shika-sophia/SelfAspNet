/**
 *@title SelfAspNet / SampleAsp / NT07_StateVariable
 *       / ViewState / HighLowNumber.aspx.cs
 *@target HighLowNumber.aspx
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第７章 状態管理 State Variable (=状態変数)
 *         7.1 ViewState / p336 / List 7-1
 *         ViewState機能を利用した数当てゲーム
 *         
 *@subject 「.aspx」ASPページ
 *          TextBox ID="txtNum" Columns="3"
 *          Button  ID="btnSend"
 *          Label   ID="lblResult"
 *
 *@subject 「.aspx.cs」イベントハンドラー
 *          ＊Page_Load()
 *          bool Page.IsPostBack 
 *              //true: first times ONLY / false: more second times
 *          System.Web.UI.StateBag;
 *          StateBag Control.ViewState
 *          object   ViewState[string key] = object value;
 *          void ViewState.Clear();
 *          
 *          ＊btnSend_Click()
 *          int  Int32.Parse(string);
 *          bool Int32.TryParse(string, out object)
 *          
 *          TextBox this.txtNum;
 *          Label   this.lblResult;
 *          string  TextBox.Text;
 *          string  Label.Text;
 *          
 *          System.Drawing.Color;
 *          Color   lblResult.ForeColor = Color.Green;
 *
 *@see HighLowNumber.jpg
 *@author shika
 *@date 2022-02-04
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT07_StateVariable.ViewState
{
    public partial class HighLowNumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var random = new Random();
                ViewState["count"] = 0;
                ViewState["answer"] = random.Next(100) + 1;
            }
        }//Page_Load()

        protected void btnSend_Click(object sender, EventArgs e)
        {
            //---- local variable definition ----
            int count = Int32.Parse(ViewState["count"].ToString());
            int answer = Int32.Parse(ViewState["answer"].ToString());
            int inputNum;
            bool isNum = Int32.TryParse(txtNum.Text, out inputNum);

            //---- judge input as number ----
            if (!isNum)
            {
                lblResult.ForeColor = Color.Red;
                lblResult.Text = "＜!＞ Please input Number ONLY.";
                txtNum.Text = "";
                return;
            }

            //---- judge input in range ----
            if (inputNum <= 0 || 100 < inputNum)
            {
                lblResult.ForeColor = Color.Red;
                lblResult.Text = "＜!＞ Please input in range [ 1 - 100 ].";
                txtNum.Text = "";
                return;
            }

            //---- allow input and increment count ----
            ViewState["count"] = ++count;

            //---- judge inputNum by comparing with the answer ----
            if (answer == inputNum)
            {
                lblResult.ForeColor = Color.Green;
                lblResult.Text =
                    $"{count} Trial: Your input '{inputNum}' was correct! <br />" +
                    $"The answer was '{answer}'.";
                ViewState.Clear();
            }
            else
            {
                lblResult.ForeColor = Color.Black;

                if (answer < inputNum)
                {
                    lblResult.Text =
                        $"{count} Trial: Your input '{inputNum}' was higher than the answer. ";
                }
                else
                {
                    lblResult.Text =
                        $"{count} Trial: Your input '{inputNum}' was lower than the answer. ";
                }
            }

        }//btnSend_Click()
    }//class
}