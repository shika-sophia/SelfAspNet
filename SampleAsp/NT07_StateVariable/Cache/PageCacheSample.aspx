<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="PageCacheSample.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT07_StateVariable.Cache.PageCacheSample"
    Culture="auto" UICulture="auto" %>
<%@ OutputCache Duration="120"
      VaryByParam="none"
      VaryByHeader="Accept-Language" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>PageCacheSample</title>
</head>
<body>
<form id="formPageCacheSample" runat="server">
<div>
    <asp:Label ID="lblGreeting" runat="server"
        Text="<%$ Resources:ResourceSample, Greeting %>">
    </asp:Label><br />
    <asp:Label ID="lblUpdate" runat="server"
        Text="<%$ Resources:ResourceSample, Update %>">
    </asp:Label>:&nbsp;
    <asp:Label ID="lblCurrent" runat="server" Text=""></asp:Label><br />
</div>
</form>
</body>
</html>
