/** <!--
 *@title SelfAspNet / SampleAsp / NT05_DataSourceControl / NeatedGrid.aspx.cs
 *@target NeatedGrid.aspx
 *@source SelfAspDB_NeatedGrid         / Album / SELECT category
 *@source SelfAspDB_SqlPlaceHolderGrid / Album / SELECT * WHERE category = @category
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 5.1.3 NestedGrid 階層的なグリッド表 / p214
 *@subject ----- outer GridView ----
 *         category, <TemplateField> inner GridView
 *         
 *@subject ----- inner GridView ----
 *         内側のGridは、WHERE句の @categoryに
 *         HiddenFieldの categoryの値を代入することで絞り込み。
 *         
 *         <ItemField>
 *           <HiddenField> ID="hdnCaterory" Value="<%# Eval("category') %>
 *           <GridView> 5.1.1 SqlPlaceHolderと同様(コピー)
 *           <DataSourceControl>
 *             SELECT * FROM Album WHERE (category=@category);
 *           <SelectParameters>
 *             <asp:ControlParameter
 *                  ControlID="hdnCaterory" 
 *                  Name="category"
 *                  PropertyName="Value"
 *                  Type="String" />
 *                  
 *@see ResultFile / NestedGrid.jpg
 *@author shika
 *@date 2021-12-08
 * -->
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT05_DataSourceControl
{
    public partial class NestedGrid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }//class
}