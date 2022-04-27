<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="ChartCombinationGraph.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT09_RichControl.ChartGraph.ChartCombinationGraph" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ChartCombinationGraph</title>
</head>
<body>
<form id="formChartCombinationGraph" runat="server">
<div>
<asp:Chart ID="chartComb" runat="server"
    DataSourceID="sds"
    ImageType="Jpeg"
    Width="600px" Height="400px">
    <Series>
        <asp:Series Name="Series1"
            ChartArea="ChartArea1"
            ChartType="Column"
            XValueMember="dating"
            YValueMembers="volume"
            YAxisType="Secondary"></asp:Series>
        <asp:Series Name="Series2"
            ChartArea="ChartArea1"
            ChartType="Candlestick"
            XValueMember="dating"
            YValueMembers="high,low,opening,closing"
            YValuesPerPoint="4" ></asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1">
            <AxisX Title="日付"></AxisX>
            <AxisY Maximum="1600" Minimum="800" Title="株価"></AxisY>
            <AxisY2 Maximum="2000" Minimum="200" Title="出来高"></AxisY2>
        </asp:ChartArea>
    </ChartAreas>
    <Titles>
        <asp:Title Name="Title1" Text="今月の株価情報">
        </asp:Title>
    </Titles>
</asp:Chart>
<asp:SqlDataSource ID="sds" runat="server"
    ConnectionString="<%$ ConnectionStrings:SelfAspDB %>" 
    SelectCommand="SELECT [dating], [opening], [high], [low], [closing], [volume] FROM [Stock] WHERE ([brand] = @brand)">
    <SelectParameters>
        <asp:Parameter 
            DefaultValue="28710" Name="brand" Type="Int32" />
    </SelectParameters>
</asp:SqlDataSource>
</div>
</form>
</body>
</html>
