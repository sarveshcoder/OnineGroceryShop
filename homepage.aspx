<%@ Page Title="" Language="C#" MasterPageFile="~/GROCERYMasterPage.master" AutoEventWireup="true" CodeFile="homepage.aspx.cs" Inherits="homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/search.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-1.12.4.js" type="text/javascript"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $("[id$=txtfindgrocery]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "GoGWebService.asmx/GetgroceryName",
                        method: "POST",
                        contentType: "application/json;charset=utf-8",
                        data: JSON.stringify({ groceryname: request.term }),
                        dataType: "json",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (data) {
                            alert('there is problem');
                        }
                    });
                }
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="home-title">
        <h1>Get Online Grocery</h1>
        <p>Order Grocery from favourite Shops near you.</p>

       
                <div class="select-location">
                    <span class="icon"></span>
                    <select>
                        <option>GokalPur</option>
                        <option>Yamuna Vihar</option>
                        <option>Karawal Nagar Nagar</option>
                        <option>Shiv Vihar</option>

                    </select>
                </div>
          
                <div class="search-grocery">

                    <asp:TextBox ID="txtfindgrocery" runat="server" CssClass="findbtn" placeholder="Search for Grocery"></asp:TextBox>

                    <div class="grocerydata" id="divproductplaceholder" runat="server">
                    </div>


                </div>
           
                <button>
                    <asp:LinkButton ID="lbtnGrocerysearch" runat="server">Search</asp:LinkButton>
                </button>
           

    </div>
    <div class="container tablefeatured">
        <div class="allGrocery" id="Grocerysection" runat="server">
        </div>
        <div class="featuredimages">
            <asp:Image runat="server" ImageUrl="~/image/casserole-dish-2776735_1920.jpg"/>
            <asp:Image runat="server" ImageUrl="~/image/almonds-1768792_1920.jpg" />


            <asp:Image runat="server" ImageUrl="~/image/spices-2548653_1920.jpg" />
              <asp:Image runat="server" ImageUrl="~/image/top-5079764_1920.jpg" />
        </div>
    </div>
</asp:Content>

