<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUploadSample.aspx.cs" Inherits="SelfAspNet.SampleAsp.AS03_ServerControl.FileUploadSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<form id="form1" runat="server">
<div>
    File Uploader:<br />
    <asp:FileUpload ID="upload" runat="server" AllowMultiple="true"/><br />
    <asp:Button ID="BtFileUp" runat="server" Text="Upload" 
        OnClick="BtFileUp_Click" /><br />
    <br />
    <asp:Label ID="LbFileUp" runat="server" Text=""></asp:Label>
</div>
</form>
</body>
</html>
