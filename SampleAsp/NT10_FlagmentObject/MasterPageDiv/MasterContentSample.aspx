<%@ Page Title="MasterContentSample" Language="C#"
    MasterPageFile="~/SampleAsp/NT10_FlagmentObject/MasterPageDiv/MasterPageSample.master"
    AutoEventWireup="true" CodeBehind="MasterContentSample.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT10_FlagmentObject.MasterPageDiv.MasterContentSample" %>
<asp:Content ID="ContentHead"
    ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" 
    ContentPlaceHolderID="content1" runat="server">
    <asp:GridView ID="grid" runat="server" 
            AllowPaging="True" AllowSorting="True" 
            AutoGenerateColumns="False" 
            DataKeyNames="Id" 
            DataSourceID="SelfAspDB" 
            OnSelectedIndexChanged="grid_SelectedIndexChanged"
            PageSize="4">
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
</asp:Content>
