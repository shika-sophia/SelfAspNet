<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="FriendlyUrlsSample.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT10_FlagmentObject.FriendlyUrlsDiv.FriendlyUrlsSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>FriendlyUrlsSample</title>
</head>
<body>
<form id="formFriendlyUrlsSample" runat="server">
<div>
    <asp:ListView ID="list" runat="server"
        ItemType="String">
        <ItemTemplate>
            ・<%#: Item %><br />
        </ItemTemplate>
    </asp:ListView>
</div>
</form>
</body>
</html>
