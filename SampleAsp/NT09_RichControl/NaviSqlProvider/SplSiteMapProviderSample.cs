/** <!--
 *@title SelfAspNet / SampleAsp / NT09_RichControl
 *       NaviSqlProvider / SplSiteMapProviderSample.cs
 *@inherit StaticSiteMapProvider
 *@source SelfAspDB / Sitemap_tb
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第９章 9.1.9 DBからTreeView/MenuViewを生成 / p441 / List 9-5
 *
 *@subject ◆Sitemap Provider 〔NT143〕
 *           //サイトマップ情報を読み込むためのライブラリ
 *         SiteMapProvider           抽象クラス
 *           └ StaticSiteMapProvider 抽象クラス 部分的に実装クラス
 *             └ XmlSiteMapProvider  XML形式の「.sitemap」を読み込むクラス 〔NT139〕
 *             
 *         DB連携のために StaticSiteMapProviderを継承して実装クラスを記述
 *             
 *@subject SiteMapProviderSample : StaticSiteMapProvider 〔NT144〕
 *         public override void Initialize(string name, NameValueCollection attributes)
 *           サイトマップ情報を読み込むリソースの初期化
 *           引数 name:      プロバイダ表示名
 *                attributs: カスタム属性のコレクション
 *         public override SiteMapNode BuildSiteMap()
 *           データソースから SiteMapNodeを組み立て
 *         protected override SiteMapNode GetRootNodeCore()
 *           ルートノードを取得
 *         
 *         private void CreateNode(SiteMapNode) 
 *           自己定義のメソッド。再帰的に自己メソッドを呼出て、
 *           階層全てのノードを rootに Add()していくメソッド
 *           
 *         void this.Add(SiteMapNode node, [SiteMapNode parentNode])
 *         
 *@subject SiteMapNodeクラス
 *         new SiteMapNode(SiteMapProvider, 
 *           string key, 
 *           string url, 
 *           string title, 
 *           string description)
 *
 *@subject Web.config <system.web>内
 *         <siteMap enabled="true" defaultProvider="SqlSiteMapProvider">
 *           <clear />
 *           <providers>
 *             <add name="SqlSiteMapProvider"
 *                  type="SelfAspNet.SampleAsp.NT09_RichControl.NaviSqlProvider.SplSiteMapProviderSample
 *                  connectName="SelfAspDB" />
 *           </providers>
 *         </siteMap>
 *
 *@see Web_config_NT09NaviSplProvider.txt
 *@author shika
 *@date 2022-05-01
 * -->
 */

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace SelfAspNet.SampleAsp.NT09_RichControl.NaviSqlProvider
{
    public class SplSiteMapProviderSample : StaticSiteMapProvider
    {
        private String connectName; //Web.config connectionStrings=""
        private SiteMapNode root;   //DBで定義されたサイトマップ情報

        //サイトマップ情報の読込に必要なリソースを初期化
        public override void Initialize(
            string name, NameValueCollection attributes)
        {
            //connectNameが空のとき、Web.configから読込
            if(connectName == null)
            {
                base.Initialize(name, attributes);
                this.connectName = attributes["connectName"];
            }
        }//Initialize()

        //DBから読み込んだ SqlDataReaderを SiteMapNodeに組み立て
        public override SiteMapNode BuildSiteMap()
        {
            if(root == null)
            {
                lock (this)
                {
                    CreateNode(root);
                }//lock
            }

            return root;
        }//BuildNode()

        //rootノードを取得(BuildNode()と同じ値を返す)
        protected override SiteMapNode GetRootNodeCore()
        {
            return BuildSiteMap();
        }//GetRootNodeCore()

        //指定ノードparentNodeを親とする子ノード群を追加
        private void CreateNode(SiteMapNode parentNode)
        {
            ConnectionStringSettings setting =
                ConfigurationManager.ConnectionStrings[connectName];

            using (var db = new SqlConnection(setting.ConnectionString))
            {
                var sql = new SqlCommand(
                    "SELECT mid, url, title, description FROM Sitemap WHERE (parent = @parent)",
                    db);
                sql.Parameters.AddWithValue("@parent", 
                    parentNode == null ? 0 : Int32.Parse(parentNode.Key));

                db.Open();

                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    var node = new SiteMapNode(
                            this,
                            reader["mid"].ToString(),
                            reader["url"].ToString(),
                            reader["title"].ToString(),
                            reader["description"].ToString());

                    if (parentNode == null)
                    {
                        this.root = node;
                        this.AddNode(root);
                        this.CreateNode(root);
                    }
                    else
                    {                      
                        this.AddNode(node, parentNode);
                        this.CreateNode(node);
                    }
                }//while

                db.Close();
            }//using
        }//CreateNode()
    }//class
}

/*
◆NavigationControl / TreeViewSitemap.aspxと同様のエラー

'/' アプリケーションでサーバー エラーが発生しました。
構成にエラーがあります。
説明: この要求を処理するために必要な構成ファイルの処理中にエラーが発生しました。以下のエラーの詳細を確認し、構成ファイルに変更を加えてください。

パーサー エラー メッセージ: The connection string name is missing for the MySqlSiteMapProvider

ソース エラー:
行 273:    <siteMap>
行 274:      <providers>
行 275:        <add name="MySqlSiteMapProvider" type="MySql.Web.SiteMap.MySqlSiteMapProvider, MySql.Web, Version=8.0.20.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d" connectionStringName="LocalMySqlServer" applicationName="/" />
行 276:      </providers>
行 277:    </siteMap>

ソース ファイル: C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\machine.config    行: 275
 */