/**
 *@title SelfAspNet / SampleAsp / NT11_AjaxDevelop / 
 *       AjaxExtentionsDiv / AjaxUpdatePanelSample.aspx.cs
 *@target AjaxUpdatePanelSample.aspx
 *@based  NT04_DataBindControl / GridViewSample.aspx
 *source  SelfAspDB / Album_tb
 *@reference  NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content NT 第11章 Ajax開発 / 11.2 AJAX Extentions / p572
 *         ■ ASP.NET AJAX Extentions 
 *         ・Ajaxの定型的な基本機能を ASP.NETに導入するためのコントロール
 *         ・ASP.NET プロジェクトは、デフォルトで 
 *           VSツールボックス内 [AJAX Extentions]項目に用意されている。
 *           (特別なインストールをしなくても利用可)
 *         
 *         ◆AJAX Extentions コントロール
 *         ScriptManager  JavaScriptの解析に必要なコントロール
 *         ScriptManagerProxy 〔下記〕
 *         UpdatePanel    部分的な更新を可能にする
 *         UpdateProgress 非同期通信中の「通信中」メッセージ・進捗状況の表示
 *         Timer          一定時間の間隔で実行するスケジュール機能
 *
 *@subject ScriptManager コントロール
 *         ・AJAX Extentionsに限らず、JavaScriptを扱う場合は
 *           各ページに１つ必ず必要。
 *         ・マスターページを利用する場合は マスターページに記述
 *           各ページには不要。(複数不可)
 *         ・ScriptManagerProxy:
 *           マスターページに ScriptManagerを記述し、
 *           各ページから、ScriptManagerにアクセスする必要がある場合
 *           各ページには ScriptManagerProxyを用いる。proxy [英] 代理。
 *         
 *@subject UpatePanel コントロール
 *         ・部分的な更新を定義するコントロール
 *         ・<asp:UpdatePanel>
 *             └ <ContentTemplate> 部分的な更新を行う サーバーコントロール / DataSourceコントロールを配置
 *             |                   配下のコントロールでポストバックが発生すると更新
 *             └ Triggers=""      ポストバック・イベントを指定して更新
 *               AsyncPostBack="" 非同期ポストバック(= Ajax通信) のイベント 
 *               UpdateMode=""    Always (=常時) | Conditional (=条件下) 
 *                                UpdatePanelをネストした場合の挙動
 *                                ・親 Conditinal + 親 ポストバック => 両方更新
 *                                ・親 Conditinal + 子 ポストバック => 子のみ更新
 *                                ・UpdateMode="" に関係なく 子は必ず更新
 *                                
 *@NOTE【実行】AjaxUpdatePanelSample.aspx
 *      Grid内のソート (= 項目行のリンクをクリック)
 *      -> ソートにより順序変化
 *      -> Page Loaded: 更新日時に変化はないことを確認
 *      =>〔AjaxUpdatePanel_withSorted.jpg〕
 *
 *@see NT04_DataBindControl / GridViewSample.aspx
 *@see AjaxUpdatePanel_withSorted.jpg
 *@copy AjaxDevelop_analysis.txt
 *@author shika
 *@date 2022-05-25
 */

using System;

namespace SelfAspNet.SampleAsp.NT11_AjaxDevelop.AjaxExtentionsDiv
{
    public partial class AjaxUpdatePanelSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl.Text = $"Page Loaded: {DateTime.Now.ToString()}";
        }

        protected void grid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }//class
}