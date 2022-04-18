<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="WizardSample.aspx.cs" 
    Inherits="SelfAspNet.SampleAsp.NT09_RichControl.WizardControl.WizardSample" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="ValidStyle.css" rel="stylesheet" />
<title>WizardSample</title>
</head>
<body>
<form id="formWizardSample" runat="server">
<div>
<asp:Wizard ID="wiz" runat="server"
    ActiveStepIndex="0"
    OnNextButtonClick="wiz_NextButtonClick"
    OnFinishButtonClick="wiz_FinishButtonClick"
    StartNextButtonText="Next &gt;" 
    StepPreviousButtonText="&lt; Prev"
    StepNextButtonText="Next &gt;" 
    FinishPreviousButtonText="&lt; Prev"
    HeaderText="書籍アンケート" >
<WizardSteps>
    <asp:WizardStep runat="server" title="個人情報">
    あなた自身について教えてください。<br />
    <br />
    Name: <br />
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="reqName" runat="server"
        ErrorMessage="名前は必須です。"
        Text="*"
        ControlToValidate="txtName"
        CssClass="ValidStyle"
        SetFocusOnError="True">
    </asp:RequiredFieldValidator><br />
    <br />
    Email:<br />
    <asp:TextBox ID="txtEmail" runat="server"
        Columns="35"></asp:TextBox>
    <asp:RequiredFieldValidator ID="reqEmail" runat="server"
        ErrorMessage="Emailは必須です。"
        Text="*"
        ControlToValidate="txtEmail"
        CssClass="ValidStyle"
        SetFocusOnError="True"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="regexEmail" runat="server"
        ErrorMessage="Emailは正しい形式で入力してください。"
        ControlToValidate="txtEmail"
        Text="*"
        CssClass="ValidStyle"
        SetFocusOnError="True"
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
    </asp:RegularExpressionValidator><br />
    <br />
    Email: (confirm)<br />
    <asp:TextBox ID="txtEmail2" runat="server"
        Columns="35"></asp:TextBox>
    <asp:RequiredFieldValidator ID="reqEmail2" runat="server" 
        ErrorMessage="Email(confirm) は必須です。"
        Text="*"
        ControlToValidate="txtEmail2"
        CssClass="ValidStyle"
        SetFocusOnError="True"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="compareEmail2" runat="server" 
        ErrorMessage="Emailと Email (confirm)は 等しくなければいけません。"
        Text="*"
        ControlToCompare="txtEmail"
        ControlToValidate="txtEmail2"
        CssClass="ValidStyle"
        SetFocusOnError="True"></asp:CompareValidator><br />
    <br />
    </asp:WizardStep>
    <asp:WizardStep runat="server" StepType="Step" title="書籍感想">
        本書に関するご意見・ご感想をお願いします。<br />
        <br />
        本書購入の目的:<br />
        <asp:DropDownList ID="dropPurpose" runat="server">
            <asp:ListItem>Work</asp:ListItem>
            <asp:ListItem>Hobby</asp:ListItem>
            <asp:ListItem>Education</asp:ListItem>
            <asp:ListItem>Reserch</asp:ListItem>
            <asp:ListItem>Others</asp:ListItem>
        </asp:DropDownList><br />
        <br />
        本書の評価:
        <asp:RequiredFieldValidator ID="reqEvalute" runat="server"
            ErrorMessage="評価は必ず選択してください。"
            Text="*"
            ControlToValidate="radioEvalute"
            CssClass="ValidStyle"
            SetFocusOnError="True"></asp:RequiredFieldValidator><br />
        <asp:RadioButtonList ID="radioEvalute" runat="server"
            RepeatDirection="Horizontal">
            <asp:ListItem>Good</asp:ListItem>
            <asp:ListItem>Normal</asp:ListItem>
            <asp:ListItem>Bad</asp:ListItem>
        </asp:RadioButtonList><br />
    </asp:WizardStep>
    <asp:WizardStep runat="server" StepType="Finish" title="自由欄">
        その他、本書に関するご意見をお願いします。<br />
        <br />
        自由記入欄:<br />
        <asp:TextBox ID="txtFree" runat="server"
            Columns="25" Rows="3" 
            TextMode="MultiLine"></asp:TextBox><br />
        <br />
        メールニュース:<br />
        <asp:CheckBox ID="chkMailNews" runat="server"
            Checked="True"
            Text="希望する" /><br />
    </asp:WizardStep>
    <asp:WizardStep runat="server"
        StepType="Complete"
        title="Thank You.">
        <asp:Literal ID="ltlResult" runat="server"
            Text="アンケートへのご協力ありがとうございました。"></asp:Literal>
    </asp:WizardStep>
</WizardSteps>
</asp:Wizard>
<asp:SqlDataSource ID="sdsWiz" runat="server"
    ConnectionString="<%$ ConnectionStrings:SelfAspDB %>" 
    InsertCommand="INSERT INTO Quest(name, email, purpose, evalute, free, mailNews) VALUES (@name, @email, @purpose, @evalute, @free, @mailNews)"
    ProviderName="<%$ ConnectionStrings:SelfAspDB.ProviderName %>"
    OnInserting="sdsWiz_Inserting"
    OnInserted="sdsWiz_Inserted">    
    <InsertParameters>
        <asp:Parameter Name="name" />
        <asp:Parameter Name="email" />
        <asp:Parameter Name="purpose" />
        <asp:Parameter Name="evalute" />
        <asp:Parameter Name="free" />
        <asp:Parameter Name="mailNews" />
    </InsertParameters>
</asp:SqlDataSource>
<asp:ValidationSummary ID="summaryWiz" runat="server" HeaderText="以下のエラーが発生しました。" ShowMessageBox="True" ShowSummary="False"  />
</div>
</form>
</body>
</html>
