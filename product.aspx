<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSection/Admin1MasterPage.master" AutoEventWireup="true" CodeFile="product.aspx.cs" Inherits="product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/product.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="productdetailmain">
        <div class="headerproductdetails">
            <h1 style="color: white">PRODUCT DETAILS</h1>
        </div>

        <div class="imagepart">
            <asp:Image ID="imgproduct" runat="server" Height="200px" Width="300px" color="white" />
        </div>

        <div class="contentpart" >
            <table>
                <tr>
                    <td>PRODUCT NAME :-</td>
                    <td>
                        <asp:Label ID="lblproductname" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td>PRODUCT CATEGORY :-</td>
                    <td>
                        <asp:Label ID="lblcategory" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>PRODUCTPRICE :-</td>
                    <td>
                        <asp:Label ID="lblprice" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>TOTAL PRICE :-</td>
                    <td>
                        <asp:Label ID="lbltotalprice" runat="server"></asp:Label></td>
                </tr>
                </table>
            <div class="contaner">
                    
                        <asp:Button ID="btnminus" runat="server" Text="<" cssClass="butn" OnClick="btnminus_Click" />  <asp:Label ID="lblquantity" runat="server"  Text="Label"></asp:Label> <asp:Button ID="btnplus" runat="server" Text=">" cssClass="butn" OnClick="btnplus_Click" />
                      
                        
                    
                
            </div>
                
            </div>
                <div class="productbtn">
                        <asp:LinkButton ID="lbtnaddtocart" runat="server" CssClass="btn"  OnClick="lbtnaddtocart_Click">ADD TO CART</asp:LinkButton><asp:LinkButton ID="lbtngotocart"  CssClass="btn" runat="server" OnClick="lbtngotocart_Click">GO TO CART</asp:LinkButton>
                        <asp:LinkButton ID="lbtnordernow" runat="server" CssClass="btn" OnClick="lbtnordernow_Click">ORDER NOW</asp:LinkButton>
                
            
        </div>
    </div>
</asp:Content>

