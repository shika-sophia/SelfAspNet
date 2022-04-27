/** <!--
 *@title SelfAspNet / SampleAsp / NT09_RichControl /
 *       ChartGraph / ChartCombinationGraph.aspx.cs
 *@target ChartCombinationGraph.aspx
 *@source SelfAspDB / Stock_tb
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 9.5.3 複合グラフを作成 / p478
 *@subject「.aspx」複合グラフ
 *         ・１つの ChartAreaに ２つの Seriesを乗せる
 *             YAxisType="" Primary | Secondary 
 *               //どちらのY軸の値を利用するか
 *         ・<ChartArea>内 <Axis> を定義//軸
 *         ・<Axis> Maximum="", Minimum="" を調整して、グラフが重ならないようにする
 *         
 *         <Chart>
 *           <Series>
 *             <asp:Series Name="Series1"
 *               ChartArea="ChartArea1"
 *               ChartType="Column"    //棒グラフ
 *               XValueMember="dating"
 *               YValueMembers="volume"
 *               YAxisType="Secondary"></asp:Series>
 *            <asp:Series Name="Series2"
 *               ChartArea="ChartArea1"
 *               ChartType="Candlestick"  //ろうそくグラフ
 *               XValueMember="dating"
 *               YValueMembers="high,low,opening,closing"
 *                  //複数指定可。「,」区切り
 *               YValuesPerPoint="4" ></asp:Series>
 *          </Series>
 *          <ChartAreas>
 *            <asp:ChartArea Name="ChartArea1">
 *               <AxisX Title="日付"></AxisX>
 *               <AxisY Maximum="1600" Minimum="800" Title="株価"></AxisY>
 *               <AxisY2 Maximum="2000" Minimum="200" Title="出来高"></AxisY2>
 *            </asp:ChartArea>
 *          </ChartAreas>
 *          <Titles>
 *            <asp:Title Name="Title1" Text="今月の株価情報">
 *            </asp:Title>
 *         </Titles>
 *   
 *@see ChartColumnGraph.aspx.cs
 *@see ChartCombinationGraph.jpg
 *@author shika
 *@date 2022-04-27
 * -->
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT09_RichControl.ChartGraph
{
    public partial class ChartCombinationGraph : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }//class
}