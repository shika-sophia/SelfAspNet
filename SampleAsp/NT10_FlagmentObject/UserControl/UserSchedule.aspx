<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="UserSchedule.aspx.cs"
    Inherits="SelfAspNet.SampleAsp.NT10_FlagmentObject.UserControl.UserSchedule" %>

<%@ Register src="UserControlSample.ascx"
    tagname="UserControlSample" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>UserSchedule</title>
</head>
<body>
<form id="formUserSchedule" runat="server">
<div>
    <uc1:UserControlSample ID="UserControlSample" runat="server" Uid="yamada"/>
</div>
</form>
</body>
</html>
