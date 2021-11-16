<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListCtrlSample.aspx.cs" Inherits="SelfAspNet.SampleAsp.AS03_ServerControl.ListCtrlSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<form id="form1" runat="server">
<div>
    好きな食べ物は？
    <asp:RadioButtonList ID="listCtrl" runat="server" AutoPostBack="True" 
        RepeatDirection="Horizontal" 
        OnSelectedIndexChanged="listCntl_SelectedIndexChanged">
        <asp:ListItem Selected="True" Value="sushi">お寿司</asp:ListItem>
        <asp:ListItem Value="meat">焼肉</asp:ListItem>
        <asp:ListItem Value="unagiFish">うなぎ</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Label ID="LabelFood" runat="server" Text=""></asp:Label>
    <br />
    <br />
    好きな食べ物は？<br />
</div>
<div>
<asp:CheckBoxList ID="listCheck" runat="server" AutoPostBack="True" 
    RepeatDirection="Horizontal" OnSelectedIndexChanged="listCheck_SelectedIndexChanged" >
    <asp:ListItem Value="sushi">お寿司</asp:ListItem>
    <asp:ListItem Value="meat">焼肉</asp:ListItem>
    <asp:ListItem Value="unagiFish">うなぎ</asp:ListItem>
</asp:CheckBoxList>
</div>
</form>
</body>
</html>
