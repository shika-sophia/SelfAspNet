/** <!--
 *@title SelfAspNet / SampleAsp / NT05_DataSourceControl / 
 *       / ObjectDataSource / ObjectDataSourceSample.aspx.cs
 *@target ObjectDataSourceSample.aspx
 *@source SelfAspDB / Album
 *@DAO    AlbumDao.cs
 *
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 5.3.1 ObjectDataSourceの実装 / p254 / List 5-11
 *         RadioButtonList SelectedValue="(No Selected)"のとき、
 *         [SELECT * FROM Album]の GridViewを表示。
 *         (同様の処理は ストアドプロシージャでも定義)
 *         
 *@based        SplPlaceHolder.aspx
 *@modification GridView -> CommandField command="Delete" 
 *                  -> TemplateField OnClientClick="return confirm()"
 *              SqlDataSource -> deleted
 *              ObjectDataSource -> new
 *              ObjectDataSourceSample.designer.aspx.cs -> deleted
 *
 *@see ResultFile / ObjectDataSourceSample.jpg
 *@see SplPlaceHolder.aspx.cs
 *@see SplStoredProcedure.aspx.cs
 *@author shika
 *@date 2021-12-19
 * -->
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT05_DataSourceControl.ObjectDataSource
{
    public partial class ObjectDataSourceSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }//class
}