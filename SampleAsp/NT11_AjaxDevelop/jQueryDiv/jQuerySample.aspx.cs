/**
 *@title SelfAspNet / SampleAsp / NT11_AjaxDevelop
 *       jQueryDiv / jQuerySample.aspx.cs
 *@target jQuerySample.aspx
 *@source https://wings.msn.to/books/{0}/{0}.jpg | {0}: isbn
 *
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content jQueryの利用
 *
 *@prepare 事前にインストールが必要だが、ValidatorControlで実行済
 *@prepare jQueryをインストール
 *         PM> Install jquery
 *         -> 「~/Scripts」に jquery-x.x.x.xxx.js 
 *         => 〔NT03_ServerControl / ValidSample.aspx.cs〕
 *         
 *@prepare 「Global.asax」Application_Start()
 *          => jQueryの保存場所を登録 〔同上 | p100 | NT20〕
 *          
 *@subject
 *
 *@see jQuerySample_withFadeout.jpg
 *@author shika
 *@date
 */
using System;

namespace SelfAspNet.SampleAsp.NT11_AjaxDevelop.jQueryDiv
{
    public partial class jQuerySample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }//class
}