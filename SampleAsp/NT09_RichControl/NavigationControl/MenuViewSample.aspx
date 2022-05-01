<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="MenuViewSample.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT09_RichControl.NavigationControl.MenuViewSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>MenuViewSample</title>
</head>
<body>
<form id="formMenuViewSample" runat="server">
<div>
    <asp:Menu ID="Menu1" runat="server"
        DataSourceID="smds"
        MaximumDynamicDisplayLevels="2">
    </asp:Menu>
    <asp:SiteMapDataSource ID="smds" runat="server" />
</div>
</form>
</body>
</html>
