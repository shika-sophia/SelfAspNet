/**
 *@title SelfAspNet / SampleAsp / NT05_DataSourceControl
 *       / TypedDataSet / PagerSample.aspx.cs
 *@target PagerSample.aspx
 *@target partial AlbumDataSetTableAdapters.AlbumTableAdapter.cs
 *@source SelfAspDB / Album
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 5.3.4 大量データのページング機能 / p269 / List 5-15
 *@subject NestedGrid.aspx 〔5.1.3 コピー〕
 *         innerGrid に ObjectDataSouceをデータバインド
 *         (innerGridには NestedGridの SqlDataSorurceが
 *         すでにバインドされているので、それに追加する)
 *         
 *         ◆GridView
 *           ID="gridSqlPlaceHolder" runat="server" 
 *           AutoGenerateColumns="False"
 *           DataKeyNames="id"
 *           DataSourceID="SelfAspDB_SplPlaceHolderGrid"
 *           EmptyDataText="Please Select Category." 
 *           AllowPaging="true"
 *           DataSourcrID="ods"
 *           PageSize="2">
 *           
 *         ◆ObjectDataSource
 *           ID="ods" runat="server"
 *           OldValuesParameterFormatString="original_{0}"
 *           EnablePaging="true"
 *           SelectMethod="GetAlbumPaging"
 *           SelectCountMetod="GetAlbumNumber"
 *           TypeName=
 *             "SelfAspNet.SampleAsp.NT05_DataSourceControl.
 *             TypedDataSet.AlbumDataSetTableAdapters.AlbumTableAdapter"
 *             
 *@subject AlbumTableAdapter.csにページングメソッドを追加
 *         ◆AlbumDataTable GetAlbumPaging(int startRowIndex, int maximumRows)
 *         〔SQL Server〕m～n 件のレコード取得をする SELECT文
 *          "SELECT * FROM Album
 *            ORDER BY updated
 *            OFFSET {startRowIndex} ROWS
 *            FETCH NEXT {maximumRows} ROWS ONLY"
 *            
 *@subject AlbumTableAdapterのプロパティ/メソッド
 *           this = AlbumTableAdapter
 *         SqlConnection this.Connection
 *         SqlDataAdapter this.Adapter
 *         SqlCommand    conn.CreateCommand()
 *         string        sqlCommand.CommandText
 *         SqlCommand    this.Adapter.SelectCommand
 *         int           this.Adapter.Fill(DataSet, string tableName)
 *         
 *@see ResultFile / PagerSample.jpg
 *@author shika
 *@date 2022-01-05
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT05_DataSourceControl.TypedDataSet
{
    public partial class PagerSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}