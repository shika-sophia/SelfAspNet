<%@ Control Language="C#" AutoEventWireup="true"
    CodeBehind="UserControlSample.ascx.cs"
    Inherits="SelfAspNet.SampleAsp.NT10_FlagmentObject.UserControl.UserControlSample" %>

<%@ OutputCache Duration="120" VaryByParam="*" %>

<asp:Calendar ID="calenSche" runat="server"
    OnDayRender="calenSche_DayRender" 
    VisibleDate="2019-12-01"></asp:Calendar>
<asp:SqlDataSource ID="sds" runat="server"
    ConnectionString="<%$ ConnectionStrings:SelfAspDB %>"
    SelectCommand=
        "SELECT [scheduleDate], [subject] + '' + [scheduleTime] + '～' AS item, [uid] FROM [Schedule] WHERE ([uid] = @uid) ORDER BY [scheduleDate], [scheduleTime]">
    <SelectParameters>
        <asp:Parameter Name="uid"
            DefaultValue="yamada" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>
