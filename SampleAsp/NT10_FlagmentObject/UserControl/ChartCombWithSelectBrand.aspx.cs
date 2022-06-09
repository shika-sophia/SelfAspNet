/** <!--
 *@title SelfAspNet / SampleAsp / NT10_FlagmentObject /
 *       UserControl / ChartCombWithSelectBrand.aspx.cs
 *@target ChartCombWithSelectBrand.aspx
 *@source SelfAspDB / Stock_tb
 *@reference NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content NT 第10章 / 10.1 UserControl / 練習問題 10-1 / p491
 *         9.5.1 Chart2.aspxを 
 *           =>〔NT09_RichControl / ChartGraph / ChartCombinationGraph.aspx〕
 *        ・ユーザーコントロール化。     
 *        ・brandで選択できるようにする。//Brand="28710" | Brand ="34259"
 *        (ListBoxは完成 -> UserControlに値を渡せない不具合あり)
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
 *        「DISTINCT」によって重複レコードを除去。(なぜか レコードが 4つ出る)
 *
 *@subject UserControl
 *         「.ascx」    <% @Control ... %>
 *                     =>　copy from〔NT09_RichControl / ChartGraph / ChartCombinationGraph.aspx〕
 *                     
 *         「.ascx.cs」 public string Brand { get; set; }
 *                     Page_Load() Chartのタイトルに brandの値を表示
 *                     
 *         「.aspx」<%@ Register Src="~/SampleAsp/NT10_FlagmentObject/UserControl/UserChartCombination.ascx"
 *                        TagPrefix="uc1" TagName="UserChartCombination" %>
 *                  
 *                  if(listBrand.SelectedIndex)
 *                  -1: 未選択時 -> 非表示
 *                  0:  Brand="28710"
 *                  1:  Brand="34259"
 *                  
 *          =>【考察】レコードが増えるたびに、if文も追加しないといけないし、
 *                   DB接続しているのに、文字列 Brand = ""を直記入するのは、
 *                   あまりいい方法ではない 
 *                  
 *                  <uc1:UserChartCombination ID="userChartComb" runat="server" 
 *                        Brand="28710" />
 *                  <uc1:UserChartCombination ID="userChartComb" runat="server" 
 *                        Brand="34259" />
 *                  
 *         「.aspx.cs」Page_Load()
 *         初期状態で ListBoxの選択肢が出るように、DB接続をして listBrand.DataBind();
 *         listBrand_SelectedIndexChangedイベント〔下記 不具合〕         
 *
 *@NOTE【考察】今回は ListItemを コードビハインドで生成しているが、
 *      これだと、listBrand_SelectedIndexChangedイベントは機能しない様子。
 *      
 *      if文を使わずに Brand="<%= listBrand.SelectedItem.Value %>" で値を
 *      ユーザーコントロールに渡すには、コードビハインドではなく、
 *      「.aspx」ページに <Items><asp:ListItem>を記述しないといけないのかも。
 *      
 *      ただし、コードビハインドでも listBrand.SelectedIndexは機能しているので、
 *      この値で if分岐して切り替えた。(あまりいい方法でない理由は下記【考察】)
 *      
 *@see NT09_RichControl / ChartGraph / ChartCombinationGraph.aspx.cs
 *@see UserChartCombination.ascx     //ユーザーコントロール
 *@see ChartCombWithSelectBrand.jpg  //ListBoxに brand値を表示
 *@see ChartCombWithSelectBrand34259.jpg  
 *
 *@author shika
 *@date 2022-06-08, 06-09, 06-10
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
            userChartComb.Brand = listBrand.SelectedItem.Value; //Brand="28710" | Brand ="34259"
            userChartComb.DataBind();

            Response.Write(userChartComb.Brand);
        }
    }//class
}

/*
 * @NOTE【不具合】ListBoxの brandを選択しても、ChartGraphが切り替わらない。
 *             ・<uc1:UserChartCombination... Brand = "34259" /> と 値を 記述すると、
 *               Brand: 34259 の ChartGraphはデフォルトで描画される。
 *               =【解答 サンプルコード】と同じ
 *               => ChartCombWithBrand34259.jpg 〔選択機能未完成〕
 *               
 *             ・ListBoxの選択によって切り替わらないので Brand ="34259"を削除し、
 *               listBrand_SelectedIndexChangedイベントに
 *               {
 *                    userChartComb.Brand = listBrand.SelectedItem.Value;
*               }
 *              を記述してみたが、
 *              Response.Write(userChartComb.Brand); をしても値が出ないこことから、
 *              listBrand_SelectedIndexChangedイベントが呼ばれていない様子。
 *
 *              ・< uc1:UserChartCombination... Brand = "34259" />
 *                Brand = "34259"の代わりに
 *                Bland = "listBrand.SelectedItem.Value" 機能せず。文字列だ。
 *               
 *              ・Brand='<%# Bind("brand") %>' これだと、
 *                Page_Load()時の DefaultValueを渡すことになり、やはり機能しない。
 *               
 *               ・「.ascx.cs」Brand set{ }内を
 *                  Brand = value; とすると StackOverFlow(=同一参照の無限ループ)になることから、
 *                「.aspx」< uc1:UserChartCombination >
 *                 Brand = "xxxx" により、Brand値は setされ、valueもその値となる。
 *                 
 *               ・<uc1:UserChartCombination > 内に
 *                 Brand = "<%= listBrand.SelectedItem.Value %>"
 *                 としてみたが、機能せず。〔下記【考察】〕
 *
 *               ・Label:
 *                 < asp:Label ID = "LblBrand" runat="server"
 *                     Text="<%= listBrand.SelectedItem.Value %>" >
 *                 </asp:Label >
 *                 -> 「Label:<%= listBrand.SelectedItem.Value %>」と式のまま表示される
 *
 *               ・< asp:Label ID = "LblBrand" runat="server">
 *                     <%= listBrand.SelectedItem.Value %>
 *                 </asp:Label >
 *                 ->System.NullReferenceException
 *                   オブジェクト参照がオブジェクト インスタンスに設定されていません。
 *                   ChartCombWithSelectBrand.aspx:行 28 //Labelの行
 *
 *                =>【考察】<%= listBrand.SelectedItem.Value %> は
 *                   値を取得していない(= nullである)ことがわかる。
 *                   Brand = "<%= listBrand.SelectedItem.Value %>"も
 *                   単なる文字列として渡されている様子。
 *                    
 *               ・Label:
 *                < asp:Label ID = "LblBrand" runat="server">
 *                   <%= listBrand.SelectedIndex %>
 *                </asp:Label >
 *
 *                ->これだと値取得 未選択: -1 | "28710": 0 | "34259": 1
 *                =>【考察】listBrandは参照可能らしい。
 *                   SelectedItemが nullかも。 
 *
 *               ・<%= listBrand.Items[listBrand.SelectedIndex].Value %>
 *                ->System.ArgumentOutOfRangeException
 *                => 未選択時: SelectedIndex == -1 なので、こうなる。
 *                   Bland = ""にこの値を渡しても機能するのは
 *                   例外時に DefaultValueを利用していると思われる。
 *                   
 *               ・if文で -1を排除しても
 *                 listBrand.Itemsは nullの様子。
 *                 
 *               ・「.aspx」内に if文で SelectedIndexを分岐し
 *                 ２つの<uc1:UserChartCombination > に
 *                  Brand = "28710" | Brand = "34259" を記述すると、
 *                  目的の切替機能は実装できる。
 *                  
 *                =>【考察】レコードが増えるたびに、if文も追加しないといけないし、
 *                   DB接続しているのに、文字列 Brand = ""を直記入するのは、
 *                   あまりいい方法ではない
 */