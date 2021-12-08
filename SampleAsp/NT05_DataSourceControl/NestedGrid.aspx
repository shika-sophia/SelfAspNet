<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NestedGrid.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT05_DataSourceControl.NestedGrid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>NestedGrid</title>
</head>
<body>
<form id="formNestedGrid" runat="server">
<div>
<%-- outer GridView --%>
<asp:GridView ID="outerGrid" runat="server"
    AutoGenerateColumns="False"
    DataSourceID="SelfAspDB_NestedGrid">
<Columns>
<asp:BoundField DataField="category"
    HeaderText="Category" SortExpression="category" />
<asp:TemplateField>
    <%-- inner ItemTemplate --%>
    <ItemTemplate>
        <asp:HiddenField ID="hdnCaterory" runat="server"
            Value='<%# Eval("category") %>' />
    <asp:GridView ID="gridSqlPlaceHolder" runat="server" 
        AutoGenerateColumns="False"
        DataKeyNames="id"
        DataSourceID="SelfAspDB_SplPlaceHolderGrid"
        EmptyDataText="Please Select Category." >
    <Columns>
        <asp:BoundField DataField="id" HeaderText="ID"
            ReadOnly="True" SortExpression="id" />
        <asp:ImageField DataImageUrlField="id"
            DataImageUrlFormatString="~/Image/{0}.jpg"
            HeaderText="Image" ReadOnly="True">
        </asp:ImageField>
        <asp:BoundField DataField="category" HeaderText="Category"
            SortExpression="category" />
        <asp:BoundField DataField="comment" HeaderText="Comment"
            SortExpression="comment" />
        <asp:BoundField
            DataField="updated"
            DataFormatString="{0:yyyy年MM月dd日(ddd)}"
            HeaderText="Updated"
            SortExpression="updated" />
        <asp:CheckBoxField DataField="favorite" HeaderText="Favorite"
            SortExpression="favorite" />
    </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SelfAspDB_SplPlaceHolderGrid" runat="server"
        ConnectionString="<%$ ConnectionStrings:SelfAspDB %>"
        SelectCommand="SELECT [Id], [category], [comment], [updated], [favorite] 
            FROM [Album] WHERE ([category] = @category)">
    <SelectParameters>
        <asp:ControlParameter
            ControlID="hdnCaterory" 
            Name="category"
            PropertyName="Value"
            Type="String" />
    </SelectParameters>
    </asp:SqlDataSource>
    </ItemTemplate>
    <%-- inner END --%>
<%-- outer Tail --%>
</asp:TemplateField>
</Columns>
</asp:GridView>
<asp:SqlDataSource ID="SelfAspDB_NestedGrid" runat="server"
    ConnectionString="<%$ ConnectionStrings:SelfAspDB %>"
    SelectCommand="SELECT DISTINCT [category] FROM [Album] ORDER BY [category]">
</asp:SqlDataSource>
</div>
</form>
</body>
</html>
