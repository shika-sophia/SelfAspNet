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
        <%-- ListItem created in Page_Load() --%>
    </asp:ListBox>
    <%-- DataBind() in Page_Load() --%>
</div>

<%-- Test Label
<div>
    Label:
    <asp:Label ID="LblBrand" runat="server">
        <%= listBrand.SelectedIndex %><br />
    </asp:Label><br />
</div> --%>

<% if (listBrand.SelectedIndex != -1) { %>
<div>
    <% if (listBrand.SelectedIndex == 0)
        { %>
    <uc1:UserChartCombination runat="server" ID="userChartComb" 
         Brand="28710" /> 
    <% }
        else if (listBrand.SelectedIndex == 1)
        { %>
    <uc1:UserChartCombination runat="server" ID="UserChartCombination1" 
         Brand="34259" />    
    <% } //if 0 or 1 %>
</div>
<% } //if -1 %>
</form>
</body>
</html>
