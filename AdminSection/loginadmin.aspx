<%@ Page Language="C#" AutoEventWireup="true" CodeFile="loginadmin.aspx.cs" Inherits="Admin_Section_loginadmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/LOGINStyleSheet.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">
    <div class="mainlog">
        <div class="heading">
            <h2>Admin Sign In</h2>
        </div>
        <div class="logcontent">
            <div class="emailid">
                <asp:TextBox ID="name" runat="server" placeholder ="Enter Your E-mail" CssClass="LOGINBOX" required =""></asp:TextBox>
            </div>
            <div class="pass">
                <asp:TextBox ID="txtpassword" runat="server" placeholder ="Enter Your Password" CssClass="LOGINBOX" required =""></asp:TextBox>
            </div>
            <div class="logbutton">
                <asp:Button ID="login" runat="server" Text="Log In" CssClass="LOGBUTTON" required ="" OnClick="login_Click"  />
                <asp:Button ID="Reset" runat="server" Text="Reset" CssClass="LOGBUTTON" required ="" />
            </div>
            <div class="forgetpass">
                    <asp:LinkButton ID="lbtnforgetpass" runat="server">Forget Password</asp:LinkButton>

                </div>
                <div class="signup">
                    <asp:LinkButton ID="lbtnsignup" runat="server">Sign Up</asp:LinkButton>

                </div>
        </div>
    </div>
    </form>
</body>
</html>
