<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="ObjectDataSourceSample.aspx.cs" 
    Inherits="SelfAspNet.SampleAsp.NT05_DataSourceControl.ObjectDataSourceSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ObjectDataSourceSample</title>
</head>
<body>
<form id="formObjectDataSourceSample" runat="server">
<div>
    <%-- RadioButtonList with DataSource --%>
    Album Category:<br />
    <asp:RadioButtonList ID="listCat" runat="server"
        Items="(No Select)"
        AppendDataBoundItems="True"
        RepeatDirection="Horizontal"
        AutoPostBack="True"
        DataSourceID="SelfAspDB_SqlPlaceHolder"
        DataTextField="category"
        DataValueField="category">
        <asp:ListItem Selected="True">(No Selected)</asp:ListItem>
    </asp:RadioButtonList>
    <asp:SqlDataSource ID="SelfAspDB_SqlPlaceHolder" runat="server"
        ConnectionString="<%$ ConnectionStrings:SelfAspDB %>"
        SelectCommand="
            SELECT DISTINCT [category] FROM [Album]
            ORDER BY [category]">
    </asp:SqlDataSource>

    <%-- GridView --%>
    <asp:GridView ID="gridObjectDataSourceSample" runat="server" 
        AutoGenerateColumns="False"
        DataKeyNames="id"
        DataSourceID="ods"
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
            <asp:TemplateField HeaderText="Action" ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="ButtonDelete" runat="server"
                        CausesValidation="False"
                        CommandName="Delete"
                        OnClientClick="return confirm('<!> DELETE this Record OK?')"
                        Text="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ods" runat="server"
        SelectMethod="GetAlbumData"
        DeleteMethod="DeleteAlbumData"
        TypeName="SelfAspNet.SampleAsp.NT05_DataSourceControl.ObjectDataSource.AlbumDao">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="String" />
        </DeleteParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="listCat" Name="category"
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</div>
</form>
</body>
</html>
