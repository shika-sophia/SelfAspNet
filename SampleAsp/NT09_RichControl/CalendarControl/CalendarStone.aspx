<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="CalendarStone.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT09_RichControl.CalendarControl.CalendarStone" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CalendarStone</title>
</head>
<body>
<form id="formCalendarStone" runat="server">
<div>
    <asp:Calendar ID="calen" runat="server"
        OnVisibleMonthChanged="calen_VisibleMonthChanged"></asp:Calendar>
</div>
</form>
</body>
</html>
