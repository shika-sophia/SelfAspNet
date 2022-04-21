<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="GridViewBook.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT04_DataBindControl.GridViewBook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>GridViewBook</title>
</head>
<body>
<form id="formGridViewBook" runat="server">
<div>
    <asp:GridView ID="gridBook" runat="server"
        AllowPaging="True"
        AllowSorting="True"
        AutoGenerateColumns="False"
        DataKeyNames="isbn"
        DataSourceID="sds">
        <Columns>
            <asp:HyperLinkField
                HeaderText="ISBNコード"
                DataNavigateUrlFields="isbn"
                DataNavigateUrlFormatString="https://wings.msn.to/index.php/-/A-03/{0}/"
                DataTextField="isbn"
                DataTextFormatString="{0}"
                SortExpression="isbn" />
            <asp:BoundField DataField="title"
                HeaderText="書名"
                SortExpression="title" />
            <asp:BoundField DataField="publisher" 
                HeaderText="出版社"
                SortExpression="publisher" />
            <asp:BoundField DataField="publishDate"
                HeaderText="発売日"
                DataFormatString="{0:yy/MM/dd}"
                SortExpression="publishDate" />
            <asp:BoundField DataField="price"
                HeaderText="単価"
                DataFormatString="{0:0,000}円"
                SortExpression="price" />
            <asp:CheckBoxField DataField="cdrom"
                HeaderText="CD-ROM"
                SortExpression="cdrom" />
            <asp:CommandField 
                HeaderText="コマンド" 
                ShowEditButton="True"
                ShowDeleteButton="True"
                ButtonType="Button" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="sds" runat="server"
        ConnectionString="<%$ ConnectionStrings:SelfAspDB %>" 
        SelectCommand="SELECT [isbn], [title], [price], [publisher], [publishDate], [cdrom] FROM [Book] ORDER BY [publishDate]"
        InsertCommand="INSERT INTO [Book] ([isbn], [title], [price], [publisher], [publishDate], [cdrom]) VALUES (@isbn, @title, @price, @publisher, @publishDate, @cdrom)" 
        UpdateCommand="UPDATE [Book] SET [title] = @title, [price] = @price, [publisher] = @publisher, [publishDate] = @publishDate, [cdrom] = @cdrom WHERE [isbn] = @isbn"
        DeleteCommand="DELETE FROM [Book] WHERE [isbn] = @isbn">
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
        <DeleteParameters>
            <asp:Parameter Name="isbn" Type="String" />
        </DeleteParameters>
    </asp:SqlDataSource>
</div>
</form>
</body>
</html>
