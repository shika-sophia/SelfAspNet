<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="jQuerySample.aspx.cs" 
    Inherits="SelfAspNet.SampleAsp.NT11_AjaxDevelop.jQueryDiv.jQuerySample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>jQuerySample</title>
</head>
<body>
<form id="formjQuerySample" runat="server">
<div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"
        AjaxFrameworkMode="Disabled"
        EnableCdn="True">
        <Scripts>
            <asp:ScriptReference Name="jquery" />
        </Scripts>
    </asp:ScriptManager>
    <script>
        $(function () {
            $('#menu img.other')
                .fadeOut(5000)
                .fadeIn(5000)
                .slideUp(5000);

            $('img').click(function () {
                $(this).fadeToggle(5000);
            });
        });
    </script>
    <div id="menu">
        <p><img src="https://wings.msn.to/books/978-4-7981-6044-3/978-4-7981-6044-3_logo.jpg" class="other" /></p>
        <p><img src="https://wings.msn.to/books/978-4-7981-5112-0/978-4-7981-5112-0_logo.jpg" class="java" /></p>
        <p><img src="https://wings.msn.to/books/978-4-7981-5757-3/978-4-7981-5757-3_logo.jpg" class="other" /></p>
        <p><img src="https://wings.msn.to/books/978-4-7981-5382-7/978-4-7981-5382-7_logo.jpg" class="csharp" /></p>
    </div>
</div>
</form>
</body>
</html>
