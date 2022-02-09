/** <!--
 *@title SelfAspNet / SampleAsp / NT07_StateVariable
 *       / Cache / DataCacheSample.aspx.cs
 *@target DataCacheSample.aspx
 *@source SelfAspDB / Book
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第７章 7.5 Cache / DataCache / p363 / List 7-15 ～ 7-18
 *
 *@prepare 【準備】DB上で Cache機能を有効にする
 *          .NET Framework / aspnet_regsql.exe
 *          C:\Windows\Microsoft.NET\Framework\v4.0.30319\aspnet_regsql.exe
 *          
 *          =>@see CMD_aspnet_regsql.txt (for detail)
 *          
 *@prepare 「Web,config」Cache対象となる DBをアプリケーションに登録
 *          <system.web>
 *            ...
 *            <caching>
 *                <sqlCacheDependency enabled="true" pollTime="5000" >
 *                    <databases>
 *                        <add name="MyCache" connectionStringName="SelfAspDB" />
 *                    </databases>
 *                </sqlCacheDependency>
 *            </caching>
 *          </system.web>
 *          
 *         「.aspx」
 *         <%@ OutputCache Duration="120" VaryParam="None"
 *             SqlDependency="MyCache:Book" %>
 *             
 *@prepare SelfAspNet / App_Data / Books.xml
 *         配布サンプルコードよりコピー
 *         
 *@subject 「.aspx」
 *          <%@ OutputCache Duration="120" VaryParam="None"
 *             SqlDependency="MyCache:Book" %>
 *             
 *          <asp:GridView ID="gridDataCacheSample">
 *              BoundField HeaderText="<表示名>" DataField="<列名>" 
 *              ※列名は「Books.xml」で定義されたものを利用
 *              
 *          <asp:DataSource>
 *          bool   EnableCaching=""
 *          int    CacheDuration="" (sec)//expiration time
 *          int?   CacheExpirationPolicy="" 
 *                   //starting point of expiration time
 *                   Absolute | Sliding
 *          string SqlCacheDependency="" //key columnName
 *          
 *@subject 「.aspx.cs」
 *          Caching Page.Cache
 *          object Cache.Get(string key)
 *          
 *          new    CacheDependency(string path    //依存関係
 *                                 [, string key]
 *                                 [, CacheDependency]
 *                                 [, DateTime start])
 *                                 
 *          void   Cache.Insert(
 *                   string key, object value, CacheDependency)
 *          void   Cache.Insert(
 *                   string key, object value, CacheDependency,
 *                   DateTime absolute, TimeSpan sliding) //有効期限
 *          void   Cache.Insert(
 *                   string key, object value, CacheDependency,
 *                   DateTime absolute, TimeSpan sliding, //有効期限
 *                   CacheItemPriority,  
 *                     //メモリ不足時に削除する優先順位                 
 *                     //Low, BelowNormal, Normal, AboveNormal, High, NotRemoval
 *                   CacheItemUpdateCallback)  //削除時に呼び出すdelegate
 *                
 *@author shika
 *@date 2022-02-09
 * -->
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT07_StateVariable.Cache
{
    public partial class DataCacheSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ds = new DataSet();
            string path = Server.MapPath("~/App_Data/Books.xml");

            if (Cache.Get("Books") == null)
            {
                ds.ReadXml(path);
                var cd = new CacheDependency(path);
                //---- 依存関係を設定した Cache ----
                Cache.Insert("Books", ds, cd);

                //---- 優先順位を設定した Cache ----
                ////Absolute
                //Cache.Insert("Books", ds, null,
                //    DateTime.Now.AddMinutes(30),
                //    System.Web.Caching.Cache.NoSlidingExpiration);
                ////Sliding
                //Cache.Insert("Books", ds, null,
                //    System.Web.Caching.Cache.NoAbsoluteExpiration,
                //    TimeSpan.FromSeconds(15));

                ////---- メモリ不足時の Cache削除優先順位を設定 ----
                //Cache.Insert("Books", ds, null,
                //    System.Web.Caching.Cache.NoAbsoluteExpiration,
                //    TimeSpan.FromSeconds(15),
                //    CacheItemPriority.High, null);
            }
            else
            {
                ds = (DataSet)Cache.Get("Books");
            }

            gridDataCacheSample.DataSource = ds;
            Page.DataBind();
        }//Page_Load()
    }//class
}