<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="FormViewMod.aspx.cs" 
    Inherits="SelfAspNet.SampleAsp.NT04_DataBindControl.FormViewMod" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>FromViewMod</title>
</head>
<body>
<form id="formFVmod" runat="server">
<div>
<asp:FormView ID="formViewMod" runat="server" 
        AllowPaging="True"
        CellPadding="4" 
        BackColor="White" BorderColor="#DEDFDE"
        BorderStyle="None" BorderWidth="1px" 
        ForeColor="Black" GridLines="Vertical"
        DataKeyNames="isbn"
        DataSourceID="sds"
        ShowSummary="False">

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
            Text='<%# Bind("isbn") %>' />
        <asp:RegularExpressionValidator
            ID="regexIsbn" runat="server"
            ErrorMessage="ISBNは [978-4-xxxxx-xxxxx-x]の形式で入力してください。"
            Text="*" 
            ControlToValidate="isbnTextBox"
            ValidationExpression="978-\d{1}-\d{3-5}-\d{3-5}-[a-zA-Z0-9]{1}"></asp:RegularExpressionValidator>
        <br />
        Title:<br />
        <asp:TextBox ID="titleTextBox" runat="server"
            Text='<%# Bind("title") %>' /><br />
        Price:<br />
        <asp:TextBox ID="priceTextBox" runat="server"
            Text='<%# Bind("price") %>' />
        <asp:RangeValidator ID="rangePrice" runat="server"
            ErrorMessage="Priceは [ 0 - 10,000 ] の範囲で入力してください。"
            Text="*"
            ControlToValidate="priceTextBox"
            Type="Integer"
            MaximumValue="10000"
            MinimumValue="0"></asp:RangeValidator>
        <br />
        Publisher:<br />
        <asp:TextBox ID="publisherTextBox" runat="server"
            Text='<%# Bind("publisher") %>' />
        <asp:DropDownList ID="dropListPublisher" runat="server"
            DataSourceID="sds_dropListPublisher"
            DataTextField="publisher"
            DataValueField="publisher">
        </asp:DropDownList>
        <asp:SqlDataSource ID="sds_dropListPublisher" runat="server"
            ConnectionString="<%$ ConnectionStrings:SelfAspDB %>"
            SelectCommand="SELECT DISTINCT [publisher] FROM [Book]"></asp:SqlDataSource>
        <br />
        Published Date:<br />
        <asp:TextBox ID="publishDateTextBox" runat="server"
            Text='<%# Bind("publishDate") %>' />
        <asp:CompareValidator ID="cmpDate" runat="server"
            ErrorMessage="日付は [xxxx-xx-xx]の形式で入力してください。"
            Text="*"
            ControlToValidate="publishDateTextBox"
            Operator="DataTypeCheck"
            Type="Date"></asp:CompareValidator>
        <br />
        CD-ROM:
        <asp:CheckBox ID="cdromCheckBox" runat="server" 
            Checked='<%# Bind("cdrom") %>' /><br />
        <br />
        <asp:LinkButton ID="InsertButton" runat="server"
            CausesValidation="True"
            CommandName="Insert"
            Text="挿入" />
        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server"
            CausesValidation="False"
            CommandName="Cancel"
            Text="キャンセル" />
        <br />
        <asp:ValidationSummary ID="summaryInsert" runat="server"
            ShowSummary="true"
            DisplayMode="BulletList" />
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
            CausesValidation="False"
            CommandName="Delete"
            Text="削除"
            OnClientClick="return confirm('DELETE OK?')" />
        &nbsp;<asp:LinkButton ID="NewButton" runat="server"
            CausesValidation="False"
            CommandName="New"
            Text="新規作成" />        
    </ItemTemplate>
    <PagerStyle BackColor="#F7F7DE"
        ForeColor="Black"
        HorizontalAlign="Right" />
    <RowStyle BackColor="#F7F7DE" />
</asp:FormView>
<asp:SqlDataSource ID="sds" runat="server"
    ConnectionString="<%$ ConnectionStrings:SelfAspDB %>"
    SelectCommand="SELECT [isbn], [title], [price], [publisher], [publishDate], [cdrom] FROM [Book] ORDER BY [publishDate]"
    InsertCommand="INSERT INTO [Book] ([isbn], [title], [price], [publisher], [publishDate], [cdrom]) VALUES (@isbn, @title, @price, @publisher, @publishDate, @cdrom)"
    UpdateCommand="UPDATE [Book] SET [title] = @title, [price] = @price, [publisher] = @publisher, [publishDate] = @publishDate, [cdrom] = @cdrom WHERE [isbn] = @isbn"
    DeleteCommand="DELETE FROM [Book] WHERE [isbn] = @isbn" >
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
<p>
    <asp:Button ID="btnGridViewBook" runat="server"
        Text="GridViewBook"
        OnClick="btnGridViewBook_Click" />
</p>
</form>
</body>
</html>
