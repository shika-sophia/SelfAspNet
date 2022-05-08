/** <!--
 *@title NT08_SelfAspNetIdentity / SampleUser /
 *       CustomControlDiv / CustomLabelSample.cs
 *@target CustomAspSample.aspx
 *@inherits WebControl.Label
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第10章 10.2 CustomControl / p492 / List 10-3
 *
 *@prepare 【参照追加】System.Design
 *
 *@subject ◆実装手順
 *　       VS フォルダ 右クリック -> [新しい項目]
 *　       -> Visual C# / Web / Webフォームサーバーコントロール -> [OK]
 *　       
 *@subject ◆Attribute / CustomControlの属性 〔p492 | NT158〕
 *         ＊Class
 *         [DefaultEvent(string)]
 *         [DefaultProperty(string)]
 *         [Designer(Type)]      デザインViewで利用するDesignクラスの型
 *         [ToolboxData(string)] デザインViewにドラッグ時に自動生成されるタグ
 *                               {0}: namespaceが埋め込まれるプレースホルダー
 *         [ValidationProperty(string)] 検証コントロールがチェックするプロパティ名
 *         
 *         ＊Property
 *         [Bindable(bool)]   データバインド可能か
 *         [Browsable(bool)]  プロパティウインドに表示するか
 *         [Category(string)] プロパティウインド上での分類
 *           Action | Appearance | Behavior | Data | Default 
 *           | Design | Format | Layout など
 *         [DegaultValue(T)] 
 *         [Description(string)]
 *         [EditorBroesable(bool)] プロパティ名を IntlliSenseで表示するか
 *         [Localizable(bool)]     ローカライズ可能か
 *         [UrlProperty(string)]   文字列プロパティが URL値を表すか
 *
 *@subject 「.cs」CustomLabelSample : Label
 *          ＊WebControl.Labelを継承
 *          ＊PropertyNameプロパティを定義
 *          ＊Label.Textプロパティは不要なので無効化
 *          ＊RenderContents(HtmlTextWriter)で出力内容を定義
 *          
 *          ◆manager, user は第８章〔NT 125〕
 *          ◆プロパティ値の取得
 *          typeof(クラス名).GetProperty(プロパティ名).GetValue(オブジェクト)
 *          
 *          Type typeof(T)     T: staticのみ、インスタンス不可 〔NT93〕
 *          Type obj.GetType() objの型に関係なく格納されているオブジェクトの型を取得
 *          PropertyInfo type.GetProperty(string) Typeオブジェクトからプロパティ情報を取得
 *          object       propertyInfo.GetValue(object) 引数で指定したプロパティの値を取得
 *                
 *@subject 「.aspx」ASPページのデザインView時 (SourceViewでは登場しない)
 *          ツールボックスに登場する
 *          NT08_AspNetIdentity コンポーネント 
 *            └ CustomLabelSample
 *            
 *          <%@ Register assembly="NT08_AspNetIdentity"
 *               namespace="NT08_AspNetIdentity.SampleUser.CustomControlDiv"
 *               tagprefix="cc1" %>
 *                
 *          <cc1:CustomLabelSample ID="CustomLabelSample1" runat="server"
 *              ProfileName="Url"> //〔8.6 Profile〕
 *          </cc1:CustomLabelSample>

 *@subject 「Web.config」 /CustomControlDiv内
 *         〔8.3.3 アクセス可否 Web.config | p382〕
 *          <authorization>
 *            └ <allow> アクセスを許可
 *            └ <deny>  アクセスを禁止
 *                └string user="" ユーザー名
 *                  「?」匿名(未ログイン)
 *                  「*」すべてのユーザー
 *         
 *         <?xml version="1.0" encoding="utf-8"?>
 *         <configuration>
 *           <location path="CustomAspSample.aspx">
 *             <system.web>
 *               <authorization>
 *                 <deny users="?"/>
 *               </authorization>
 *             </system.web>
 *           </location>
 *         </configuration>
 *         
 *@subject 「~/App_Start/Startup.Auth.cs」
 *          初期化ファイルでアクセス拒否された場合、Loginページにリダイレクトする設定
 *          
 *          app.UseCookieAuthentication(new CookieAuthenticationOptions
 *          {   ...
 *              LoginPath = new PathString("/Account/Login"),
 *
 *@subject  【実行】CustomAspSample.aspx -> リダイレクト「Login.aspx」
 *           -> Login.aspxでログインする。
 *                Email: profile@sample.jp
 *                pass:  Profile999-
 *                
 *@see CustomLabelSample.jpg
 *@see CustomAspSample.jpg
 *@see CustomAspSample.aspx
 *@copy SelfAspNet / SampleAsp / NT10_FlagmentObject / CustomControl.txt
 *@author shika
 *@date 2022-05-04, 05-08
 * -->
 */
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using NT08_AspNetIdentity.Models;
using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NT08_AspNetIdentity.SampleUser.CustomControlDiv
{
    [Designer(typeof(System.Web.UI.Design.ControlDesigner))]
    [DefaultProperty("ProfileName")]
    [ToolboxData("<{0}:CustomLabelSample runat=server></{0}:CustomLabelSample>")]
    public class CustomLabelSample : Label
    {
        [Bindable(true)]
        [Category("Behavior")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("プロファイル名")]
        public string ProfileName
        {
            get
            {
                String s = (String)ViewState["ProfileName"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["ProfileName"] = value;
            }
        }

        [Browsable(false)]
        public override String Text
        {
            get { return ""; }
            set { throw new NotSupportedException(); }
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            HttpContext cx = this.Context;
            if(cx != null)
            {
                ApplicationUserManager manager =
                    Context
                    .GetOwinContext()
                    .GetUserManager<ApplicationUserManager>();
                ApplicationUser user = manager.FindByName(
                    Context.User.Identity.Name);

                writer.Write(String.Format("あなたのサイトは [{0}] です。",
                    typeof(ApplicationUser)
                    .GetProperty(ProfileName)
                    .GetValue(user)));
            }
            else
            {
                writer.Write($"[{this.ID}]");
            }
        }//RenderContents()
    }//class
}
