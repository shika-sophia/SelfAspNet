/** <!--
 *@title SelfAspNet / SampleAsp / NT03_ServerControl / ValidSample.aspx.cs
 *@target ValidSample.aspx 
 *@target ValidSample_Style.css
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第３章 ServerControl / 3.4 ValidateControl / p101 /
 *         fig 3-18, List 3-7, 3-8
 *@subject 検証コントロールの実装例
 *
 *@subject 3.4.1 検証コントロールのための「jQuery」準備 〔p100〕
 *         ◆jQuery
 *         ＊ValidControlは内部的に jQueryを利用しているので、
 *         ここを動作させるには、事前にインストールが必要。
 *         
 *         ＊jQueryをインストール〔p99 | NT20〕
 *         PM> Install jquery
 *         => 「~/Scripts」に jquery-x.x.x.xxx.js 
 *         
 *         ＊[Global.asax]も編集して、
 *         jQueryを Startupで loadする設定にする。
 *
 *@subject CDN: Contents Delivery Network
 *         JavaScript, CSS, 画像などコンテンツの配信に最適化されたネットワークのこと
 *         
 *@subject ScriptManagerコントロール〔11.2.1〕
 *         bool EnableCdn=""
 *         string CdnPath=""
 *         string CdnDebugPath=""
 *         
 *         ScriptResourceMapping 
 *              ScriptManager.ScriptResourceMapping
 *         void ScriptManager.ScriptResourceMapping.
 *                AddDefinition(
 *                  string name,
 *                  bool 〔System.Reflection.Assembly,
 *                  ScriptResourceDefinition)
 *         
 *@subject ScriptResourceDefinitionクラス System.Web.UI
 *         new ScriptResourceDefinition() 
 *         {
 *           string this.Path         ローカルパス
 *           string this.DebugPath    ローカルパス(デバッグモード)
 *           string this.CdnPath      CDNのURL
 *           string this.CdnDebugPath CDNのURL(デバッグモード) 
 *         }
 *
 *@subject 「Web.config」デバッグモードを変更する場合のみ修正 / デフォルト true
 *          <compilation debug="true" targetFramework="4.8" /> 
 *             ↓
 *          <compilation debug="false" targetFramework="4.8" />
 *          
 *@see ~/Global.asax.cs
 *@see ResultFile / ValidSample.jpg
 *@see ResultFile / ValidSample_Summary.jpg
 *@author shika
 *@date 2021-11-19, 2022-05-11
 * -->
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT03_ServerControl
{
    public partial class ValidSample : System.Web.UI.Page
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

/*
【考察】行頭の半角スペース
行頭の半角スペースは無視されるようなので、
必要なら「@thinsp;」で半角スペースを挿入。

【考察】<!>表示
@see ResultFile / ValidSample.jpg
ErrorMessage=""内の <!>はタグと認識されて表示されない模様。
「&lt;」「&gt;」に替えても同様。
<！> <>内の文字をマルチバイト(全角)にすると表示される。

Labelの「<○>」は表示可

【考察】範囲検証前のデータ型検証
RangeValidatorの前に下記を置いていたが、
Rangeだけでも、データ型が異なる入力値があると、
エラーメッセージが出るので削除。
<!-- <asp:CompareValidator ID="cmpWeight" runat="server"
    ControlToValidate="txtWeight"
    CssClass="validSample"
    Operator="DataTypeCheck"
    Type="Integer"
    ErrorMessage="Body Weight should be input by Number. "
    SetFocusOnError="true"
    Display="Dynamic">
</asp:CompareValidator> -->

【考察】ValidationSummary
ShowMessageBox="true": メッセージダイアログの後、ページにも表示される。
ShowSummary="": ページ表示はデフォルトで trueの様子。
*/