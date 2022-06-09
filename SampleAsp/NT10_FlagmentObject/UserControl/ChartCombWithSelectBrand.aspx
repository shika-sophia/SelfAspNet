<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="ChartCombWithSelectBrand.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT10_FlagmentObject.UserControl.ChartCombWithSelectBrand" %>

<%@ Register Src="~/SampleAsp/NT10_FlagmentObject/UserControl/UserChartCombination.ascx"
    TagPrefix="uc1" TagName="UserChartCombination" %>


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
        SelectionMode="Single" AutoPostBack="True" >
    </asp:ListBox>
    <%-- DataBind() in Page_Load() --%>
</div>
<div>
    <uc1:UserChartCombination runat="server" ID="userChartComb" 
        Bland="" />
</div>
</form>
</body>
</html>
