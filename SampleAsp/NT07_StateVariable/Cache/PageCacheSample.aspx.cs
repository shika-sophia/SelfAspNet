/** <!--
 *@title SelfAspNet / SampleAsp / NT07_StateVariable
 *       / Cache / PageCacheSample.aspx.cs
 *@target PageCacheSample.aspx
 *@source
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第７章 7.5 Cache / p355 / List 7-10, 7-11, 7-12
 *         ■ Cache
 *         ・OutputCache (= PageCache)
 *         ・FlagumentCache 〔10.1.3〕
 *         ・DataCache
 *         
 *@subject ◆OutputCache (= PageCache)
 *         Caching Page.Cache
 *         他メンバー〔DataCacheSample.cs 参照〕
 *         
 *@subject 「.aspx」
 *         <%@ Page ... %>
 *         <%@ OutputCache ... 
 *             Duration="" Cacheの有効期間 (秒)
 *             VaryByParam=""
 *                none: keyによってCache振り分けなし (= 変数によって別Cacheにする)
 *                      VaryByParam=""は省略不可なので、必要ない場合は none
 *                xxxx: 指定keyによってCache振分
 *                xxxx;yyyy 複数keyの場合、「;」で区切って指定
 *                "*":  すべての変数を key指定
 *             VaryByHeader=""    //RequestHeaderによってCache振分
 *                Accept-Language  //RequestHeaderの key。Pageでの利用言語。
 *             VaryByCustom=""    //自己定義
 *                Browser          //ブラウザによって Cache振分
 *          %>
 *          
 *@subject ◆国際化対応ページ
 *         ＊Resourceファイルの準備
 *           [VS] プロジェクト -> /App_Resources 右クリック -> [追加]
 *           -> [リソースファイル]
 *           -> 「<ベース名> [.<カルチャ名>].rscx
 *           -> key, valueを入力
 *           ※ カルチャなしは defaultファイルとなる。
 *           
 *         ＊「.aspx」Page settings
 *         <%@ Page ... 
 *             Culture=""   auto, ja, en-US
 *             UICulture="" auto, ja, en-US
 *         %> 
 *         
 *         <%@ OutputCache ... 
 *             VaryByParam="mone" //省略不可
 *             VaryByHeader=""    //RequestHeaderによってCache振分
 *               Accept-Language  //RequestHeaderの key。Pageでの利用言語。
 *         %>
 *         
 *         <asp:Label ID="lblGreeting" runat="server"
 *                Text="<%$ Resources:<ClassResx baseName>, <key> %>">
 *                
 *@see PageCacheSample.jpg
 *     Cache機能で時刻が更新していない
 *     Culture="en-US"で英語表示
 *     
 *@author shika
 *@date 2022-02-07
 * -->
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT07_StateVariable.Cache
{
    public partial class PageCacheSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblCurrent.Text = DateTime.Now.ToString();
        }
    }//class
}