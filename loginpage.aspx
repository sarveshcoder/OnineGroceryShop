<%@ Page Title="" Language="C#" MasterPageFile="~/GROCERYMasterPage.master" AutoEventWireup="true" CodeFile="loginpage.aspx.cs" Inherits="loginpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="mainlog">
        <div class="heading">
            <h2>Sign In Here</h2>
        </div>
        <div class="logcontent">
            <div class="emailid">
                <asp:TextBox ID="mail" runat="server" placeholder="Enter Your E-mail" CssClass="LOGINBOX" required=""></asp:TextBox>
            </div>
            <div class="pass">
                <asp:TextBox ID="txtpassword" runat="server" placeholder="Enter Your Password" CssClass="LOGINBOX" required=""></asp:TextBox>
            </div>
            <div class="logbutton">
                <asp:Button ID="login" runat="server" Text="Log In" CssClass="LOGBUTTON" required="" OnClick="login_Click"/>
                <asp:Button ID="Reset" runat="server" Text="Reset" CssClass="LOGBUTTON" required="" />
            </div>
            <div class="forgetpass">
                <asp:LinkButton ID="lbtnforgetpass" runat="server">Forget Password</asp:LinkButton>

            </div>
            <div class="signup">
                <asp:LinkButton ID="lbtnsignup" runat="server" >New User</asp:LinkButton>

            </div>

        </div>
    </div>
</asp:Content>

