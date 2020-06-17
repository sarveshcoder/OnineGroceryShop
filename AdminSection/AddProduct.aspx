<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSection/Admin1MasterPage.master" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="AdminSection_AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/Addproduct.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="mainproduct">
        
            <div class="headerproduct">
                <h1 >ADD PRODUCTS PAGE!</h1>
            </div>
            <div class="contentproduct">
                <div class="productname">
                    PRODUCT_NAME	
                <asp:TextBox ID="txtproductname" runat="server" palceholder="Enter Product Name" CssClass="LOGINBOX"></asp:TextBox>
                </div>
                <div class="productcompany">
                    PRODUCT_COMPANY
                <asp:TextBox ID="txtproductcomapnay" runat="server" palceholder="Enter Product Comapny" CssClass="LOGINBOX"></asp:TextBox>
                </div>
                <div class="productimage" >
                    PRODUCT_IMAGE
                <asp:FileUpload ID="txtfuproductimage" runat="server" />
                </div>
                <div class="productprice">
                    PRODUCT_PRICE
                <asp:TextBox ID="txtproductprice" runat="server" palceholder="Enter Product Price" CssClass="LOGINBOX"></asp:TextBox>
                </div>
                <div class="productcategory">
                    PRODUCT_CATEGORY
                <asp:TextBox ID="txtproductcategory" runat="server" palceholder="Enter Product Category" CssClass="LOGINBOX"></asp:TextBox>
                </div>
                <div class="productdescript">
                    PRODUCT_DESCRIPTION
                <asp:TextBox ID="txtproductdescript" runat="server" palceholder="Enter Product Description" CssClass="LOGINBOX"></asp:TextBox>
                </div>
                <div class="addbutton">
                    <asp:Button ID="productbutton" runat="server" Text="ADD PRODUCT"  CssClass="LOGBUTTON" OnClick="productbutton_Click" />
                </div>
            </div>
        </div>
        <div class="procuductGV" style="color: white">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="PRODUCT_ID">
                        <ItemTemplate>
                            <asp:Label ID="LBLPRODUCTID" runat="server" Text='<%#Eval("product_id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PRODUCT_NAME">
                        <ItemTemplate>
                            <%#Eval("product_name") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtgvproductname" runat="server" Text='<%#Eval("product_name") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PRODUCT_COMPANY">
                        <ItemTemplate>
                            <%#Eval("product_company") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtgvproductcompany" runat="server" Text='<%#Eval("product_company") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PRODUCT_IMAGE">
                        <ItemTemplate>
                            <asp:Image ID="imgproduct" runat="server" ImageUrl='<%#Eval("product_img_url") %>' Height="70px" Width="70px" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:FileUpload ID="fugvproductimage" runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PRODUCT_PRICE">
                        <ItemTemplate>
                            <%#Eval("product_price") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtgvproductprice" runat="server" Text='<%#Eval("product_price") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PRODUCT_CATEGORY">
                        <ItemTemplate>
                            <%#Eval("product_category") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtgvproductcategory" runat="server" Text='<%#Eval("product_category") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PRODUCT_DESCRIPTION">
                        <ItemTemplate>
                            <%#Eval("product_description") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtgvproductdesc" runat="server" Text='<%#Eval("product_description") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField></asp:TemplateField>
                    <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField HeaderText="Delete" ShowEditButton="True" />
                </Columns>

            </asp:GridView>
        </div>
    </div>
</asp:Content>

