<%@ Page Language="C#" AutoEventWireup="true"
        CodeBehind="HelloAsp.aspx.cs" Inherits="SelfAspNet.SampleAsp.HelloAsp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>HelloAsp</title>
</head>
<body>
<form id="form1" runat="server">
<div>
    名前:　<asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
    <asp:Button ID="BtnSend" runat="server" Text="送信" OnClick="BtnSend_Click" /><br />
    <br />
    <asp:Label ID="LbGreet" runat="server"></asp:Label>
</div>
</form>
</body>
</html>
