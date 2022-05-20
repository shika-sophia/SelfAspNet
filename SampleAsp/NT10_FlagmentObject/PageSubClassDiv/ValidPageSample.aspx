<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="ValidPageSample.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT10_FlagmentObject.PageSubClassDiv.ValidPageSample" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ValidPageSample</title>
    <link href="NT03_ServerControl/ValidSample_Style.css"
        rel="stylesheet" />
</head>
<body>
<form id="formValidPageSample" runat="server">
<div>
    ◆Name:<br />
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="reqName" runat="server"
        ControlToValidate="txtName"
        CssClass="validSample"
        ErrorMessage="Name"
        Text=""
        SetFocusOnError="false">
    </asp:RequiredFieldValidator><br />
    <br />
    ◆Body Weight:<br />
    <asp:TextBox ID="txtWeight" runat="server" Columns="5"></asp:TextBox>&thinsp;kg
    <asp:RangeValidator ID="rngWeight" runat="server"
        ControlToValidate="txtWeight"
        CssClass="validSample"
        MinimumValue="0" MaximumValue="300"
        Type="Integer"
        ErrorMessage="Body Weight"
        Text=""
        SetFocusOnError="false"
        Display="Static">
    </asp:RangeValidator><br />
    <br />
    ◆Birthday:<br />
    <asp:TextBox ID="txtBirth" runat="server" Columns="10"></asp:TextBox>
    <asp:CompareValidator ID="cmpBirth" runat="server"
        ControlToValidate="txtBirth"
        CssClass="validSample"
        Operator="DataTypeCheck"
        Type="Date"
        ErrorMessage="Birthday"
        Text=""
        SetFocusOnError="false">
    </asp:CompareValidator><br />
    <br />
    ◆E-mail:<br />
    <asp:TextBox ID="txtEmail" runat="server" Columns="50"></asp:TextBox>
    <asp:RegularExpressionValidator ID="rgxEmail" runat="server"
        ControlToValidate="txtEmail"
        CssClass="validSample"
        ValidationExpression =
            "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
        ErrorMessage="E-mail"
        Text=""
        SetFocusOnError="false">   
    </asp:RegularExpressionValidator><br />
    <br />
    ◆E-mail: (Confirm)<br />
    <asp:TextBox ID="txtEmail2" runat="server" Columns="50"></asp:TextBox>
    <asp:CompareValidator ID="cmpEmail" runat="server" 
        ControlToValidate="txtEmail2"
        ControlToCompare="txtEmail"
        CssClass="validSample"
        ErrorMessage="E-Mail,E-Mail(Confirm)"
        Text=""
        SetFocusOnError="false">
    </asp:CompareValidator><br />
    <br />
    <asp:Button ID="BtnSubmit" runat="server" Text="Submit"
        CssClass="BtnSubmit"
        OnClick="BtnSubmit_Click" /><br />
    <br />
    <asp:Label ID="LblResult" runat="server" Text=""></asp:Label><br />
</div>
<div>
    <asp:ValidationSummary ID="sumValidSample" runat="server"
        DisplayMode="List"
        HeaderText="◆Input Error"
        CssClass="validSample"
        ShowMessageBox="true"/>
</div>
</form>
</body>
</html>
