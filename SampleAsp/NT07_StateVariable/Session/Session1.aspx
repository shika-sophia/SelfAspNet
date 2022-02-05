<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Session1.aspx.cs" 
    Inherits="SelfAspNet.SampleAsp.NT07_StateVariable.Session.Session1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Session1</title>
</head>
<body>
<form id="formSession1" runat="server">
<div>
    ◆Session 1<br />
    <asp:Label ID="lblSession1" runat="server" Text=""></asp:Label><br />
    LinkButton[<asp:LinkButton ID="link" runat="server"
        OnClick="link_Click" >Session 2</asp:LinkButton>]<br />
    HTML &lt;a&gt;[<a href="Session2.aspx">Session 2</a>]<br />
</div>
</form>
</body>
</html>
