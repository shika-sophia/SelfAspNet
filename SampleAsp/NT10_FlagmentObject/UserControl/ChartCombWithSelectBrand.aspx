<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="ChartCombWithSelectBrand.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT10_FlagmentObject.UserControl.ChartCombWithSelectBrand" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ChartCombWithSelectBrand</title>
</head>
<body>
<form id="formChartCombWithSelectBrand" runat="server">
<div>
    Select Brand:<br />
    <asp:ListBox ID="listBrand" runat="server"
        SelectionMode="Single">
        <%-- ListItem created in Page_Load() --%>
    </asp:ListBox>
    <%-- DataBind() in Page_Load() --%>
</div>
</form>
</body>
</html>
