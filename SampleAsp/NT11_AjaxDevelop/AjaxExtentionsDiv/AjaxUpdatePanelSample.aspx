<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="AjaxUpdatePanelSample.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT11_AjaxDevelop.AjaxExtentionsDiv.AjaxUpdatePanelSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>AjaxUpdatePanelSample</title>
</head>
<body>
<form id="formAjaxUpdatePanelSample" runat="server">
<div>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <asp:Label ID="lbl" runat="server" Text=""></asp:Label>
<asp:UpdatePanel ID="upPanel" runat="server">
    <ContentTemplate>
    <%-- 4.3.1 GridViewSample.aspx (Copy) --%>
    <asp:GridView ID="grid" runat="server" 
            AllowPaging="True" AllowSorting="True" 
            AutoGenerateColumns="False" 
            CellPadding="4" 
            DataKeyNames="Id" 
            DataSourceID="SelfAspDB" 
            ForeColor="#333333" 
            GridLines="None" 
            OnSelectedIndexChanged="grid_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="Id"
                DataNavigateUrlFormatString="https://wings.msn.to/album/{0}"
                DataTextField="Id" DataTextFormatString="{0}"
                HeaderText="Albumコード" />
            <asp:ImageField DataAlternateTextField="Id"
                DataImageUrlField="Id" DataImageUrlFormatString="~/Image/{0}.jpg"
                HeaderText="画像" ReadOnly="True">
                <ControlStyle Height="40px" Width="40px" />
            </asp:ImageField>
            <asp:BoundField DataField="category" HeaderText="分類"
                SortExpression="category" />
            <asp:BoundField DataField="comment" HeaderText="コメント"
                SortExpression="comment" />
            <asp:BoundField DataField="updated" 
                DataFormatString="{0:yyyy年MM月dd日 (ddd)}"
                HeaderText="最終更新日" SortExpression="updated" />
            <asp:CheckBoxField DataField="favorite" HeaderText="お気に入り"
                SortExpression="favorite" />
            <asp:CommandField ButtonType="Button" HeaderText="編集 / 削除"
                ShowDeleteButton="True" ShowEditButton="True" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SelfAspDB" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SelfAspDB %>" 
        DeleteCommand="DELETE FROM [Album] WHERE [Id] = @Id" 
        InsertCommand="INSERT INTO [Album] ([Id], [category], [comment], [updated], [favorite]) VALUES (@Id, @category, @comment, @updated, @favorite)"
        SelectCommand="SELECT [Id], [category], [comment], [updated], [favorite] FROM [Album]"
        UpdateCommand="UPDATE [Album] SET [category] = @category, [comment] = @comment, [updated] = @updated, [favorite] = @favorite WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="String" />
        </DeleteParameters>
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
    </asp:SqlDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
</div>
</form>
</body>
</html>
