<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListViewSample.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT04_DataBindControl.ListViewSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ListViewSample</title>
</head>
<body>
<form id="formListView" runat="server">
<div>
<%-- ==== ListViewControl ==== --%>
<asp:ListView ID="listViewSample" runat="server"
    DataKeyNames="isbn"
    DataSourceID="SelfAspDB_ListView"
    InsertItemPosition="LastItem">

    <%-- Layout / Pager--%>
    <LayoutTemplate>
    <div id="itemPlaceholderContainer" runat="server"
        style="font-family: Verdana, Arial, Helvetica, sans-serif;">
        <span runat="server" id="itemPlaceholder" />
    </div>
    <div style="text-align: center;background-color: #5D7B9D;
            font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF;">
        <asp:DataPager ID="DataPager1" runat="server">
            <Fields>
                <asp:NextPreviousPagerField ButtonType="Button"
                    ShowFirstPageButton="True"
                    ShowLastPageButton="True" />
            </Fields>
        </asp:DataPager>
    </div>
    </LayoutTemplate>

    <%-- 標準表示モード / Item, Alternating --%>
    <ItemTemplate>
    <span style="background-color: #E0FFFF;color: #333333;">
        <asp:Image ID="ImageListView" runat="server"
            ImageUrl='<%# Eval("isbn", "https://wings.msn.to/books/{0}/{0}.jpg") %>'
            Width="110px" Height="160px"
            AlternateText='<%# Eval("title") %>' /><br />
        <br />
        ISBN:
        <asp:Label ID="isbnLabel" runat="server"
            Text='<%# Eval("isbn") %>' /><br />
        Title:
        <asp:Label ID="titleLabel" runat="server"
            Text='<%# Eval("title") %>' /><br />
        Price:
        <asp:Label ID="priceLabel" runat="server"
            Text='<%# Eval("price", "{0:##,###円}") %>' /><br />
        Publisher:
        <asp:Label ID="publisherLabel" runat="server"
            Text='<%# Eval("publisher") %>' /><br />
        Publish Date:
        <asp:Label ID="publishDateLabel" runat="server"
            Text='<%# Eval("publishDate", "{0:yyyy年MM月dd日}") %>' /><br />
        CD-ROM:&nbsp;
        <asp:CheckBox ID="cdromCheckBox" runat="server"
            Checked='<%# Eval("cdrom") %>' Enabled="false" Text="cdrom" /><br />
        <br />
        <asp:Button ID="EditButton" runat="server"
            CommandName="Edit" Text="編集" />
        <asp:Button ID="DeleteButton" runat="server"
            CommandName="Delete" Text="削除"
            OnClientClick="return confirm('DELETE OK?')" /><br />
        <br /></span>
    </ItemTemplate>
    <AlternatingItemTemplate>
    <span style="background-color: #FFFFFF; color: #284775;">
        <asp:Image ID="ImageListView" runat="server"
            ImageUrl='<%# Eval("isbn", "https://wings.msn.to/books/{0}/{0}.jpg") %>'
            Width="110px" Height="160px"
            AlternateText='<%# Eval("title") %>' /><br />
        ISBN:
        <asp:Label ID="isbnLabel" runat="server"
            Text='<%# Eval("isbn") %>' /><br />
        Title:
        <asp:Label ID="titleLabel" runat="server"
            Text='<%# Eval("title") %>' /><br />
        Price:
        <asp:Label ID="priceLabel" runat="server"
            Text='<%# Eval("price", "{0:##,###円}") %>' /><br />
        Publisher:
        <asp:Label ID="publisherLabel" runat="server"
            Text='<%# Eval("publisher") %>' /><br />
        Publish Date:
        <asp:Label ID="publishDateLabel" runat="server"
            Text='<%# Eval("publishDate", "{0:yyyy年MM月dd日}") %>' /><br />
        CD-ROM:&nbsp;
        <%-- 
        <asp:CheckBox ID="cdromCheckBox" runat="server"
            Checked='<%# Eval("cdrom") %>' Enabled="false" Text="cdrom" /><br />
        --%>
        <br />
        <asp:Button ID="EditButton" runat="server"
            CommandName="Edit" Text="編集" />
        <asp:Button ID="DeleteButton" runat="server"
            CommandName="Delete" Text="削除"
            OnClientClick="return confirm('DELETE OK?')"/><br />
        <br /></span>
    </AlternatingItemTemplate>

    <%-- 編集,挿入,モード / Edit, Insert --%>
    <EditItemTemplate>
    <span style="background-color: #999999;">
        <asp:Image ID="ImageListView" runat="server"
            ImageUrl='<%# Eval("isbn", "https://wings.msn.to/books/{0}/{0}.jpg") %>'
            Width="110px" Height="160px"
            AlternateText='<%# Eval("title") %>' /><br />
        ISBN:<br />
        <asp:Label ID="isbnLabel1" runat="server"
            Text='<%# Eval("isbn") %>' /><br />
        Title:<br />
        <asp:TextBox ID="titleTextBox" runat="server"
            Text='<%# Bind("title") %>' /><br />
        Price:<br />
        <asp:TextBox ID="priceTextBox" runat="server"
            Text='<%# Bind("price") %>' /><br />
        Publisher:<br />
        <asp:TextBox ID="publisherTextBox" runat="server"
            Text='<%# Bind("publisher") %>' /><br />
        Publish Date:<br />
        <asp:TextBox ID="publishDateTextBox" runat="server"
            Text='<%# Bind("publishDate") %>' /><br />
        CD_ROM:&nbsp;
        <asp:CheckBox ID="cdromCheckBox" runat="server"
            Checked='<%# Bind("cdrom") %>' Text="cdrom" /><br />
        <br />
        <asp:Button ID="UpdateButton" runat="server"
            CommandName="Update" Text="更新" />
        <asp:Button ID="CancelButton" runat="server"
            CommandName="Cancel" Text="キャンセル" /><br />
        <br /></span>
    </EditItemTemplate>
    <InsertItemTemplate>
    <span style="">
        ISBN:<br />
        <asp:TextBox ID="isbnTextBox" runat="server"
            Text='<%# Bind("isbn") %>' /><br />
        Title:<br />
        <asp:TextBox ID="titleTextBox" runat="server"
            Text='<%# Bind("title") %>' /><br />
        Price:<br />
        <asp:TextBox ID="priceTextBox" runat="server"
            Text='<%# Bind("price") %>' /><br />
        Publisher:<br />
        <asp:TextBox ID="publisherTextBox" runat="server"
            Text='<%# Bind("publisher") %>' /><br />
        Publish Date:<br />
        <asp:TextBox ID="publishDateTextBox" runat="server"
            Text='<%# Bind("publishDate") %>' /><br />
        CD_ROM:&nbsp;
        <asp:CheckBox ID="cdromCheckBox" runat="server"
            Checked='<%# Bind("cdrom") %>' Text="cdrom" /><br />
        <br />
        <asp:Button ID="InsertButton" runat="server"
            CommandName="Insert" Text="新規登録" />
        <asp:Button ID="CancelButton" runat="server"
            CommandName="Cancel" Text="キャンセル" /><br />
        <br /></span>
    </InsertItemTemplate>

    <%-- EmptySet --%>
    <EmptyDataTemplate>
        <span>(データなし)</span>
    </EmptyDataTemplate>
