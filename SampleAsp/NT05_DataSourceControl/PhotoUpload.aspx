<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhotoUpload.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT05_DataSourceControl.PhotoUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>PhotoUpload</title>
</head>
<body>
<form id="formPhotoUpload" runat="server">
<div>
<%-- ==== FileUpload ==== --%>
    File: (DB: Photo_tbに uploadします)<br />
    <asp:FileUpload ID="upFile" runat="server" />&nbsp;
    <asp:Button ID="BtnUpload" runat="server"
        Text="Upload" OnClick="BtnUpload_Click" />
</div>
<%-- ==== DataSource ==== --%>
<asp:SqlDataSource ID="SelfAspDB_PhotoUpload" runat="server"
    ConnectionString="<%$ ConnectionStrings:SelfAspDB %>"
    SelectCommand="SELECT [type], [data] FROM [Photo]"
    InsertCommand="INSERT INTO Photo(type, data) VALUES (@type, @data)" >
    <InsertParameters>
        <asp:ControlParameter ControlID="upFile"
            Name="data" PropertyName="FileBytes" />
    </InsertParameters>
</asp:SqlDataSource>
</form>
</body>
</html>
