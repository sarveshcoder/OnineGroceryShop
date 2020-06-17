<%@ Page Title="" Language="C#" MasterPageFile="~/GROCERYMasterPage.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="maincart" >
        <div class="cartheader">
             <h1>MY CART(<asp:Label ID="lbltotalcartvalue" runat="server"></asp:Label>) </h1>
        </div>
       <div class="contentcart">
            <div id="gvcart" class="gvcart" runat="server">
        
    <asp:GridView ID="gvcartproduct" runat="server" AutoGenerateColumns="False"  CellPadding="4" ForeColor="Black" OnRowEditing="gvcartproduct_RowEditing" OnRowDeleting="gvcartproduct_RowDeleting" OnRowUpdating="gvcartproduct_RowUpdating" OnRowCancelingEdit="gvcartproduct_RowCancelingEdit" BackColor="#CCCCCC" BorderColor="#000" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2">
        <Columns>
            <asp:TemplateField>
                 <ItemTemplate>
                    <asp:HiddenField ID="hiddencartid" runat="server" Value='<%#Bind("cart_id") %>'  />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    PRODUCT IMAGE<br />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtn" runat="server" Height="116px" Width="226px" ImageUrl='<%# Bind("product_img_url") %>' AlternateText='<%# Bind("product_id") %>' /> 
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    PRODUCT NAME<br />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblproductname" runat="server" Text='<%#Bind("product_name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

                <asp:TemplateField>
                <HeaderTemplate>
                    PRODUCT CATEGORY<br />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblproductcategory" runat="server" Text='<%#Bind("product_category") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-CssClass="gvwidth" ItemStyle-CssClass="gvcenter">
                <HeaderTemplate>
                   QUANTITY
                </HeaderTemplate>
                <ItemTemplate>
                   <asp:Label ID="lblquantity" runat="server" Text='<%#Bind("Quantity") %>'></asp:Label>                   
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtquantity" runat="server" Text='<%#Bind("Quantity")%>'></asp:TextBox><br />
                </EditItemTemplate>

<HeaderStyle CssClass="gvwidth"></HeaderStyle>

<ItemStyle CssClass="gvcenter"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-CssClass="gvwidth" ItemStyle-CssClass="gvcenter">
                <HeaderTemplate>
                    PRICE
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblprice" runat="server" Text='<%#Bind("product_price") %>'></asp:Label>
                </ItemTemplate>

<HeaderStyle CssClass="gvwidth"></HeaderStyle>

<ItemStyle CssClass="gvcenter"></ItemStyle>
            </asp:TemplateField>
             <asp:TemplateField HeaderStyle-CssClass="gvwidth" ItemStyle-CssClass="gvcenter">
                <HeaderTemplate>
                    TOTAL PRICE
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbltotalprice" runat="server" Text='<%#Bind("Total_price") %>'></asp:Label>
                </ItemTemplate>

<HeaderStyle CssClass="gvwidth"></HeaderStyle>

<ItemStyle CssClass="gvcenter"></ItemStyle>
            </asp:TemplateField>
        
            <asp:CommandField HeaderText="DELETE" ShowDeleteButton="True" HeaderStyle-CssClass="gvwidth" ItemStyle-CssClass="gvcenter">
<HeaderStyle CssClass="gvwidth"></HeaderStyle>

<ItemStyle CssClass="gvcenter"></ItemStyle>
            </asp:CommandField>
        <asp:CommandField HeaderText="ADD QUANTITY" ShowEditButton="true" EditText="ADD Quantity" UpdateText="ADD" HeaderStyle-CssClass="gvwidth" ItemStyle-CssClass="gvcenter">
<HeaderStyle CssClass="gvwidth"></HeaderStyle>

<ItemStyle CssClass="gvcenter"></ItemStyle>
            </asp:CommandField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <div class="pricedetails">
        PRICE :-<asp:Label ID="lblprice" runat="server"></asp:Label><br />
        SHIPPING CHARGES :-<asp:Label ID="lblshipcharges" runat="server"></asp:Label><br />
        TOTAL PRICE :-<asp:Label ID="lbltotalprice" runat="server"></asp:Label>
    </div>
    <div class="buttonpart">
        
        <asp:Button ID="btncontinueshoping" runat="server" Text="CONTINUE SHOPING"  Width="251px" CssClass="batn" OnClick="btncontinueshoping_Click"  />
        <asp:Button ID="btnplaceorder" runat="server" Text="PLACE ORDER"  Width="252px" CssClass="batn" OnClick="btnplaceorder_Click"  />
    </div>
        </div>
           <div class="emptycart" id="emptycart" runat="server">
        <div class="headercart">
            <h3>MY CART(0)
            </h3>
        </div>
        <div class="emptycontent">
            <h1 class="centerempty">YOUR CART IS EMPTY</h1>
            <asp:Image runat="server" ImageUrl="~/image/your-cart-is-empty.png"  />
        </div>
    </div>
       </div>
   </div>
</asp:Content>

