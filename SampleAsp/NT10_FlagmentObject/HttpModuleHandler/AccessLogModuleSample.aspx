<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="AccessLogModuleSample.aspx.cs" 
    Inherits="SelfAspNet.SampleAsp.NT10_FlagmentObject.HttpModuleHandler.AccessLogModuleSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>AccessLogModuleSample</title>
</head>
<body>
<form id="formAccessLogModuleSample" runat="server">
<div>
    <asp:Literal ID="Literal1" runat="server"
        Text="AccessLogModuleSample.aspxで実行。<br />
              DB / AccessLog_tbを確認。" ></asp:Literal>
</div>
</form>
</body>
</html>
