<%@ Page Title="登録" Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Register.aspx.cs"
    Inherits="NT08_AspNetIdentity.Account.Register" %>

<asp:Content runat="server" ID="BodyContent"
    ContentPlaceHolderID="MainContent">
    <h2><%: Title %>。</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>新しいアカウントを作成する</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">電子メール</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="電子メール フィールドは必須です。" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">パスワード</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="パスワード フィールドは必須です。" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">パスワードの確認入力</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="パスワードの確認入力フィールドは必須です。" />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="パスワードと確認のパスワードが一致しません。" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" 
                AssociatedControlID="Url"
                CssClass="col-md-2 control-label">URL</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="Url" runat="server"
                    TextMode="Url"
                    CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqUrl" runat="server"
                    ControlToValidate="Url"
                    Display="Dynamic"
                    CssClass="text-danger"
                    ErrorMessage="URLは必須です。"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="登録" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
