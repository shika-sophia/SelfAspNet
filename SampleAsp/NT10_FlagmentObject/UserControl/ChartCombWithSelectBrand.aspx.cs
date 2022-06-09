/** <!--
 *@title SelfAspNet / SampleAsp / NT10_FlagmentObject /
 *       UserControl / ChartCombWithSelectBrand.aspx.cs
 *@target ChartCombWithSelectBrand.aspx
 *@source SelfAspDB / Stock_tb
 *@reference NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content NT 第10章 / 10.1 UserControl / 練習問題 10-1 / p491
 *         9.5.1 Chart2.aspxを 
 *           =>〔NT09_RichControl / ChartGraph / ChartCombinationGraph.aspx〕
 *        ・ユーザーコントロール化。     (未完成)
 *        ・brandで選択できるようにする。(ここは完成)
 *         
 *@subject brand選択できる機能
 *         ListBoxコントロールでは バインド式 <%# Eval() %>は提供されていないので、
 *         ListBoxで DBのレコードを動的に表示するには、
 *         Page_Load()で DBアクセスして、
 *         ListItem.Text, ListItem.Valueに代入して表示する。
 *         
 *         ListItemCollection ListView.Items
 *         void ListView.Items.Add(ListItem)
 *               └ new ListItem([string text, [string value]])
 *         int  ListView.Rows         ListBoxの行数 
 *         void ListView.DataBind()   ListBoxにデータバインド
 *         
 *@subject SQL "SELECT DISTINCT [brand] FROM [Stock]"
 *         Stock_tbは、同brandの dating別のレコードが複数存在するので、
 *        「DISTINCT」によって重複レコードを除去。
 *
 *@subject UserControl
 *         「.ascx」    <% @Control ... %>
 *                     =>　copy from〔NT09_RichControl / ChartGraph / ChartCombinationGraph.aspx〕
 *                     
 *         「.ascx.cs」 public int Brand { get; set; }
 *                     Page_Load() Chartのタイトルに branの値を表示
 *                     
 *         「.aspx」<%@ Register src="UserChartCombination.ascx"
 *                         tagname="ChartComb" TagPrefix="uc2" %>
 *
 *                  <uc2:ChartComb ID="userChartComb" runat="server" />
 *                  
 *         「.aspx.cs」Page_Load()
 *         初期状態で ListBoxの選択肢が出るように、DB接続をして listBrand.DataBind();
 *         listBrand_SelectedIndexChangedイベント〔下記 不具合〕         
 *
 *@NOTE【不具合】ListBoxの brandを選択しても、ChartGraphが切り替わらない。
 *             ・<uc2:ChartComb ... Brand ="34259" />と 値を 記述すると、
 *               Brand: 34259 の ChartGraphはデフォルトで描画される。
 *               =【解答 サンプルコード】と同じ
 *               
 *             ・ListBoxの選択によって切り替わらないので Brand ="34259"を削除し、
 *               listBrand_SelectedIndexChangedイベントに
 *               {
 *                    userChartComb.Brand = Int32.Parse(listBrand.SelectedItem.Value);
 *               }
 *               を記述してみたが、
 *               Response.Write(userChartComb.Brand);をしても値が出ないこことから、
 *               listBrand_SelectedIndexChangedイベントが呼ばれていない様子。
 *           
 *               ・<uc2:ChartComb>内に
 *               Brand="<%= Int32.Parse(listBrand.SelectedItem.Value) %>"
 *               としてみたが、コンパイルエラー。
 *               
 *               ・Bland="listBrand.SelectedItem.Value" 機能せず
 *               
 *               ・Brand='<%# Bind("brand") %>' これだと、
 *               Page_Load()時の DefaultValueを渡すことになり、やはり機能しない。
 *               
 *               
 *@see NT09_RichControl / ChartGraph / ChartCombinationGraph.aspx.cs
 *@see UserChartCombination.ascx //ユーザーコントロール
 *@see ChartCombWithSelectBrand.jpg
 *
 *@author shika
 *@date 2022-06-08
 * -->
 */
/* <!--
 *@NOTE SqlDataSource version: It cannot DataBinding <%# Eval() %>.
 *      <asp:SqlDataSource ID="sds" runat="server"
 *           ConnectionString="<%$ ConnectionStrings:SelfAspDB %>"
 *           SelectCommand="SELECT [brand] FROM [Stock] WHERE ([brand] = @brand)">
 *        <SelectParameters>
 *           <asp:ControlParameter ControlID="listBrand"
 *               Name="brand"
 *               PropertyName="SelectedValue"
 *               Type="Int32" />
 *        </SelectParameters>
 *      </asp:SqlDataSource>
 * -->
 */
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT10_FlagmentObject.UserControl
{
    public partial class ChartCombWithSelectBrand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var setting = ConfigurationManager.ConnectionStrings["SelfAspDB"];
            using (var db = new SqlConnection(setting.ConnectionString))
            {
                var sql = new SqlCommand(
                    "SELECT DISTINCT [brand] FROM [Stock]", db);

                db.Open();
                var reader = sql.ExecuteReader();

                int count = 0;
                while (reader.Read())
                {
                    count++;
                    string text = reader["brand"].ToString();
                    listBrand.Items.Add(new ListItem(text: text, value: text));
                }//while

                listBrand.Rows = count;

                reader.Close();
                db.Close();
            }//using
      
            listBrand.DataBind();
        }//Page_Load()

        protected void listBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            userChartComb.Cache.Remove(null);
            userChartComb.Brand = Int32.Parse(listBrand.SelectedItem.Value); //Brand ="34259"
            userChartComb.DataBind();

            Response.Write(userChartComb.Brand);
        }
    }//class
}