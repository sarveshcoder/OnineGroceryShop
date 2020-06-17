<%@ Page Title="" Language="C#" MasterPageFile="~/GROCERYMasterPage.master" AutoEventWireup="true" CodeFile="Registrationpage.aspx.cs" Inherits="Registrationpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="mainregpage">
        <div class="textreg">
            <h2>Sign Up Here</h2>
        </div>
        <div class="contentreg">
            <div class="custname">
                <asp:TextBox ID="name" runat="server" placeholder ="Your Name" CssClass="TXTBOX" required =""></asp:TextBox>

            </div>
            <div class="email">
                <asp:TextBox ID="mail" runat="server" placeholder ="Your E-mail" TextMode="Email" CssClass="TXTBOX" required =""></asp:TextBox>

            </div>
            <div class="password">
                <asp:TextBox ID="passwordreg" runat="server" placeholder ="password" TextMode="Password" CssClass="TXTBOX" required =""></asp:TextBox>

            </div>
            <div class="cnfpassword">
                <asp:TextBox ID="passwordcnf" runat="server" placeholder ="confirm password" TextMode="Password" CssClass="TXTBOX" required =""></asp:TextBox>

            </div>
             <div class="address">
                <asp:TextBox ID="custaddress" runat="server" placeholder ="Enter your Address"  CssClass="TXTBOX" required =""></asp:TextBox>

            </div>
             <div class="contcact">
                <asp:TextBox ID="custcontact" runat="server" placeholder ="Phone No." TextMode="Number" CssClass="TXTBOX" required =""></asp:TextBox>

            </div>

            <div class="SUBMITbutton">
                <asp:Button ID="submit" runat="server" Text="SIGN IN" CssClass="regbutton" required  ="" OnClick="submit_Click" />
            </div>
        </div>
    </div>
</asp:Content>

