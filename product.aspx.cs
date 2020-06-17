using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            lblquantity.Text = "1";
            getcartdetailsbyproductcustomer();
            string productid = Request.QueryString["id"];
            if (Request.QueryString["message"] == "success")
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Successfully Added to cart')</script>");
            }

            if (productid != null)
            {
                fillproductdetails(productid);
            }
        }

    }

    public void getcartdetailsbyproductcustomer()
    {
        string id = Request.QueryString["id"];
        if (id != "" && id != null)
        {
            Connection con = new Connection();

            if (Session["userid"] != null)
            {
                SqlCommand cmd1 = new SqlCommand("select * from cartdetails where product_id=@productid and Cid=@userid", con.con);
                cmd1.Parameters.AddWithValue("@productid", int.Parse(id));
                cmd1.Parameters.AddWithValue("@userid", int.Parse(Session["userid"].ToString()));
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    lbtnaddtocart.Visible = false;
                    lbtngotocart.Visible = true;
                }
                else
                {
                    lbtngotocart.Visible = false;
                }

            }
            else
            {
                lbtngotocart.Visible = false;
                fillproductdetails(Request.QueryString["id"]);
            }
        }
        else
        {
            Response.Redirect("homePage.aspx");
        }
    }
    public void fillproductdetails(string productid)
    {
        Connection con = new Connection();
        SqlCommand cmd = new SqlCommand("select * from product_details where product_id=@productid", con.con);
        cmd.Parameters.AddWithValue("@productid",productid);

        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            lblproductname.Text = dt.Rows[0]["product_name"].ToString();
            lblcategory.Text = dt.Rows[0]["product_category"].ToString();
            lblprice.Text = dt.Rows[0]["product_price"].ToString();

            imgproduct.ImageUrl = dt.Rows[0]["product_img_url"].ToString();
            lbltotalprice.Text = lblprice.Text;
        }
    }
    protected void lbtnaddtocart_Click(object sender, EventArgs e)
    {
        if (Session["userid"] != null)
        {
            Connection con = new Connection();
            SqlCommand cmd = new SqlCommand("insert into cartdetails values(@Product_id,@userid,@Quantity,@Total_price)", con.con);
            cmd.Parameters.AddWithValue("@Product_id", int.Parse(Request.QueryString["id"]));
            cmd.Parameters.AddWithValue("@userid", int.Parse(Session["userid"].ToString()));
            cmd.Parameters.AddWithValue("@Quantity", int.Parse(lblquantity.Text));
            cmd.Parameters.AddWithValue("@Total_price", int.Parse(lbltotalprice.Text));
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                Response.Redirect("product.aspx?id=" + Request.QueryString["id"] + "&message=success");

            }

        }
        else
        {
            Response.Redirect("Cart.aspx");
        }
    }
    protected void lbtngotocart_Click(object sender, EventArgs e)
    {
        Response.Redirect("Cart.aspx");
    }
    protected void lbtnordernow_Click(object sender, EventArgs e)
    {
        if (Session["userid"] != null)
        {
            Session["productid"] = Request.QueryString["id"];
            Session["productname"] = lblproductname.Text;
            Session["price"] = lblprice.Text;
            Session["quantity"] = lblquantity.Text;
            Session["totalamount"] = lbltotalprice.Text;
            Response.Redirect("Checkout.aspx?payment=product");
        }
    }
    protected void btnminus_Click(object sender, EventArgs e)
    {
        if (int.Parse(lblquantity.Text) > 1)
        {
            int quantity = int.Parse(lblquantity.Text) - 1;
            lbltotalprice.Text = (quantity * int.Parse(lblprice.Text)).ToString();
            lblquantity.Text = quantity.ToString();
        }
    }
    protected void btnplus_Click(object sender, EventArgs e)
    {
        int quantity = 1 + int.Parse(lblquantity.Text);
        lbltotalprice.Text = (quantity * int.Parse(lblprice.Text)).ToString();
        lblquantity.Text = quantity.ToString();
    }
}