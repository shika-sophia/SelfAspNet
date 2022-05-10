<%@ Page Title="アカウントの確認" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="NT08_AspNetIdentity.Account.Confirm" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>。</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successPanel" ViewStateMode="Disabled" Visible="true">
            <p>
                アカウントをご確認いただき、ありがとうごいます。ログインするには <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">こちら</asp:HyperLink>  をクリックしてください             
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="errorPanel" ViewStateMode="Disabled" Visible="false">
            <p class="text-danger">
                エラーが発生しました。
            </p>
        </asp:PlaceHolder>
    </div>
</asp:Content>
