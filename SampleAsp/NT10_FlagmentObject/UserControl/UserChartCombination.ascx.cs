/*
 *@see   ChartCombWithSelectBrand.aspx.cs
 *@based NT09_RichControl / ChartGraph / ChartCombinationGraph.aspx
 *
 */
using System;
using System.Web.UI.DataVisualization.Charting;

namespace SelfAspNet.SampleAsp.NT10_FlagmentObject.UserControl
{
    public partial class UserChartCombination : System.Web.UI.UserControl
    {
        public string Brand 
        {
            get { return sds.SelectParameters["brand"].DefaultValue; }
            set { sds.SelectParameters["brand"].DefaultValue = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            chartComb.Titles[0].Text = $"Brand: {Brand} / 今月の株価情報";
        }
    }//class
}