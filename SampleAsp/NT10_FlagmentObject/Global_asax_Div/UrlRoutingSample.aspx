<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="UrlRoutingSample.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT10_FlagmentObject.Global_asax_Div.UrlRoutingSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>UrlRoutingSample</title>
</head>
<body>
<form id="formUrlRoutingSample" runat="server">
<div>
    <asp:Literal ID="ltrYear" runat="server" 
        Text="<%$ RouteValue:year %>" Mode="Encode"></asp:Literal>年&nbsp;
    <asp:Literal ID="ltrMonth" runat="server"
        Text="<%$ RouteValue:month %>" Mode="Encode"></asp:Literal>月&nbsp;
    <asp:Literal ID="ltrDay" runat="server"
        Text="<%$ RouteValue:day %>" Mode="Encode"></asp:Literal>日<br />
    <br />
    <asp:HyperLink ID="link" runat="server" 
        NavigateUrl="<%$ RouteUrl:RouteName=blog, year=2019, month=11, day=24 %>"
        Text="<%$ RouteUrl:RouteName=blog, year=2019, month=11, day=24 %>">
    </asp:HyperLink>
</div>
</form>
</body>
</html>
