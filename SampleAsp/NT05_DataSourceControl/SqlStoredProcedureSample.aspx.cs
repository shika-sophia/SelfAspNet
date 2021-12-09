/** <!--
 *@title SelfAspNet / SampleAsp / NT05_DataSourceControl / SqlStoredProcedure.aspx
 *@target SqlStoredProcedure.aspx
 *@source SelfAspDB_SqlPlaceHolder     / Album / SELECT category
 *@source SelfAspDB_SqlPlaceHolderGrid / Album / SELECT *
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 5.1.6 ストアドプロシージャ / p224
 *@subject RadioListButton (No Selected)時にも
 *         AlbumFilterProcedure を起動し、Grid表を表示。
 *         
 *         <%-- GridView SqlDataSource --%>
 *         <asp:SqlDataSource ID="SelfAspDB_SplPlaceHolderGrid" runat="server"
 *             ConnectionString="<%$ ConnectionStrings:SelfAspDB %>"
 *              SelectCommand="AlbumFilterProcedure"
 *              SelectCommandType="StoredProcedure" 
 *              OnSelected="SelfAspDB_SplPlaceHolderGrid_Selected" >
 *          <SelectParameters>
 *              <asp:ControlParameter
 *                  ControlID="listCat" 
 *                  Name="category"
 *                  PropertyName="SelectedValue"
 *                  Type="String" />
 *              <asp:Parameter Direction="Output" Name="recordNUM" Type="Int32" />
 *          </SelectParameters>
 *@subject 検索結果の件数をラベル表示 
 *         Selectedイベントハンドラー: SqlDataSourceが SELECT実行後にイベント発生
 *         SqlDataSourceStatusEventArgs e
 *     System.Data.Common.
 *         DbCommand             e.Command;
 *         DbParameterCollection command.Parameters;
 *         DbParameter           commandDic["@key"];
 *         object                para.Value;
 *
 *@see SplSample / AlbumFilterProcedure.sql
 *@see ResultFile / SqlStoredProcedure.jpg
 *@author shika
 *@date 2021-12-09
 * -->
 */
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT05_DataSourceControl
{
    public partial class SqlStoredProcedureSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SelfAspDB_SplPlaceHolderGrid_Selected(
            object sender, SqlDataSourceStatusEventArgs e)
        {
            DbCommand command = e.Command;
            DbParameterCollection commandDic = command.Parameters;
            DbParameter para = commandDic["@recordNum"];
            int recordNum = Int32.Parse(para.Value.ToString());

            if(recordNum == 0)
            {
                lblRecordNum.Text = $"No Record.";
            } else if (recordNum == 1)
            {
                lblRecordNum.Text = $"{recordNum} Record was Searched.";
            } else if (recordNum > 1)
            {
                lblRecordNum.Text = $"{recordNum} Records were Searched.";
            }
        }
    }//class
}