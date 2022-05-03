<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="SiteMapNodeSample.aspx.cs" 
    Inherits="SelfAspNet.SampleAsp.NT09_RichControl.NavigationControl.SiteMapNodeSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>SiteMapNodeSample</title>
</head>
<body>
<form id="formSiteMapNodeSample" runat="server">
<div>
    <asp:HyperLink ID="linkPrev" runat="server">Previous</asp:HyperLink>&nbsp;
    <asp:HyperLink ID="linkParent" runat="server">Parent</asp:HyperLink>&nbsp;
    <asp:HyperLink ID="linkNext" runat="server">Next</asp:HyperLink><br />
</div>
</form>
</body>
</html>
