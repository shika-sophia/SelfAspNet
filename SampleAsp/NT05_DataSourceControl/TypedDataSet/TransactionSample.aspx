<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="TransactionSample.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT05_DataSourceControl.TypedDataSet.TransactionSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>TransactionSample</title>
</head>
<body>
<form id="formTransactionSample" runat="server">
<div>
<asp:GridView ID="gridTransaction" runat="server"
    AutoGenerateColumns="False"
    DataKeyNames="Id"
    DataSourceID="ods"
    OnRowDeleting="gridTransaction_RowDeleting">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
        <asp:BoundField DataField="category" HeaderText="category" SortExpression="category" />
        <asp:BoundField DataField="comment" HeaderText="comment" SortExpression="comment" />
        <asp:BoundField DataField="updated" HeaderText="updated" SortExpression="updated" />
        <asp:CheckBoxField DataField="favorite" HeaderText="favorite" SortExpression="favorite" />
        <asp:CommandField ButtonType="Button"
            DeleteText="Delete Row"
            HeaderText="Actions"
            ShowDeleteButton="True"
            OnClientClick="return confirm('＜!＞ Delete ROW OK?')" />
       
    </Columns>

</asp:GridView>
<asp:ObjectDataSource ID="ods" runat="server"
    DeleteMethod="Delete"
    InsertMethod="Insert"
    OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAlbumData"
    TypeName="SelfAspNet.SampleAsp.NT05_DataSourceControl.TypedDataSet.AlbumDataSetTableAdapters.AlbumTableAdapter" UpdateMethod="Update">
    <DeleteParameters>
        <asp:Parameter Name="Original_Id" Type="String" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="Id" Type="String" />
        <asp:Parameter Name="category" Type="String" />
        <asp:Parameter Name="comment" Type="String" />
        <asp:Parameter Name="updated" Type="DateTime" />
        <asp:Parameter Name="favorite" Type="Boolean" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="category" Type="String" />
        <asp:Parameter Name="comment" Type="String" />
        <asp:Parameter Name="updated" Type="DateTime" />
        <asp:Parameter Name="favorite" Type="Boolean" />
        <asp:Parameter Name="Original_Id" Type="String" />
    </UpdateParameters>
</asp:ObjectDataSource>
</div>
</form>
</body>
</html>
