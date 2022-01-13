<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="LinqEntitySample.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT05_DataSourceControl.EntityDataModel.LinqEntitySample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>LinqEntitySample</title>
</head>
<body>
<form id="formLinqEntitySample" runat="server">
<div>
    <asp:GridView ID="gridLinqEntitySample" runat="server"
        SelectMethod="gridLinqEntitySample_GetBooksByPrice"
        DataKeyNames="isbn"
        AllowSorting="true"
        AllowPaging="true"
        PageSize="3">
    </asp:GridView>
</div>
</form>
</body>
</html>
