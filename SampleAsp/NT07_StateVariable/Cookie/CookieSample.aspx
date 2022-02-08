<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="CookieSample.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT07_StateVariable.Cookie.CookieSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CookieSample</title>
</head>
<body>
<form id="formCookieSample" runat="server">
<div>
    Email Address: <asp:TextBox ID="txtMail" runat="server"
        Columns="30" MaxLength="100"></asp:TextBox>&nbsp;
    <asp:Button ID="btnSave" runat="server" Text="Save"
        OnClick="btnSave_Click" /><br />
    <br />
    <asp:Label ID="lblCookie" runat="server" Text=""></asp:Label>
</div>
</form>
</body>
</html>
