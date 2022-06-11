<%@ Page Title="PracticeContent" Language="C#" 
    MasterPageFile="~/SampleAsp/NT10_FlagmentObject/MasterPageDiv/MasterPageSample.master"
    AutoEventWireup="true" 
    CodeBehind="PracticeContent.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT10_FlagmentObject.MasterPageDiv.PracticeContent" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="content1Content" ContentPlaceHolderID="content1" runat="server">
<div>
    <asp:ListView ID="listView" runat="server"
        DataSourceID="sds"
        DataKeyNames="isbn"
        GroupItemCount="6" >
        <GroupTemplate>
            <tr id="itemPlaceholderContainer" runat="server">
                <td id="itemPlaceholder" runat="server"></td>
            </tr>
        </GroupTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="">
                <tr>
                    <td>データは返されませんでした。</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <EmptyItemTemplate>
            <td runat="server" />
        </EmptyItemTemplate>
        <Itemtemplate>
            <td runat="server" style="">
                <asp:Image ID="image" runat="server" 
                    ImageUrl='<%# Eval("isbn", "https://wings.msn.to/books/{0}/{0}.jpg") %>'
                    Width="100" Height="160"
                    AlternateText="No Image" />
            </td>
        </Itemtemplate>     
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="groupPlaceholderContainer" runat="server" border="0" style="">
                            <tr id="groupPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style=""></td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="sds" runat="server"
        ConnectionString="<%$ ConnectionStrings:SelfAspDB %>" 
        SelectCommand="SELECT [isbn], [title], [price], [publisher], [publishDate], [cdrom] FROM [Book]"></asp:SqlDataSource>
</div>
</asp:Content>
