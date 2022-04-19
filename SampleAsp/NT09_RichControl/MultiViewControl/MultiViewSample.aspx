<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="MultiViewSample.aspx.cs" 
    Inherits="SelfAspNet.SampleAsp.NT09_RichControl.MultiViewControl.MultiViewSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>MultiViewSample</title>
</head>
<body>
<form id="formMultiViewSample" runat="server">
<div>
<asp:MultiView ID="mv" runat="server" ActiveViewIndex="0">
    <asp:View ID="view1" runat="server">
        <asp:GridView ID="gridMulti" runat="server" DataSourceID="sds" OnSelectedIndexChanged="gridMulti_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="sds" runat="server"
            ConnectionString="<%$ ConnectionStrings:SelfAspDB %>"
            SelectCommand="SELECT [Id], [category], [comment], [updated], [favorite] FROM [Album]">           
        </asp:SqlDataSource>
    </asp:View>
    <asp:View ID="view2" runat="server">
        <asp:FormView ID="fvMulti" runat="server"
            DataKeyNames="Id"
            DataSourceID="sdsDetail">
        </asp:FormView>
        <asp:SqlDataSource ID="sdsDetail" runat="server"
            ConnectionString="<%$ ConnectionStrings:SelfAspDB %>"
            SelectCommand="SELECT [Id], [category], [comment], [updated], [favorite] FROM [Album] WHERE ([Id] = @Id)">
            <SelectParameters>
                <asp:ControlParameter 
                    ControlID="gridMulti"
                    Name="Id"
                    PropertyName="SelectedValue"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Button ID="btn" runat="server"
            Text="一覧へ"
            CommandName="PrevView" />
    </asp:View>
</asp:MultiView>
</div>
</form>
</body>
</html>
