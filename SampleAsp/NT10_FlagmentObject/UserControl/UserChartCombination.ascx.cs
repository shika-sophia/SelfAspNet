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
        public int Brand 
        {
            get { return Int32.Parse(sds.SelectParameters["brand"].DefaultValue); }
            set { sds.SelectParameters["brand"].DefaultValue = value.ToString(); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            chartComb.Titles[0].Text = $"Brand: { Brand.ToString()} / 今月の株価情報";
        }
    }//class
}