<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="LinqEntityFriendly.aspx.cs"
    Inherits="SampleAsp.NT10_FlagmentObject.FriendlyUrlsDiv.LinqEntityFriendly" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>LinqEntityFriendly</title>
</head>
<body>
<form id="formLinqEntityFriendly" runat="server">
<div>
    <asp:GridView ID="gridLinqEntityFriendly" runat="server"
        ItemType="SelfAspNet.Models.Book"
        DataKeyNames="isbn"
        SelectMethod="gridLinqEntityFriendly_GetBooksByPrice"
        UpdateMethod="gridLinqEntityFriendly_UpdateBook"
        AutoGenerateEditButton="true"
        AllowSorting="true"
        AllowPaging="true"
        PageSize="3">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <%#: Item.isbn  %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ValidationSummary ID="summaryLinqEntityFriendly" runat="server"
        HeaderText="Validation Error:"
        ShowSummary="true" />
</div>
</form>
</body>
</html>
