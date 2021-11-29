/**
 *@title SelfAspNet / SampleAsp / GridWithTemplate.aspx.cs
 *@target GridTemplate.aspx
 *@target SelfAspDB / Album
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content GridViewControl with TemplateField / p160 - 171 /
 *@subject GridViewの一部を TemplateFieldに変更
 *         分類: DropDownListを追加、選択できるようにする。
 *                 DetaSource: SelfAspDB_ListEditCat
 *         コメント:   編集時のTextBox.Columnsを拡大
 *         最終更新日: 編集時に Date型検証 -> 更新時にアラート
 *         削除ボタン: クリック時に Client側 confirm() 確認メッセージを出す。
 *
 *@see GridViewSample.aspx
 *@see SampleSql / Alubum_tb.sql
 *@see ResultFile / GridWithTemplate.jpg
 *@author shika
 *@date 2021-11-30
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT04_DataBindControl
{
    public partial class GridWithTemplate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gridTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}