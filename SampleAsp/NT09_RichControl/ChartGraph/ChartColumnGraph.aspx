<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="ChartColumnGraph.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT09_RichControl.ChartGraph.ChartColumnGraph" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ChartColumnGraph</title>
</head>
<body>
<form id="formChartColumnGraph" runat="server">
<div>
    <asp:Chart ID="chartColumn" runat="server"
        DataSourceID="sds"
        ImageType="Jpeg"
        Width="600px" Height="300px">
        <series>
            <asp:Series Name="Series1"
                ChartArea="ChartArea1"
                ChartType="Column"
                XValueMember="dating"
                YValueMembers="volume">
            </asp:Series>
        </series>
        <chartareas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </chartareas>
        <Titles>
            <asp:Title Name="今月の取引高"
                Text="今月の取引高"
                Visible="true"></asp:Title>
        </Titles>
    </asp:Chart>
    <asp:SqlDataSource ID="sds" runat="server"
        ConnectionString="<%$ ConnectionStrings:SelfAspDB %>" 
        SelectCommand="SELECT [dating], [opening], [high], [low], [closing], [volume] FROM [Stock] WHERE ([brand] = @brand) ORDER BY [dating]">
        <SelectParameters>
            <asp:Parameter DefaultValue="28710" Name="brand" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</div>
</form>
</body>
</html>
