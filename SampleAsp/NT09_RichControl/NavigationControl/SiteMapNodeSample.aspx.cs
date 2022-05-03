/**
 *@title SelfAspNet / SampleAsp / NT09_RichControl
 *       / NavigationControl / SiteMapNodeSample.aspx.cs
 *@target SiteMapNodeSample.aspx
 *@source Web.sitemap
 *@reference 山田祥寛『独習 ASP.NET 第６版』翔泳社, 2020
 *@content 第９章 9.1.8 SiteMapNode / p439 / List 9-4
 *         SiteMapNodeクラスからサイトマップ情報を参照する 
 *         
 *@subject ◆SiteMapNode (System.Web.)
 *         var node = new SiteMapNode();
 *         SiteMapNode SiteMap.CurrentNode
 *         SiteMapNodeCollection
 *                 node.ChildNodes
 *         bool    node.HasChildNodes
 *         string  node.Title
 *         string  node.Url
 *         ?       node.Item
 *         string  node.Desctiption
 *         SiteMapNode node.RootNode       ルートノード
 *         SiteMapNode node.ParentNode     親ノード
 *         SiteMapNode node.PreviousSibing 兄ノード
 *         SiteMapNode node.NextSibling    弟ノード
 *         
 *@author shika
 *@date 2022-05-03
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelfAspNet.SampleAsp.NT09_RichControl.NavigationControl
{
    public partial class SiteMapNodeSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var nodeCurrent = SiteMap.CurrentNode;
            
            if(nodeCurrent != null)
            {
                var nodePrev = nodeCurrent.PreviousSibling;
                var nodeParent = nodeCurrent.ParentNode;
                var nodeNext = nodeCurrent.NextSibling;

                SetHyperLink(linkPrev, nodePrev);
                SetHyperLink(linkParent, nodeParent);
                SetHyperLink(linkNext, nodeNext);
            }
        }//Page_Load()

        private void SetHyperLink(HyperLink link, SiteMapNode node)
        {
            if(node != null)
            {
                link.NavigateUrl = node.Url;
                link.Visible = true;
            }
        }//SetHyperLink()
    }//class
}