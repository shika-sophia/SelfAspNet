<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="ErrorSample.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT10_FlagmentObject.Global_asax_Div.ErrorSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ErrorSample</title>
</head>
<body>
<form id="formErrorSample" runat="server">
<div>
    <asp:GridView ID="gridError" runat="server"></asp:GridView>
    <asp:SqlDataSource ID="sdsError" runat="server"
        ConnectionString="<%$ ConnectionStrings:SelfAspError %>" 
        SelectCommand="SELECT [id], [url], [userAgent], [referrer], [accessTime] FROM [AccessLog]"></asp:SqlDataSource>
</div>
</form>
</body>
</html>
