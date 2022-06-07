<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="MultiViewBook.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT09_RichControl.MultiViewControl.MultiViewBook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>MultiViewBook</title>
</head>
<body>
<form id="formMultiViewBook" runat="server">
<div>
<asp:MultiView ID="multi" runat="server" ActiveViewIndex="0">
    <asp:View ID="view1" runat="server">
        <asp:GridView ID="grid" runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="isbn"
            DataSourceID="sds"
            OnSelectedIndexChanged="grid_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                <asp:BoundField DataField="publisher" HeaderText="publisher" SortExpression="publisher" />
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="sds" runat="server"
            ConnectionString="<%$ ConnectionStrings:SelfAspDB %>"
            SelectCommand="SELECT [isbn], [title], [price], [publisher], [publishDate], [cdrom] FROM [Book] ORDER BY [publishDate] DESC">
        </asp:SqlDataSource>
    </asp:View>
    <asp:View ID="view2" runat="server">
        <asp:FormView ID="FormView1" runat="server"
            DataKeyNames="isbn" 
            DataSourceID="sdsDetail">            
            <ItemTemplate>
                <asp:Image ID="imageView2" runat="server"
                    ImageUrl='<%# Eval("isbn", "https://wings.msn.to/books/{0}/{0}.jpg") %>'
                    Width="100px" Height="160px"
                    AlternateText='<%# Eval("title") %>'/><br />
                isbn:
                <asp:Label ID="isbnLabel" runat="server" Text='<%# Eval("isbn") %>' />
                <br />
                title:
                <asp:Label ID="titleLabel" runat="server" Text='<%# Bind("title") %>' />
                <br />
                price:
                <asp:Label ID="priceLabel" runat="server" Text='<%# Bind("price") %>' />
                <br />
                publisher:
                <asp:Label ID="publisherLabel" runat="server" Text='<%# Bind("publisher") %>' />
                <br />
                publishDate:
                <asp:Label ID="publishDateLabel" runat="server" Text='<%# Bind("publishDate") %>' />
                <br />
                cdrom:
                <asp:CheckBox ID="cdromCheckBox" runat="server" Checked='<%# Bind("cdrom") %>' Enabled="false" />
                <br />
            </ItemTemplate>
        </asp:FormView>
        <asp:SqlDataSource ID="sdsDetail" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SelfAspDB %>" 
            SelectCommand="SELECT [isbn], [title], [price], [publisher], [publishDate], [cdrom] FROM [Book] WHERE ([isbn] = @isbn)">
            <SelectParameters>
                <asp:ControlParameter ControlID="grid" Name="isbn" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Button ID="btnView2" runat="server"
            CommandName="PrevView" 
            Text="Return" />
    </asp:View>
</asp:MultiView>
</div>
</form>
</body>
</html>
