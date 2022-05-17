<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="GridFriendly.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT10_FlagmentObject.FriendlyUrlsDiv.GridFriendly" %>
<%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>GridFriendly</title>
</head>
<body>
<form id="formGridFriendly" runat="server">
<div>
<asp:GridView ID="grid" runat="server"
    AutoGenerateColumns="False"
    DataKeyNames="Id"
    DataSourceID="sds">
    <Columns>
        <asp:TemplateField HeaderText="Id" SortExpression="Id">
            <EditItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:HyperLink ID="link" runat="server"
                    NavigateUrl='<%#: FriendlyUrl.Href("~/album", Eval("id")) %>'
                    Text='<%#: Eval("id") %>'></asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="category" HeaderText="category" SortExpression="category" />
        <asp:BoundField DataField="comment" HeaderText="comment" SortExpression="comment" />
        <asp:BoundField DataField="updated" HeaderText="updated" SortExpression="updated" />
        <asp:CheckBoxField DataField="favorite" HeaderText="favorite" SortExpression="favorite" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="sds" runat="server" 
    ConnectionString="<%$ ConnectionStrings:SelfAspDB %>"
    SelectCommand="SELECT [Id], [category], [comment], [updated], [favorite] FROM [Album] ORDER BY [updated] DESC">

</asp:SqlDataSource>
</div>
</form>
</body>
</html>
