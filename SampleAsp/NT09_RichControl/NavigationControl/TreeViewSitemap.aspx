 
<% @ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="TreeViewSitemap.aspx.cs" 
    Inherits="SelfAspNet.SampleAsp.NT09_RichControl.NavigationControl.TreeViewSitemap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>TreeViewSitemap</title>
</head>
<body>
    <form id="formTreeViewSitemap" runat="server">
        <div>
        </div>
        <asp:TreeView ID="treeSitemap" runat="server" DataSourceID="smds" ImageSet="News" NodeIndent="10" ShowLines="True">
            <HoverNodeStyle Font-Underline="True" />
            <NodeStyle Font-Names="Arial" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
            <ParentNodeStyle Font-Bold="False" />
            <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
        </asp:TreeView>
        <asp:SiteMapDataSource ID="smds" runat="server" />
    </form>
</body>
</html>