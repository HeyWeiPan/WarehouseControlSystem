<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateUserPassword.aspx.cs"
    Inherits="Home_UpdateUserPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../CommonUI/Css/office.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="text-align: center;">
                <p>
                    &nbsp;</p>
                <p>
                    &nbsp;</p>
                <p>
                    &nbsp;</p>
                <p>
                    &nbsp;</p>
                <asp:Wizard ID="Wizard1" runat="server" OnActiveStepChanged="Wizard1_ActiveStepChanged">
                    <WizardSteps>
                        <asp:WizardStep ID="WizardStep1" runat="server" Title="Step 1" StepType="Start">
                            Wizard Step 1<br />
                            <br />
                            Favorite Numer:
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                        </asp:WizardStep>
                           <asp:WizardStep ID="WizardStep2" runat="server" Title="Step 2" StepType="Step">
                            Wizard Step 1<br />
                            <br />
                            Favorite Numer:
                            <asp:DropDownList ID="DropDownList2" runat="server">
                                <asp:ListItem>lin</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                        </asp:WizardStep>
                        <asp:WizardStep ID="WizardStep3" runat="server" Title="Step 3" StepType="Complete">
                            Complete Wizard Step
                            <br />
                            <br />
                            <asp:Label ID="Label1" runat="server"></asp:Label><br />
                            <br />
                            <asp:Label ID="Label2" runat="server"></asp:Label>
                        </asp:WizardStep>
                    </WizardSteps>
                </asp:Wizard>
                &nbsp;</div>
        </div>
    </form>
</body>
</html>
