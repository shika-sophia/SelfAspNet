<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomValidSample.aspx.cs" Inherits="SelfAspNet.SampleAsp.CustomValidSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>CustomValidSample</title>
<link href="NT03_ServerControl/ValidSample_Style.css" rel="stylesheet" />
<script type="text/javascript">
    function MyValid(source, args) {
        args.IsValid = (args.Value.Length <= 20);
    }
</script>
</head>
<body>
<form id="form1" runat="server">
<div>
    Name:<br />
    <asp:TextBox ID="txtName" runat="server" Columns="25"></asp:TextBox><br />
    <asp:CustomValidator ID="CusName" runat="server"
        ClientValidationFunction="MyValid"
        ControlToValidate="txtName"
        CssClass="validSample"
        ErrorMessage="<！> Name shuld be input in 20 length.">
    </asp:CustomValidator><br />
    <asp:Button ID="BtnSubmit" runat="server" Text="Submit"
        CssClass="BtnSubmit" OnClick="BtnSubmit_Click" /><br />
    <br />
    <asp:Label ID="LbResult" runat="server" Text=""></asp:Label><br />
</div>
</form>
</body>
</html>
