<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="AlbumTypedDataSet.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT05_DataSourceControl.TypedDataSet.AlbumTypedDataSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>AlbumTypedDataSet</title>
</head>
<body>
<form id="formAlbumTypedDataSet" runat="server">
<div>
<asp:RadioButtonList ID="list" runat="server"
    AutoPostBack="true"
    AppendDataBoundItems="true"
    Items="(No Selected)" 
    RepeatDirection="Horizontal"
    DataSourceID="sds_list"
    DataTextField="category"
    DataValueField="category">
    <asp:ListItem Selected="True">(No Selected)</asp:ListItem>
</asp:RadioButtonList>
<asp:SqlDataSource ID="sds_list" runat="server"
    ConnectionString="<%$ ConnectionStrings:SelfAspDB %>"
    SelectCommand="SELECT DISTINCT [category] FROM [Album] ORDER BY [category]">
</asp:SqlDataSource>
<asp:GridView ID="gridTyped" runat="server"
    EmptyDataText="<！> [Categry] is not selected."
    AutoGenerateColumns="False"
    DataKeyNames="Id"
    DataSourceID="ods">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="Id" 
            ReadOnly="True" SortExpression="Id" />
        <asp:BoundField DataField="category"
            HeaderText="category" SortExpression="category" />
        <asp:BoundField DataField="comment"
            HeaderText="comment" SortExpression="comment" />
        <asp:BoundField DataField="updated"
            HeaderText="updated" SortExpression="updated" />
        <asp:CheckBoxField DataField="favorite"
            HeaderText="favorite" SortExpression="favorite" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="ods" runat="server"
    SelectMethod="GetAlbumData"
    TypeName="SelfAspNet.SampleAsp.NT05_DataSourceControl.TypedDataSet.AlbumDataSetTableAdapters.AlbumTableAdapter" 
    UpdateMethod="Update"
    InsertMethod="Insert"
    DeleteMethod="Delete"
    OldValuesParameterFormatString="original_{0}" >
    <DeleteParameters>
        <asp:Parameter Name="Original_Id" Type="String" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="Id" Type="String" />
        <asp:Parameter Name="category" Type="String" />
        <asp:Parameter Name="comment" Type="String" />
        <asp:Parameter Name="updated" Type="DateTime" />
        <asp:Parameter Name="favorite" Type="Boolean" />
    </InsertParameters>
    <SelectParameters>
        <asp:ControlParameter ControlID="list"
            Name="category"
            PropertyName="SelectedValue"
            Type="String" />
    </SelectParameters>
    <UpdateParameters>
        <asp:Parameter Name="category" Type="String" />
        <asp:Parameter Name="comment" Type="String" />
        <asp:Parameter Name="updated" Type="DateTime" />
        <asp:Parameter Name="favorite" Type="Boolean" />
        <asp:Parameter Name="Original_Id" Type="String" />
    </UpdateParameters>
</asp:ObjectDataSource>
</div>
</form>
</body>
</html>
