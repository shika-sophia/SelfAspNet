<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="RequestHeaderSample.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT06_ImplicitObject.RequestHeaderSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>RequestHeaderSample</title>
</head>
<body>
    <form id="formRequestHeaderSample" runat="server">
        <div>
            ◆Request.Property (Request Header)<br />
            <asp:GridView ID="gridReqProp" runat="server">
            </asp:GridView>
            <br />
            ◆Request.Property (Path)<br />
            <asp:GridView ID="gridReqPath" runat="server">
            </asp:GridView>
            <br />
            ◆Request.ServerVariables[] (Request Header)
            <asp:GridView ID="gridReqHeader" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
