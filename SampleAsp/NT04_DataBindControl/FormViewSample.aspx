<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="FormViewSample.aspx.cs" 
    Inherits="SelfAspNet.SampleAsp.NT04_DataBindControl.FormViewSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>FromViewSample</title>
</head>
<body>
    <form id="formFV" runat="server">
        <div>
            <asp:FormView ID="formViewSample" runat="server" 
                    AllowPaging="True"
                    CellPadding="4" 
                    BackColor="White" BorderColor="#DEDFDE"
                    BorderStyle="None" BorderWidth="1px" 
                    ForeColor="Black" GridLines="Vertical"
                    DataKeyNames="isbn"
                    DataSourceID="SelfAspDB_FormView">

                <EditItemTemplate>
                    ISBN:<br />
                    <asp:Label ID="isbnLabel" runat="server" 
                        Text='<%# Eval("isbn") %>' />
                    <br />
                    Title:<br />
                    <asp:TextBox ID="titleTextBox" runat="server"
                        Text='<%# Bind("title") %>' /><br />
                    Price:<br />
                    <asp:TextBox ID="priceTextBox" runat="server"
                        Text='<%# Bind("price") %>' /><br />
                    Publisher:<br />
                    <asp:TextBox ID="publisherTextBox" runat="server"
                        Text='<%# Bind("publisher") %>' /><br />
                    Published Date:<br />
                    <asp:TextBox ID="publishDateTextBox" runat="server"
                        Text='<%# Bind("publishDate", "{0:yyyy/MM/dd}") %>' /><br />
                    CD-ROM:&nbsp;
                    <asp:CheckBox ID="cdromCheckBox" runat="server"
                        Checked='<%# Bind("cdrom") %>' /><br />
                    <br />
                    <asp:LinkButton ID="UpdateButton" runat="server"
                        CausesValidation="True" CommandName="Update" Text="更新" />
                    &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server"
                        CausesValidation="False" CommandName="Cancel" Text="キャンセル" />
                </EditItemTemplate>
                <EditRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                
                <InsertItemTemplate>
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
                    Published Date:<br />
                    <asp:TextBox ID="publishDateTextBox" runat="server"
                        Text='<%# Bind("publishDate") %>' /><br />
                    CD-ROM:
                    <asp:CheckBox ID="cdromCheckBox" runat="server" 
                        Checked='<%# Bind("cdrom") %>' /><br />
                    <br />
                    <asp:LinkButton ID="InsertButton" runat="server"
                        CausesValidation="True" CommandName="Insert" Text="挿入" />
                    &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server"
                        CausesValidation="False" CommandName="Cancel" Text="キャンセル" />
                </InsertItemTemplate>

                <ItemTemplate>
                    <asp:Image ID="ImageFormView" runat="server"
                        Width="110px" Height="160px"
                        AlternateText='<%# Eval("title") %>'
                        ImageUrl='<%# Eval("isbn", "https://wings.msn.to/books/{0}/{0}.jpg") %>' /><br />
                    <br />
                    ISBN:&nbsp;
                    <asp:Label ID="isbnLabel" runat="server"
                        Text='<%# Eval("isbn") %>' /><br />
                    Title:&nbsp;
                    <asp:Label ID="titleLabel" runat="server"
                        Text='<%# Eval("title") %>' /><br />
                    Price:&nbsp;
                    <asp:Label ID="priceLabel" runat="server"
                        Text='<%# Eval("price", "{0:##,###円}") %>' /><br />
                    Publisher:&nbsp;
                    <asp:Label ID="publisherLabel" runat="server"
                        Text='<%# Eval("publisher") %>' /><br />
                    Published Date:&nbsp;
                    <asp:Label ID="publishDateLabel" runat="server"
                        Text='<%# Eval("publishDate", "{0:yyyy年MM月dd日}") %>' /><br />
                    CD-ROM:&nbsp;
                    <asp:CheckBox ID="cdromCheckBox" runat="server"
                        Checked='<%# Eval("cdrom") %>' Enabled="false" /><br />
                    <br />
                    <asp:LinkButton ID="EditButton" runat="server"
                        CausesValidation="False" CommandName="Edit" Text="編集" />
                    &nbsp;<asp:LinkButton ID="DeleteButton" runat="server"
                        CausesValidation="False" CommandName="Delete" Text="削除"
                        OnClientClick="return confirm('DELETE OK?')" />
                    &nbsp;<asp:LinkButton ID="NewButton" runat="server"
                        CausesValidation="False" CommandName="New" Text="新規作成" />
                </ItemTemplate>
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
            </asp:FormView>
            <asp:SqlDataSource ID="SelfAspDB_FormView" runat="server" ConnectionString="<%$ ConnectionStrings:SelfAspDB %>" DeleteCommand="DELETE FROM [Book] WHERE [isbn] = @isbn" InsertCommand="INSERT INTO [Book] ([isbn], [title], [price], [publisher], [publishDate], [cdrom]) VALUES (@isbn, @title, @price, @publisher, @publishDate, @cdrom)" SelectCommand="SELECT [isbn], [title], [price], [publisher], [publishDate], [cdrom] FROM [Book] ORDER BY [publishDate] DESC" UpdateCommand="UPDATE [Book] SET [title] = @title, [price] = @price, [publisher] = @publisher, [publishDate] = @publishDate, [cdrom] = @cdrom WHERE [isbn] = @isbn">
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
        <p>
            <asp:Button ID="btnListView" runat="server"
                Text="ListView"
                OnClick="btnListView_Click" />
        </p>
    </form>
</body>
</html>