</asp:ListView>

<%-- ==== DataSource ==== --%>
<asp:SqlDataSource ID="SelfAspDB_ListView" runat="server"
    ConnectionString="<%$ ConnectionStrings:SelfAspDB %>"
    DeleteCommand="DELETE FROM [Book] WHERE [isbn] = @isbn"
    InsertCommand="
        INSERT INTO [Book] (
            [isbn], [title], [price], [publisher], [publishDate], [cdrom])
        VALUES (@isbn, @title, @price, @publisher, @publishDate, @cdrom)"
    SelectCommand="
        SELECT [isbn], [title], [price], [publisher], [publishDate], [cdrom] 
        FROM [Book] ORDER BY [publishDate] DESC"
    UpdateCommand="
        UPDATE [Book] 
        SET [title] = @title, [price] = @price, [publisher] = @publisher,
            [publishDate] = @publishDate, [cdrom] = @cdrom
        WHERE [isbn] = @isbn">
    <DeleteParameters>
        <asp:Parameter Name="isbn" Type="String" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="isbn" Type="String" />
        <asp:Parameter Name="title" Type="String" />
        <asp:Parameter Name="price" Type="Int32" />
        <asp:Parameter Name="publisher" Type="String" />
        <asp:Parameter DbType="Date" Name="publishDate" />
        <asp:Parameter Name="cdrom" Type="Boolean" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="title" Type="String" />
        <asp:Parameter Name="price" Type="Int32" />
        <asp:Parameter Name="publisher" Type="String" />
        <asp:Parameter DbType="Date" Name="publishDate" />
        <asp:Parameter Name="cdrom" Type="Boolean" />
        <asp:Parameter Name="isbn" Type="String" />
    </UpdateParameters>
</asp:SqlDataSource>
</div>
</form>
</body>
</html>
