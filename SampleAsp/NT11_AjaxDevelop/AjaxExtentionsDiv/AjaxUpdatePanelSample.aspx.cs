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
 *         ・利用できないコントロール
 *         × TreeView, Menu, FileUpload, HtmlInputFile
 *         × (GridView) EnableSortingAndPagingCallbacks="True"のみ
 *         ・Requestデータが部分化されているわけではないことに注意
 *           ViewStateは、毎回ページ全体のデータがサーバーに送られている。
 *           
 *         ・<asp:UpdatePanel>
 *             └ <ContentTemplate> 部分的な更新を行う サーバーコントロール / DataSourceコントロールを配置
 *             |                   配下のコントロールでポストバックが発生すると更新
 *             └ <Triggers>        ポストバック・イベントを指定して更新
 *             |   └ <asp:AsyncPostBack> 非同期ポストバック(= Ajax通信) のイベント 
 *             |        └ ControlID="" 更新するコントロール名
 *             |        └ EventName="" トリガーとなるイベント名
 *             |             Tick | Init | Load | Unload | PreRender
 *             |             | DataBinding | Dispose
 *             |
 *             └ UpdateMode=""    Always (=常時) | Conditional (=条件下) 
 *                                UpdatePanelをネストした場合の挙動
 *                                ・親 Conditinal + 親 ポストバック => 両方更新
 *                                ・親 Conditinal + 子 ポストバック => 子のみ更新
 *                                ・UpdateMode="" に関係なく 子は必ず更新
 *
 *@subject UpdateProgressコントロール
 *         ・非同期通信中の「通信中」メッセージ, 進捗状況の表示。
 *         
 *         <asp:UpadataProgress>
 *           └ <ProgressTemplate>内 Label, Imageなど表示系コントロールを配置
 *           └ AssociatedUpdatePanel="" デフォルト: 全ての UpdatePanel
 *           └ DisplayAfter=""          非同期通信の何ミリ秒後に表示するか / デフォルト: 500
 *           |                          ※ 0: 即時表示。 短時間で処理が完了すると画面のチラつきに見えるので注意
 *           └ DynamicLayout=""         通信メッセージを動的にレイアウトするか / デフォルト: true
 *         
 *@subject Timer コントロール
 *         ・<asp:UpdatePanel>内 <Triggers>
 *             <asp:AsyncPostBackTrigger> 非同期ポストバック(= Ajax通信) のイベント 
 *               ContrrolID="" 更新するコントロール
 *               EventName=""  トリガーとなるイベント
 *         ・<asp:Timer> Interval=""
 *         
 *         ・「.aspx.cs」イベントハンドラー
 *           xxxx.DataBind() 必須 / xxxx: 更新するコントロールのID
 *           
 *           ※GridViewなどデータバインドコントロールは Page_Load()時に
 *           自動的にデータバインドが行われるが、
 *           UpdatePanlの部分更新の領域は自動でバインドされない。
 *           <asp:Timer>利用時には必ず明示的に xxxx.DataBind()をしないと
 *           自動更新は表示されない。
 *           
 *           ※ViewStateMode="Disable"なら、明示的に xxxx.DataBind()をしなくても
 *           自動更新される。
 *           
 *@NOTE【実行】AjaxUpdatePanelSample.aspx
 *      Grid内のソート (= 項目行のリンクをクリック)
 *      -> ソートにより順序変化
 *      -> Page Loaded: 更新日時に変化はないことを確認済
 *      
 *@NOTE【実行】UpdateProgressを追加
 *      ソート時に 通信中の「.gif」が表示されるかを確認
 *      =>〔AjaxUpdatePanel_withUpdateProgress.jpg〕
 *      
 *@NOTE【実行】Timerを追加
 *      実行中は サーバーエクスプローラが開いていないため、
 *      実行中に右メニュー欄の ソリューションエクスプローラを開き、
 *      「App_Data / SelfAspDB.mdf」から サーバーエクスプローラを開く。
 *      Album_tb -> [新しいクエリ] -> UPDATE文実行
 *      
 *      -- NT11_AjaxDevelop / AjaxExtentions / AjaxUpdatePanel.aspx
 *      -- Timer更新のテストのため、Album_tbデータを変更
 *      UPDATE Album 
 *        SET comment=N'ピアノ部屋。毎日練習しています。バッハが好きです。'
 *        WHERE Id='S0003';
 *      =>〔SampleSql / Album_tb.sql〕
 *        
 *      DB変更後に 自動更新されるかを確認済。10秒おきにチェックしている。
 *      (Page Loaded: 更新日時には変更なし -> 部分的に更新されているから)
 *      
 *@see NT04_DataBindControl / GridViewSample.aspx
 *@see AjaxUpdatePanel_withUpdateProgress.jpg
 *@see SampleSql / Album_tb.sql
 *@copy AjaxDevelop_analysis.txt
 *@author shika
 *@date 2022-05-25, 05-26
 */

using System;
using System.Threading;

namespace SelfAspNet.SampleAsp.NT11_AjaxDevelop.AjaxExtentionsDiv
{
    public partial class AjaxUpdatePanelSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //---- UpdatePanel ----
            lbl.Text = $"Page Loaded: {DateTime.Now.ToString()}";

            //---- UpdateProgress ----
            if (Page.IsPostBack)
            {
                Thread.Sleep(3000);
            }
            
            //---- Timer ----
            grid.DataBind();
        }

        protected void grid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }//class
}