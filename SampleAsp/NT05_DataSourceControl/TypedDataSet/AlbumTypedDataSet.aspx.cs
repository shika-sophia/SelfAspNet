/** <!--
 *@title SelfAspNet / SampleAsp / SampleAsp / NT05_DataSourceControl 
 *       / TypedDataSet / AlbumDataSetTableAdapters / AlbumTableAdapter.cs
 *@target partial AlbumDataSetTableAdapters.AlbumTableAdapter.cs
 *@source SelfAspDB / Album
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 5.3 DataAccessComponentの開発 / p264 / List 5-12 追補
 *@subject partial classで 自動生成コードに 自己定義コードを追加
 *         テキスト本文中 List 5-12は 「...中略...」となっていた部分を
 *         配布サンプルコードから追補。
 *         テキスト本文の説明通りだと、GetAlbumData()は
 *         引数なしのメソッドでしか定義できないので、
 *         Text Original:[ObjectParam2.aspx]を参照し
 *         => My Code:   [AlbumTypedDataSet.aspx]に
 *         ＊<asp:RadioButtonList>内
 *           <asp:ListItem Selected="True">(No Selected)</asp:ListItem>
 *           
 *         ＊<asp:GridView> - <asp:ObjectDataSource>内
 *           <SelectParameters>
 *             <asp:ControlParameter ControlID="list"
 *               Name="category"
 *               PropertyName="SelectedValue"
 *               Type="String" />
 *           </SelectParameters>
 *         を追補
 *         
 *@see ReaultFile / AlbumTypedDataSet.jpg
 *@author shika
 *@date 2021-12-28  
 * --> */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT05_DataSourceControl.TypedDataSet
{
    public partial class AlbumTypedDataSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}