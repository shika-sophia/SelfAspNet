<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="FormViewAlbum.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT04_DataBindControl.FormViewAlbum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>FormViewAlbum</title>
</head>
<body>
<form id="formFormViewAlbum" runat="server">
<div>
<asp:FormView ID="fvAlbum" runat="server"
    AllowPaging="True"
    DataKeyNames="Id"
    DataSourceID="sds"
    HeaderText="私のアルバム (単票)">
<EditItemTemplate>
    アルバムID:
    <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>' />
    <br />
    分類:
    <asp:TextBox ID="txtCategory" runat="server"
        Text='<%# Bind("category") %>' />
    <br />
    備考:
    <asp:TextBox ID="txtComment" runat="server"
        Text='<%# Bind("comment") %>' />
    <br />
    最終更新日:
    <asp:TextBox ID="txtUpdated" runat="server"
        Text='<%# Bind("updated") %>' />
    <br />
    お気に入り:
    <asp:CheckBox ID="checkFavorite" runat="server"
        Checked='<%# Bind("favorite") %>' />
    <br />
    <asp:LinkButton ID="btnUpdate" runat="server"
        CausesValidation="True"
        CommandName="Update"
        Text="更新" />&nbsp;
    <asp:LinkButton ID="btnUpdateCancel" runat="server"
        CausesValidation="False"
        CommandName="Cancel"
        Text="キャンセル" />
</EditItemTemplate>
<InsertItemTemplate>
    アルバムID:
    <asp:TextBox ID="IdTextBox" runat="server"
        Text='<%# Bind("Id") %>' />
    <br />
    分類:
    <asp:TextBox ID="categoryTextBox" runat="server"
        Text='<%# Bind("category") %>' />
    <br />
    備考:
    <asp:TextBox ID="commentTextBox" runat="server"
        Text='<%# Bind("comment") %>' />
    <br />
    最終更新日:
    <asp:TextBox ID="updatedTextBox" runat="server"
        Text='<%# Bind("updated") %>' />
    <br />
    お気に入り:
    <asp:CheckBox ID="favoriteCheckBox" runat="server"
        Checked='<%# Bind("favorite") %>' />
    <br />
    <asp:LinkButton ID="InsertButton" runat="server"
        CausesValidation="True"
        CommandName="Insert"
        Text="挿入" />
    &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server"
        CausesValidation="False"
        CommandName="Cancel"
        Text="キャンセル" />
</InsertItemTemplate>
<ItemTemplate>
    <asp:Image ID="Image1" runat="server"
        ImageUrl='<%# Eval("Id", "~/Image/{0}.jpg") %>'
        AlternateText='<%# Eval("Id") %>' />
    <br />
    アルバムID:
    <asp:Label ID="IdLabel" runat="server"
        Text='<%# Eval("Id") %>' />
    <br />
    分類:
    <asp:Label ID="categoryLabel" runat="server"
        Text='<%# Bind("category") %>' />
    <br />
    備考:
    <asp:Label ID="commentLabel" runat="server"
        Text='<%# Bind("comment") %>' />
    <br />
    最終更新日:
    <asp:Label ID="updatedLabel" runat="server" 
        Text='<%# Bind("updated", "{0:yyyy/MM/dd}") %>' />
    <br />
    favorite:
    <asp:CheckBox ID="favoriteCheckBox" runat="server"
        Checked='<%# Bind("favorite") %>' Enabled="True" />
    <br />
    <br />
    <asp:LinkButton ID="btnEdit" runat="server"
        CausesValidation="false"
        CommandName="Edit"
        Text="編集"></asp:LinkButton>&nbsp;
    <asp:LinkButton ID="btnDelete" runat="server"
        CausesValidation="false"
        CommandName="Delete"
        OnClientClick="return confirm('削除してもいいですか？')"
        Text="削除"></asp:LinkButton>&nbsp;
    <asp:LinkButton ID="btnInsert" runat="server"
        CausesValidation="false"
        CommandName="New"
        Text="新規登録"></asp:LinkButton><br />
</ItemTemplate>
</asp:FormView>

<asp:SqlDataSource ID="sds" runat="server"
    ConnectionString="<%$ ConnectionStrings:SelfAspDB %>"
    SelectCommand="SELECT [Id], [category], [comment], [updated], [favorite] FROM [Album] ORDER BY [updated] DESC"
    InsertCommand="INSERT INTO [Album] ([Id], [category], [comment], [updated], [favorite]) VALUES (@Id, @category, @comment, @updated, @favorite)"
    UpdateCommand="UPDATE [Album] SET [category] = @category, [comment] = @comment, [updated] = @updated, [favorite] = @favorite WHERE [Id] = @Id"
    DeleteCommand="DELETE FROM [Album] WHERE [Id] = @Id" >
    <InsertParameters>
        <asp:Parameter Name="Id" Type="String" />
        <asp:Parameter Name="category" Type="String" />
        <asp:Parameter Name="comment" Type="String" />
        <asp:Parameter DbType="Date" Name="updated" />
        <asp:Parameter Name="favorite" Type="Boolean" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="category" Type="String" />
        <asp:Parameter Name="comment" Type="String" />
        <asp:Parameter DbType="Date" Name="updated" />
        <asp:Parameter Name="favorite" Type="Boolean" />
        <asp:Parameter Name="Id" Type="String" />
    </UpdateParameters>
    <DeleteParameters>
        <asp:Parameter Name="Id" Type="String" />
    </DeleteParameters>
</asp:SqlDataSource>
</div>
</form>
</body>
</html>
