<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="ClientCallJs.aspx.cs"
    Inherits="SelfAspNetApi.SampleCode.ClientCallJs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ClientCallJs</title>
</head>
<body>
<form id="formClientCallJs" runat="server">
<div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"
        EnableCdn="true"
        AjaxFrameworkMode="Disabled">
        <Scripts>
            <asp:ScriptReference Name="jquery" />
            <asp:ScriptReference Path="~/SampleCode/BookSearch.js" />
        </Scripts>
    </asp:ScriptManager>
    <input id="txtIsbn" type="text" />&nbsp;
    <input id="btnSearch" type="button" value="Search" /><br />
    <div id="result">
    </div>
</div>
</form>
</body>
</html>
