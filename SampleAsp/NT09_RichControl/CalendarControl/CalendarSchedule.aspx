﻿<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="CalendarSchedule.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT09_RichControl.CalendarControl.CalendarSchedule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CalendarSchedule</title>
</head>
<body>
<form id="formCalendarSchedule" runat="server">
<div>
    <asp:Calendar ID="calenSche" runat="server"
        OnDayRender="calenSche_DayRender" 
        VisibleDate="2019-12-01"></asp:Calendar>
    <asp:SqlDataSource ID="sds" runat="server"
        ConnectionString="<%$ ConnectionStrings:SelfAspDB %>"
        SelectCommand=
          "SELECT [scheduleDate], [subject] + '' + [scheduleTime] + '～' AS item, [uid] FROM [Schedule] WHERE ([uid] = @uid) ORDER BY [scheduleDate], [scheduleTime]">
        <SelectParameters>
            <asp:Parameter Name="uid" DefaultValue="yamada" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</div>
</form>
</body>
</html>
