<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="Checkout" %>

<!DOCTYPE html>

<html>
    <title>CheckOut</title>
<head>

<meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="css/checkoutStyleSheet.css" rel="stylesheet" />

<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

<link rel="stylesheet" href="Style.css">

  

</head>

<body>
    <form id="form1" runat="server">


<h2> Checkout Product Here:-</h2>

<div class="row">

  <div class="col-75">

    <div class="container">

      

      

        <div class="row">

          <div class="col-50">
            <h3>Product</h3>

                <label for="email"><i class="fa fa-envelope"></i>Payment ID:- </label>
              <asp:Label ID="lblpaymentid" runat="server"></asp:Label>
            <label for="fname"><i class="fa fa-cash-register"></i>No. Of Products</label>
            <asp:Label ID="lblnoofproducts" runat="server"></asp:Label>

               <asp:GridView ID="productdetails" runat="server" AutoGenerateColumns="false" ShowHeader="false">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                              <asp:Label ID="lblproductname" runat="server" Text='<%#Bind("Product_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
                </asp:GridView>
         <table style="width: 100%;margin-top: 20px;">
                    <tr><td>Food Price :-</td><td><asp:Label ID="lblpriceofproduct" runat="server"></asp:Label></td></tr>
                    <tr><td>Shiping Address :-</td><td><asp:Label ID="lblshipingaddress" runat="server"></asp:Label></td></tr>
                    <tr><td>Shiping Price :-</td><td><asp:Label ID="lblshipingcharges" runat="server"></asp:Label></td></tr>
                    <tr><td>Total Price :-</td><td><asp:Label ID="lbltotalprice" runat="server"></asp:Label></td></tr>
                <tr>
                    <td colspan="2" style="text-align: center"></td>
                </tr>
            </table>
          


           
           

             
            </div>
         

          <div class="col-50">
            <h3>Payment</h3>
            <label for="fname">Accepted Cards</label>
            <div class="icon-container">
              <i class="fa fa-cc-visa" style="color:navy;"></i>
              <i class="fa fa-cc-amex" style="color:blue;"></i>
              <i class="fa fa-cc-mastercard" style="color:red;"></i>
              <i class="fa fa-cc-discover" style="color:orange;"></i>
            </div>
            <label for="cname">Name on Card</label>
            <inpt type="text" id="cname" name="cardname" 
                    placeholder="Sarvesh Maurya">
            <label for="ccnum">Credit card number</label>
            <input type="text" id="ccnum" name="cardnumber" 
                  placeholder="1111-2222-3333-4444">
            <label for="expmonth">Exp Month</label>
            <input type="text" id="expmonth" name="expmonth" 
               placeholder="September">
            <div class="row">
              <div class="col-50">
                <label for="expyear">Exp Year</label>
                <input type="text" id="expyear" name="expyear" placeholder="2020">
              </div>
              <div class="col-50">
                <label for="cvv">CVV</label>
                <input type="text" id="cvv" name="cvv" placeholder="352">
              </div>
            </div>
          </div>
          
        </div>
        <label>
          <input type="checkbox" checked="checked" name="sameadr"> 
           Shipping address same as billing
        </label>
       <asp:Button ID="btnconfirmandpay" CssClass="btn" runat="server" Text="PAY NOW" OnClick="btnconfirmandpay_Click"  />
    </div>
  </div>
  
</div>
    </form>
</body>
</html>
