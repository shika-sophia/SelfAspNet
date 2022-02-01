<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="ResponseHeaderSample.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT06_ImplicitObject.Response.ResponseHeaderSample" 
    ContentType="application/octet-stream"
    ResponseEncoding="Shift-JIS" %>
<asp:ListView ID="list" runat="server" DataSourceID="sds" DataKeyNames="isbn">
<ItemTemplate><%# Eval("isbn")%>,<%# Eval("title")%>,<%# Eval("publisher")%>,<%# Eval("price")%>,<%# Eval("publishDate")%>,<%# Eval("cdrom")%>
</ItemTemplate>
</asp:ListView>
<asp:SqlDataSource ID="sds" runat="server" 
    ConnectionString="<%$ ConnectionStrings:SelfAspDB %>" 
    SelectCommand="SELECT [isbn], [title], [price], [publisher], [publishDate], [cdrom] FROM [Book] ORDER BY [isbn]">
</asp:SqlDataSource>
