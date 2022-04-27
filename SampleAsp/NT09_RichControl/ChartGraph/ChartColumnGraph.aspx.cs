/** <!--
 *@title SelfAspNet / SampleAsp / NT09_RichControl / 
 *       ChartGraph / ChartColumnGraph.aspx.cs
 *@target ChartColumnGraph.aspx
 *@source SelfAspDB / Stock_tb
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第９章 Rich / 9.5 ChartControl / p472 / 
 *@subject ColumnGraph(棒グラフ)を表示 DB連携
 *
 *@prepare Stock_tb
 *         CREATE TABLE [dbo].[Stock]
 *         (
 *            [brand] INT NOT NULL , //銘柄コード(会社コード)
 *            [dating] DATE NOT NULL,//日付 
 *            [opening] INT NOT NULL,//始値
 *            [high] INT NOT NULL,   //最高値
 *            [low] INT NOT NULL,    //最安値
 *            [closing] INT NOT NULL,//終値 
 *            [volume] INT NOT NULL, //取引高
 *            PRIMARY KEY ([brand], [dating])　//複合 primary key
 *          )
 *         
 *          INSERT INTO Stock ...〔配布サンプル [SelfAsp.mdf]をコピー〕
 *@subject 「.aspx」
 *         データ -> Chartコントロール
 *         <Chart>
 *           <Series>
 *             ChartArea="ChartArea1"
 *             ChartType="Column"    //グラフの種類
 *             XValueMember="dating" //X軸の値 (縦軸)
 *             YValueMember="volume" //Y軸の値 (横軸)
 *           <Title>
 *             Name="" //このコントロール(タグ)の名前
 *             Text="" //表示するテキスト
 *@subject <SqlDataSource>
 *           SelectCommand="
 *             SELECT [dating], [opening], [high], [low], [closing], [volume] 
 *               FROM [Stock] 
 *               WHERE ([brand] = @brand) 
 *               ORDER BY [dating]">
 *           <SelectParameters>
 *             <asp: Parameter 
 *               DefaultValue="28710" //固定値
 *               Name="brand" 
 *               Type="Int32" />
 *      
 *@see SampleSql / Stock_tb.sql
 *@see ChartColumnGraph
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
    public partial class ChartColumnGraph : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}