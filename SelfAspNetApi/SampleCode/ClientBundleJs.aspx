<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="ClientBundleJs.aspx.cs"
    Inherits="SelfAspNetApi.SampleCode.ClientBundleJs" %>
<%@ Import Namespace="System.Web.Optimization" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ClientBundleJs</title>
</head>
<body>
<form id="formClientBundleJs" runat="server">
<div>
    <asp:ScriptManager ID="ScriptManager2" runat="server"
        EnableCdn="true"
        AjaxFrameworkMode="Disabled">
        <Scripts>
            <asp:ScriptReference Name="jquery" />
            <%-- <asp:ScriptReference Path="~/SampleCode/BookSearch.js" /> --%>            
        </Scripts>
    </asp:ScriptManager>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <%: Scripts.Render("~/bundles/mySetting") %>
    </asp:PlaceHolder>
    <input id="txtIsbn" type="text" />&nbsp;
    <input id="btnSearch" type="button" value="Search" /><br />
    <div id="result">
    </div>
</div>
</form>
</body>
</html>
