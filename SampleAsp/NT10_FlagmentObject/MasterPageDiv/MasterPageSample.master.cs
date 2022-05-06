
/** <!--
 *@title SelfAspNet / SampleAsp / NT10_FlagmentObject
 *       / MasterPageDiv / MasterPageSample.master
 *@target MasterContentSample.aspx
 *@inherits System.Web.UI.MasterPage
 *@datasource SelfAspDB / Album_tb, Sitemap_tb
 *@reference NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content NT 第10章 10.3 Master Page / p498
 *         ◆マスターページ
 *         ・アプリケーション共通のレイアウトを定義
 *         ・開発生産性: 開発者がコンテンツ処理に集中できる
 *         ・保守性: レイアウト変更時に各ページ全てを変更しなくて済む
 *                  (マスターページのみ変更すればいい)
 *         ・ユーザー利便性: ページ構造が統一しているので解りやすい。
 *         ・<%@ Master ... %>で マスターページの挙動を定義 (@Pageと同様)
 *         ・<%@ Page ... %> MasterPageFile=""で マスターページと関連付け
 *         ・マスターページ   <asp: ContentPlaceHolder> ID="" と
 *           コンテンツページ <asp: Content> ContentPlaceHolderID="" とが
 *           必ず １:１の対応関係にある。
 *           複数のプレースホルダーがある場合も同様
 *         ・コンテンツページからマスターページの動的変更も可
 *         ・マスターページのネストも可
 *         ・マスターページにDB連携して コンテンツに合わせた<meta><title>などを生成できる
 *
 *@subject「.master」
 *         [新しい項目の追加] -> Visual C#/Web/WebFormsマスターページ
 *         
 *         <%@ Master ... %>
 *             //MasterPageにおける <%@ Page ... %>
 *         <asp:ContentPlaceHolder ID="content1" runat="server">
 *             //コンテンツが挿入される場所
 *         </asp:ContentPlaceHolder>
 *          
 *@subject <asp:Image>
 *           ImageUrl="http://www.wings.msn.to/image/wings.jpg"
 *              ↓
 *           ImageUrl="~/Image/wings.jpg" 上記よりコピーして /Image に保存
 *           
 *@subject 「.aspx」コンテンツページ
 *          [新しい項目の追加] -> Visual C#/Web/マスターページを含むWebForms
 *          -> 「.master」を指定 -> [ OK ]
 *       
 *          <%@ Page ... %>
 *            string Title="" 
 *              コンテンツページには<title>が存在しない。省略時はMasterPageの<title>を表示
 *            string MasterPageFile=""   「.master」のpath
 *            
 *          <asp:Content ID="ContentHead"
 *             ContentPlaceHolderID="head" runat="server">
 *          </asp:Content>
 *          
 *          <asp:Content ID="Content1"
 *             ContentPlaceHolderID="content1" runat="server">
 *             // [NT04/GridViewSample.aspx]をコピー
 *             // <Grid PageSize="4 />, オートフォーマットOFF
 *          </asp:Content>
 *
 *          => 〔see MasterPage_withContentSample.jpg〕
 *          
 *@subject 「.aspx.cs」コンテンツページからマスターページの内容を変更する
 *          プログラムによる動的変更 => 「.aspx.cs」Page_Load()で定義
 *
 *          MasterPage Page.Master 〔NT86〕
 *            System.Web.UI.MasterPageクラスは Pageクラスのサブセット(=部分的機能)
 *          Control control.FindControl(string id) 〔NT44〕
 *            引数IDのコントロールで利用している 子コントロールを取得
 *            Controlオブジェクトは全てのコントロールのルートクラス
 *            適切なクラス(利用しているクラス)にキャストして使う。
 *          string  Image.ImageUrl
 *          
 *          => 〔see MasterPage_modifiedByContent.jpg〕
 *
 *@subject 「.master.cs」マスターページに DB連携し、<meta><title>を生成
 *          Page.Header.Title       <title>を埋め込み
 *          Page.Header.Keywords    <meta keywords="">を生成
 *          Page.Header.Description <meta descritiom="">を生成
 *          
 *          sds.SelectParameters 〔NT49〕
 *          sds.SelectParameters.Add("url",
 *               Request.AppRelativeCurrentExecutionFilePath);
 *          //現在ページのURLで Sitemapテーブルから検索
 *          //Sitemap_tbに 現在ページ(コンテンツページ)は未登録のため
 *          //sds.SelectParameters.Add("url", "~/Chap10/Content.aspx");に置換
 *                 
 *          IDataReader - SqlDataReaderクラス 〔NT59〕
 *                 
 *          => 〔see MasterPage_withMetaFromSqlData.jpg〕
 *
 *@see MasterPage_withContentSample.jpg
 *@see MasterPage_modifiedByContent.jpg
 *@see MasterPage_withMetaFromSqlData.jpg
 *@author shika
 *@date 2022-05-05
 * -->
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT10_FlagmentObject.MasterPageDiv
{
    public partial class MasterPageSample : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            sds.SelectParameters.Clear();
            sds.SelectParameters.Add("url", "~/Chap10/Content.aspx");

            using (var reader = (IDataReader)
                sds.Select(DataSourceSelectArguments.Empty))
            {
                if (reader.Read())
                {
                    Page.Header.Title = reader["title"].ToString();
                    Page.Header.Keywords = reader["keywd"].ToString();
                    Page.Header.Description = reader["description"].ToString();
                }
                else
                {
                    Response.Write("MasterPage/reader.Read(): false");
                }

                reader.Close();
            }//using
        }//Page_Load()
    }//class
}