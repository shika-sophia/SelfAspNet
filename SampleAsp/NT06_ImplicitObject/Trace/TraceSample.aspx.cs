/** <!--
 *@title SelfAspNet / SampleAsp / NT06_ImplicitObject
 *       / Trace / TraceSample.aspx.cs
 *@target TraceSample.aspx
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第６章 6.3 Trace
 *         Trace機能: アプリケーションの状態を記録する
 *                    実行プロセス、イベント、変数の値、処理時間など
 *                    
 *@subject 「.aspx」@Page ページ単位でTraceを有効にする
 *          <%@ Page ...
 *                Trace="true" 
 *                TraceMode="SortByTime" %>
 *                   SortByTime (=Default)
 *                   SortByCategory
 *                   
 *@subject 「Web.config」アプリケーション全体でTraceを有効にする
 *          <system.web> 
 *          ...
 *              <trace enable=""     Trace有効か                   DEFAULT false
 *                     localOnly=""  TraceViewer をローカルのみで利用       true
 *                     mostRecent="" requetLimit=""を越えた古いTraceの破棄  false
 *                     pageOutput="" 個別ページの末尾に Trace情報を表示      false
 *                     requestLimit="" サーバー上で維持するTrace情報の最大値 
 *                                     DEFAULT 10/最大 10,000
 *                     traceMode="" SortByTime (=DEFAULT) | SortByCategory
 *                     writeToDiagonosticTrace="" 
 *                         Trace情報を System.Diagonostics トレース・インフラに転送するか false
 *               />
 *          </system.web>
 *          
 *@subject Trace Viewer: アプリケーションで蓄積した Trace情報をリスト表示
 *         上記「Web.config」<trace>でアプリケーション全体に Trace有効を設定した場合のみ
 *         https://localhost:44380/<App_Root名>/Trace.axd でアクセス
 *         
 *         Trace.asd: HTTP Handlarを用いた仮想的な URL
 *                    (サーバー上に 実際の「Trace.asd」ファイルが存在する必要はない)
 *                    ASP.NETが　このURLを Requestされると、
 *                    System.Web.Handlars.TraceHandlarクラスを呼出、
 *                    Trace出力を生成して、表示する。
 *                    
 *@subject Traceにメッセージを追加
 *         「.aspx.cs」Page_Load()
 *          TraceContext Page.Trace
 *          void         Trace.Write(string); Trace情報に表示
 *          void         Trace.Warn(string);  赤字で表示
 *          
 *@see TraceSampleResult.txt
 *@author shika
 *@date 2022-02-03
 * --> 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT06_ImplicitObject.Trace
{
    public partial class TraceSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtName.Text = "Shika";
            Trace.Write($"{txtName.Text} (通常)");
            Trace.Warn($"{txtName.Text} (警告)");
        }
    }//class
}