<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="HighLowNumber.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT07_StateVariable.ViewState.HighLowNumber" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>HighLowNumber</title>
</head>
<body>
<form id="formHighLowNumber" runat="server">
<div>
    ◆Number of Guess Game<br />
    Please input any number in range [ 1 - 100 ].<br />
    <asp:TextBox ID="txtNum" runat="server"
        Columns="3"></asp:TextBox>&nbsp;
    <asp:Button ID="btnSend" runat="server"
        Text="Answer" OnClick="btnSend_Click" /><br />
    <asp:Label ID="lblResult" runat="server"
        Text=""></asp:Label>
</div>
</form>
</body>
</html>
