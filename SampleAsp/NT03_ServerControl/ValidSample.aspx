<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidSample.aspx.cs" Inherits="SelfAspNet.SampleAsp.NT03_ServerControl.ValidSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ValidSample</title>
    <link href="ValidSample_Style.css" rel="stylesheet" />
</head>
<body>
<form id="formValidSample" runat="server">
<div>
    ◆Name:<br />
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="reqName" runat="server"
        ControlToValidate="txtName"
        CssClass="validSample"
        ErrorMessage="<！> Name should be required."
        Text="<！>"
        SetFocusOnError="true">
    </asp:RequiredFieldValidator><br />
    <br />
    ◆Body Weight:<br />
    <asp:TextBox ID="txtWeight" runat="server" Columns="5"></asp:TextBox>&thinsp;kg
    <asp:RangeValidator ID="rngWeight" runat="server"
        ControlToValidate="txtWeight"
        CssClass="validSample"
        MinimumValue="0" MaximumValue="300"
        Type="Integer"
        ErrorMessage="<！> Body Weight should be input in range [0 - 300]."
        Text="<！>"
        SetFocusOnError="true"
        Display="Dynamic">
    </asp:RangeValidator><br />
    <br />
    ◆Birthday:<br />
    <asp:TextBox ID="txtBirth" runat="server" Columns="10"></asp:TextBox>
    <asp:CompareValidator ID="cmpBirth" runat="server"
        ControlToValidate="txtBirth"
        CssClass="validSample"
        Operator="DataTypeCheck"
        Type="Date"
        ErrorMessage="<！> Birthday should be input by Date format like [YYYY-MM-DD]."
        Text="<！>"
        SetFocusOnError="true">
    </asp:CompareValidator><br />
    <br />
    ◆E-mail:<br />
    <asp:TextBox ID="txtEmail" runat="server" Columns="50"></asp:TextBox>
    <asp:RegularExpressionValidator ID="rgxEmail" runat="server"
        ControlToValidate="txtEmail"
        CssClass="validSample"
        ValidationExpression =
            "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
        ErrorMessage="<！> E-mail should be input by E-mail format."
        Text="<！>"
        SetFocusOnError="true">   
    </asp:RegularExpressionValidator><br />
    <br />
    ◆E-mail: (Confirm)<br />
    <asp:TextBox ID="txtEmail2" runat="server" Columns="50"></asp:TextBox>
    <asp:CompareValidator ID="cmpEmail" runat="server" 
        ControlToValidate="txtEmail2"
        ControlToCompare="txtEmail"
        CssClass="validSample"
        ErrorMessage="<！> E-mail and E-Mail(Confirm) should be input equally."
        Text="<！>"
        SetFocusOnError="true">
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
