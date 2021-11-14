/**
 * @title SelfAspNet / SampleAsp / AS02ServerControl / ListCtrl.aspx.cs
 * @reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 * @content 第３章 ListControlの EventHandler / p84 / List 3-1, 3-2
 * @subject RadioButtonList -> 単一選択の SelectedIndexChanged
 * @subject CheckBoxList    -> 複数選択の SelectedIndexChanged
 *          ◆System.Web.UI.WebControls.ListControl
 *          int      list.SelectedIndex
 *          ListItem list.SelectedItem
 *          T        list.SelectedValue
 *          
 *          ◆System.Web.UI.WebControls.ListItem 
 *          bool listItem.Selected
 *          T    listItem.Value
 *          
 * @see ResultFile / ListCtrl.jpg
 * @author shika
 * @date 2021-11-15
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.AS02ServerControl
{
    public partial class ListCtrlSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void listCntl_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelFood.Text = $"{listCtrl.SelectedValue}";
            //LabelFood.Text = $"{listCtrl.Item[SelectedIndex].Value}";
            //LabelFood.Text = $"{listCtrl.SelectedItem.Value}";

        }

        protected void listCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(ListItem item in listCheck.Items)
            {
                if (item.Selected)
                {
                    Response.Write($"{item.Value}, ");
                }
            }
        }
    }//class
}

/*
【考察】Response.Write()
@see ResultFile / Listctrl.jpg

全ての表示要素の一番上に表示される。
 */