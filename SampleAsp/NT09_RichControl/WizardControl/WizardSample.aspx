<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="WizardSample.aspx.cs" 
    Inherits="SelfAspNet.SampleAsp.NT09_RichControl.WizardControl.WizardSample" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>WizardSample</title>
</head>
<body>
<form id="formWizardSample" runat="server">
<div>
<asp:Wizard ID="wiz" runat="server"  OnFinishButtonClick="Wizard1_FinishButtonClick" ActiveStepIndex="0" FinishPreviousButtonText="&lt; Prev" StartNextButtonText="Next &gt;" StepNextButtonText="Next &gt;" StepPreviousButtonText="&lt; Prev" >
<WizardSteps>
    <asp:WizardStep runat="server" title="個人情報">
    Name: <br />
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="reqName" runat="server"
        ErrorMessage="*"></asp:RequiredFieldValidator><br />
    Email:<br />
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="reqEmail" runat="server"
        ErrorMessage="*"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="regexEmail" runat="server"
        ErrorMessage="*"></asp:RegularExpressionValidator><br />
    Email: (confirm)<br />
    <asp:TextBox ID="txtEmail2" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="reqEmail2" runat="server" 
        ErrorMessage="*"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="compareEmail2" runat="server" 
        ErrorMessage="*"></asp:CompareValidator><br />
    <br />
    </asp:WizardStep>
    <asp:WizardStep runat="server" StepType="Step" title="書籍感想">
    </asp:WizardStep>
    <asp:WizardStep runat="server" StepType="Finish" title="自由欄">
    </asp:WizardStep>
    <asp:WizardStep runat="server" StepType="Complete" title="Thank You.">
    </asp:WizardStep>
</WizardSteps>
</asp:Wizard>
<asp:SqlDataSource ID="sdsWiz" runat="server">
</asp:SqlDataSource>
<asp:ValidationSummary ID="summaryWiz" runat="server"  />
</div>
</form>
</body>
</html>
