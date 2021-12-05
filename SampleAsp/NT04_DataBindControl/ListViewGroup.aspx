<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListViewGroup.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT04_DataBindControl.ListViewGroup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ListViewGroup</title>
</head>
<body>
<form id="formListViewGroup" runat="server">
<div>
<%-- ==== ListView ==== --%>
<asp:ListView ID="listViewGroup" runat="server"
        DataKeyNames="isbn"
        DataSourceID="SelfAspDB_ListViewGroup"
        GroupItemCount="3" InsertItemPosition="LastItem">

<%-- Layout, Pager, Group --%>
<LayoutTemplate>
    <table runat="server">
    <tr runat="server">
        <td runat="server">
            <table id="groupPlaceholderContainer" runat="server"
                    border="1" style="background-color: #FFFFFF;
                    border-collapse: collapse;border-color: #999999;
                    border-style:none;border-width:1px;
                    font-family: Verdana, Arial, Helvetica, sans-serif;">
                <tr id="groupPlaceholder" runat="server"></tr>
            </table>
        </td>
    </tr>
    <tr runat="server">
        <td runat="server" style="text-align: center;background-color: #CCCCCC;
                font-family: Verdana, Arial, Helvetica, sans-serif;
                color: #000000;">
            <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                <Fields>
                    <asp:NextPreviousPagerField ButtonType="Button"
                        ShowFirstPageButton="True"
                        ShowLastPageButton="True" />
                </Fields>
            </asp:DataPager>
        </td>
    </tr>
    </table>
</LayoutTemplate>
<GroupTemplate>
    <tr id="itemPlaceholderContainer" runat="server">
        <td id="itemPlaceholder" runat="server"></td>
    </tr>
</GroupTemplate>

<%-- Item, Alternating --%>
<ItemTemplate>
    <td runat="server" style="background-color:#DCDCDC;color: #000000;">
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
        <%--
        <asp:CheckBox ID="cdromCheckBox" runat="server"
            Checked='<%# Eval("cdrom") %>' Enabled="false" Text="" /><br />
        --%>
        <br />
        <asp:Button ID="EditButton" runat="server"
            CommandName="Edit" Text="編集" />&nbsp;
        <asp:Button ID="DeleteButton" runat="server"
            CommandName="Delete" Text="削除"
            OnClientClick='return confirm("DELETE OK?")' /><br />
    </td>
</ItemTemplate>
<AlternatingItemTemplate>
    <td runat="server" style="background-color:#FFF8DC;">
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
        <%--
        <asp:CheckBox ID="cdromCheckBox" runat="server"
            Checked='<%# Eval("cdrom") %>' Enabled="false" Text="" /><br />
        --%>
        <br />
        <asp:Button ID="EditButton" runat="server"
            CommandName="Edit" Text="編集" />&nbsp;
        <asp:Button ID="DeleteButton" runat="server"
            CommandName="Delete" Text="削除"
            OnClientClick='return confirm("DELETE OK?")' /><br />
    </td>
</AlternatingItemTemplate>

<%-- Edit, Insert, Empty --%>
<EditItemTemplate>
    <td runat="server" style="background-color:#008A8C;color: #FFFFFF;">
        <asp:Image ID="ImageListView" runat="server"
            ImageUrl='<%# Eval("isbn", "https://wings.msn.to/books/{0}/{0}.jpg") %>'
            Width="110px" Height="160px"
            AlternateText='<%# Eval("title") %>' /><br />
        <br />
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
            Text='<%# Bind("publishDate", "{0:yyyy/MM/dd}") %>' /><br />
        CD-ROM:&nbsp;
        <asp:CheckBox ID="cdromCheckBox" runat="server"
            Checked='<%# Bind("cdrom") %>' Text="" /><br />
        <br />
        <asp:Button ID="UpdateButton" runat="server"
            CommandName="Update" Text="更新" />&nbsp;
        <asp:Button ID="CancelButton" runat="server"
            CommandName="Cancel" Text="キャンセル" /><br />
    </td>
</EditItemTemplate>
<InsertItemTemplate>
    <td runat="server" style="">
        <br />
        <asp:Image ID="ImageListView" runat="server"
            ImageUrl='<%# Eval("isbn", "https://wings.msn.to/books/{0}/{0}.jpg") %>'
            Width="110px" Height="160px"
            AlternateText='<%# Eval("title") %>' /><br />
        <br />
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
            Text='<%# Bind("publishDate", "{0:yyyy/MM/dd}") %>' /><br />
        CD-ROM:&nbsp;
        <asp:CheckBox ID="cdromCheckBox" runat="server"
            Checked='<%# Bind("cdrom") %>' Text="" /><br />
        <br />
        <asp:Button ID="InsertButton" runat="server"
            CommandName="Insert" Text="新規登録" />&nbsp;
        <asp:Button ID="CancelButton" runat="server"
            CommandName="Cancel" Text="クリア" /><br />
    </td>
</InsertItemTemplate>
<EmptyItemTemplate>
    <td runat="server">
        <asp:Image ID="ImageListView" runat="server"
            ImageUrl="https://wings.msn.to/image/wings.jpg"
            AlternateText='EmptyImage' /><br />
        <br />
    </td>
</EmptyItemTemplate>
<EmptyDataTemplate>
    <table runat="server" style="background-color: #FFFFFF;
            border-collapse: collapse;border-color: #999999;
            border-style:none;border-width:1px;">
        <tr>
            <td>( No Data )</td>
        </tr>
    </table>
</EmptyDataTemplate>
</asp:ListView>

<%-- ==== DataSource ==== --%>
<asp:SqlDataSource ID="SelfAspDB_ListViewGroup" runat="server"
    ConnectionString="<%$ ConnectionStrings:SelfAspDB %>"
    SelectCommand="
        SELECT [isbn], [title], [price], [publisher], [publishDate], [cdrom]
        FROM [Book] ORDER BY [publishDate] DESC"
    InsertCommand="
        INSERT INTO [Book] ([isbn], [title], [price], [publisher], [publishDate], [cdrom])
        VALUES (@isbn, @title, @price, @publisher, @publishDate, @cdrom)"
    UpdateCommand="
        UPDATE [Book] 
        SET [title] = @title, [price] = @price, [publisher] = @publisher, 
            [publishDate] = @publishDate, [cdrom] = @cdrom 
        WHERE [isbn] = @isbn"
    DeleteCommand="DELETE FROM [Book] WHERE [isbn] = @isbn" >
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
