<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridWithTemplate.aspx.cs" Inherits="SelfAspNet.SampleAsp.NT04_DataBindControl.GridWithTemplate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>GridWithTemplate</title>
    <link href="../NT03_ServerControl/ValidSample_Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gridTemplate" runat="server" 
                    AllowPaging="True" AllowSorting="True" 
                    AutoGenerateColumns="False" 
                    CellPadding="4" 
                    DataKeyNames="Id" 
                    DataSourceID="SelfAspDB" 
                    ForeColor="#333333" 
                    GridLines="None" 
                    OnSelectedIndexChanged="gridTemplate_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="Id"
                        DataNavigateUrlFormatString="https://wings.msn.to/album/{0}"
                        DataTextField="Id" DataTextFormatString="{0}"
                        HeaderText="Albumコード" />
                    <asp:ImageField DataAlternateTextField="Id"
                        DataImageUrlField="Id" 
                        DataImageUrlFormatString="~/Image/{0}.jpg"
                        HeaderText="画像" ReadOnly="True">
                        <ControlStyle Height="40px" Width="40px" />
                    </asp:ImageField>
                    <asp:TemplateField HeaderText="分類" SortExpression="category">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ListEditCat" runat="server"
                                DataSourceID="SelfAspDB_ListEditCat"
                                SelectedValue='<%# Bind("category") %>' 
                                DataTextField="category" 
                                DataValueField="category">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SelfAspDB_ListEditCat" runat="server"
                                ConnectionString="<%$ ConnectionStrings:SelfAspDB %>"
                                SelectCommand="SELECT DISTINCT [category] FROM [Album]">
                            </asp:SqlDataSource>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LblCat" runat="server"
                                Text='<%# Bind("category") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="コメント" SortExpression="comment">
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtEditComment" runat="server"
                                Text='<%# Bind("comment") %>'
                                Columns="60"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LblComment" runat="server" 
                                Text='<%# Bind("comment") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="最終更新日" SortExpression="updated">
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtEditDate" runat="server"
                                Text='<%# Bind("updated","{0:yyyy/MM/dd}") %>'></asp:TextBox>
                            <asp:CompareValidator ID="cmpEditDate" runat="server"
                                ControlToValidate="TxtEditDate"
                                Operator="DataTypeCheck"
                                Type="Date"
                                CssClass="validSample"
                                ErrorMessage="最終更新日は日付形式で入力してください。[yyyy/MM/dd]"
                                Text="*">
                            </asp:CompareValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LblDate" runat="server"
                                Text='<%# Bind("updated", "{0:yyyy年MM月dd日 (ddd)}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CheckBoxField DataField="favorite" HeaderText="お気に入り"
                        SortExpression="favorite" />
                    <asp:TemplateField HeaderText="編集 / 削除" ShowHeader="False">
                        <EditItemTemplate>
                            <asp:Button ID="BtnUpdate" runat="server"
                                CausesValidation="True" CommandName="Update" Text="更新" />
                            &nbsp;<asp:Button ID="BtnCancel" runat="server"
                                CausesValidation="False" CommandName="Cancel" Text="キャンセル" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Button ID="BtnEdit" runat="server"
                                CausesValidation="False"
                                CommandName="Edit"
                                Text="編集" />
                            &nbsp;<asp:Button ID="BtnDelete" runat="server"
                                CausesValidation="False"
                                CommandName="Delete"
                                OnClientClick="return confirm('Delete OK?')"
                                Text="削除" />
                        </ItemTemplate>                                
                    </asp:TemplateField>
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
            <br />
            <asp:ValidationSummary runat="server"
                ID="gridSummary"
                HeaderText="Error following:"
                ShowMessageBox="true"
                ShowSummary="false">
            </asp:ValidationSummary>
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
        </div>
    </form>
</body>
</html>
