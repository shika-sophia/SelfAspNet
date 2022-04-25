<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="CalendarSample.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT09_RichControl.CalendarControl.CalendarSample" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CalendarSample</title>
</head>
<body>
<form id="formCalendarSample" runat="server">
<div>
    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
    <br />
    <asp:Calendar ID="calen" runat="server"
        OnSelectionChanged="calen_SelectionChanged"></asp:Calendar>
</div>
</form>
</body>
</html>
