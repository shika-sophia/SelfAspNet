<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="CustomAspSample.aspx.cs"
    Inherits="NT08_AspNetIdentity.SampleUser.CustomAspSample" %>

<%@ Register assembly="NT08_AspNetIdentity" namespace="NT08_AspNetIdentity.SampleUser" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CustomAspSample</title>
</head>
<body>
<form id="formCustomAspSample" runat="server">
<div>
    <cc1:CustomLabelSample ID="CustomLabelSample1" runat="server">
    </cc1:CustomLabelSample>
</div>
</form>
</body>
</html>
