using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminSection_Admin1MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void lbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminHome.aspx");
    }
    protected void addproduct_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddProduct.aspx");
    }

    protected void Getorder_Click(object sender, EventArgs e)
    {
        Response.Redirect("Order.aspx");
    }

    protected void Cart_Click(object sender, EventArgs e)
    {
        Response.Redirect("Cart.aspx");
    }
    protected void payment_Click(object sender, EventArgs e)
    {
        Response.Redirect("Checkout.aspx");
    }
}
