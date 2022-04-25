/** <!--
 *@title SelfAspNet / SampleAsp / MultiViewSample.aspx.cs
 *@target MultiViewSample.aspx
 *@source SelfAspDB / Album_tb
 *@reference NT 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content NT 第９章 9.3 MultiView / p461 / List 9-9
 *@subject MultiView 一覧 / 詳細画面の切替
 *         別ページに遷移することなく、１つのページ内で定義できる。
 *         
 *@subject 〔NT GridView: p259〕DataKeyNames="" 
 *          DataKeyNames=""は SqlDataSourceの primary keyを表す。
 *          これを設定しないと、WHERE句検索などができずコンパイルエラー。
 *          SqlDataSourceで自動生成されるが、
 *          ObjectDataSource時は自分で記述する必要がある。
 *          MultiViewでも自己設定が必要なのかも。
 *
 *@subject <View> <FormView>
 *         FormViewAlbum.aspxをコピー
 *         => 〔章末問題4-6 | NT04DataBindControl/FormViewAlbum.aspx〕
 *      
 *@subject <FormView>の SqlDataSource
 *         GridViewの Idを取得し、SELECT WHERE句に代入
 *         (SqlDataSourceのタスクメニューから自動設定可)
 *
 *         SelectCommand="SELECT [Id], [category], [comment], [updated], [favorite] FROM [Album] WHERE ([Id] = @Id)" >
 *           <SelectParameters>
 *               <asp:ControlParameter 
 *                   ControlID="gridMulti"
 *                   Name="Id"
 *                   PropertyName="SelectedValue"
 *                   Type="String" />
 *           </SelectParameters>
 *           
 *@subject イベントハンドラー
 *         <MultiView> ActiveViewIndex="" 
 *           表示するViewのindexを指定
 *           -1: (デフォルト) Viewを表示しない
 *           0: 最初のViewに設定
 *           
 *         gridMulti_SelectedIndexChangedイベントハンドラー
 *           選択ボタンがクリックされたときに呼出される。
 *           mv.ActiveViewIndex = 1;とするだけで、次のViewを表示
 *           
 *         protected void gridMulti_SelectedIndexChanged(object sender, EventArgs e)
 *         {
 *             mv.ActiveViewIndex = 1;
 *         }
 *         
 *@subject <Button> CommandName="PrevView"
 *         MultiView特有のコマンド、ひとつ前のViewを表示
 *         (ここでは GridViewに戻る)
 *
 *@see NT04DataBindControl/FormViewAlbum.aspx
 *@see MultiViewSample.jpg
 *@author shika
 *@date 2022-04-19, 04-25
 * -->
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT09_RichControl.MultiViewControl
{
    public partial class MultiViewSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gridMulti_SelectedIndexChanged(object sender, EventArgs e)
        {
            mv.ActiveViewIndex = 1;
        }
    }//class
}

/*
 *NOTE 【考察】
 *      章末問題4-6 が必要 
 *      => 〔NT04DataBindControl/FormViewAlbum.aspx〕
 *      
 *      アプリケーションでサーバー エラーが発生しました。
 *      例外の詳細: System.InvalidOperationException:
 *      選択されたデータ キーを取得する前に、
 *      データ キーを GridView 'gridMulti' で指定しなければなりません。
 *      データ キーを指定するには、DataKeyNames プロパティを使用します。
 *      
 *      => <GridView>に DataKeyNames="Id"を追加すると解決
 *      (これを設定しないと、WHERE句検索などができずコンパイルエラー。)
 *      
 */