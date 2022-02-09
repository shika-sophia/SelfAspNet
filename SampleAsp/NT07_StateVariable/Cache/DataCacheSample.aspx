<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="DataCacheSample.aspx.cs" 
    Inherits="SelfAspNet.SampleAsp.NT07_StateVariable.Cache.DataCacheSample" %>
<%@ OutputCache Duration="120" VaryByParam="none" 
    SqlDependency="MyCache:Book" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>DataCacheSample</title>
</head>
<body>
<form id="formDataCacheSample" runat="server">
<div>
    <asp:GridView ID="gridDataCacheSample" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="isbn" HeaderText="ISBN" />
            <asp:BoundField DataField="title" HeaderText="Title" />
            <asp:BoundField DataField="price" HeaderText="Price" />
            <asp:BoundField DataField="publish" HeaderText="Publisher" />
            <asp:BoundField DataField="published" HeaderText="Publish Date" />
        </Columns>
    </asp:GridView>
    <%-- Page.DataBind() in [DataCacheSample.aspx.cs] --%>
</div>
</form>
</body>
</html>
