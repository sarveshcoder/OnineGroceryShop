using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class Cart : System.Web.UI.Page
{
   
    int price = 0;
    int shipingcharges = 100;
    int totalamount = 0;
    
    public void fillgridview()
    {
        if (Session["userid"] != null)
        {
            emptycart.Visible = false;
            Connection con = new Connection();
            SqlCommand cmd = new SqlCommand("getcartproductdetailsbyuserid", con.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", int.Parse(Session["userid"].ToString()));
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    price = price + (Convert.ToInt32(sdr["Total_price"]));

                }

                totalamount = shipingcharges + price;

                lblprice.Text = price.ToString();
                lblshipcharges.Text = shipingcharges.ToString();
                lbltotalprice.Text = totalamount.ToString();
                lbltotalcartvalue.Text = dt.Rows.Count.ToString();
                gvcartproduct.DataSource = dt;
                gvcartproduct.DataBind();
            }
            else
            {
                gvcart.Visible = false;
                emptycart.Visible = true;
            }
        }
        else
        {
            gvcart.Visible = false;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            fillgridview();
        }
    }
    protected void btnplaceorder_Click(object sender, EventArgs e)
    {
        Response.Redirect("Checkout.aspx?id=" + Session["userid"].ToString() + "&payment=cart&price=" + lblprice.Text + "");
    }
    protected void btncontinueshoping_Click(object sender, EventArgs e)
    {
        Response.Redirect("homePage.aspx");
    }
    protected void gvcartproduct_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvcartproduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvcartproduct_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void gvcartproduct_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }
}