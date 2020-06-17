<%@ Page Language="C#" AutoEventWireup="true" CodeFile="orderplace.aspx.cs" Inherits="orderplace" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
     <title>Order Confirm</title>
<head runat="server">
    <link href="css/orderplace.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
    <div class="maincontent">
    <div class="header">
        <asp:Image  runat="server" ImageUrl="~/image/order_confirm.png" width="100px" /> 
        <h1>YOUR ORDER PLACED SUCCESSFULLY </h1>
    </div>
      <div class="container">
          <div class="content">
            
            <div class="contentheader">
               <h3> Order Details</h3>
            </div>
            
            <div class="contenttable">
                <table>
                    <tr>
                    <td>Payment ID :-</td><td><asp:Label ID="lblpaymentid" runat="server"></asp:Label></td>
                        </tr>
                    <tr>
                    <td>No of Product :-</td><td><asp:Label ID="lblnoofproduts" runat="server"></asp:Label></td>
                        </tr>
                
                </table>
                <asp:GridView ID="gvpaymentdetails" runat="server" AutoGenerateColumns="false" ShowHeader="false">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblproductname" runat="server" Text='<%#Bind("product_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <table>
                    <tr>
                        <td>PRICE :-</td><td><asp:Label ID="lblprice" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>SHIPPING PRICE :-</td><td><asp:Label ID="lblshipingprice" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>TOTAL PRICE :-</td><td><asp:Label ID="lbltotalprice" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </div>
              <div align="right">
                   <asp:Image ID="img"  runat="server" ImageUrl="~/image/thank.png"  width= "200px"   /> 
              </div>
        </div>
        <div align="center">
         <asp:Button ID="btncontinueshoping" runat="server" Text="CONTINUE SHOPING" class="btn" OnClick="btncontinueshoping_Click" />
            </div>
          </div>
    </div>
    </form>
    </body>
</html>
