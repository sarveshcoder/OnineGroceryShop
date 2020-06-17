using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class orderplace : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgridview();
        }
    }
    public void fillgridview()
    {
        string userid = Request.QueryString["id"];
        string payment = Request.QueryString["payment"];
        if (userid != null && userid != "")
        {
            if (payment == "cart")
            {
                Connection con = new Connection();
                SqlCommand cmd = new SqlCommand("getpaymentdetailsbyidanddate", con.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@payment", Session["paymentcart"].ToString());
                cmd.Parameters.AddWithValue("@userid", int.Parse(userid));
                cmd.Parameters.AddWithValue("@date", Session["datecart"].ToString());
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                lblpaymentid.Text = Session["paymentcart"].ToString();
                lblnoofproduts.Text = dt.Rows.Count.ToString();
                SqlDataReader sdr = cmd.ExecuteReader();
                int price = 0;
                while (sdr.Read())
                {
                    price = price + (int.Parse(sdr["total_price"].ToString()));
                }
                lblprice.Text = price.ToString();
                lblshipingprice.Text = "100";
                lbltotalprice.Text = (price + 100).ToString();
                gvpaymentdetails.DataSource = dt;
                gvpaymentdetails.DataBind();
            }
            else if (payment == "product")
            {
                Connection con = new Connection();
                SqlCommand cmd = new SqlCommand("getpaymentproductdetailsbyidanddate", con.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@payment", Session["paymentproduct"].ToString());
                cmd.Parameters.AddWithValue("@userid", int.Parse(userid));
                cmd.Parameters.AddWithValue("@date", Session["dateproduct"].ToString());
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                lblpaymentid.Text = dt.Rows[0]["payment_ID"].ToString();
                lblnoofproduts.Text = dt.Rows.Count.ToString();
                SqlDataReader sdr = cmd.ExecuteReader();
                int price = 0;
                while (sdr.Read())
                {
                    price = price + (int.Parse(sdr["Total_amount"].ToString()));
                }
                lblprice.Text = price.ToString();
                lblshipingprice.Text = "100";
                lbltotalprice.Text = (price + 100).ToString();
                gvpaymentdetails.DataSource = dt;
                gvpaymentdetails.DataBind();
            }
            else
            {
                Response.Redirect("homePage.aspx");
            }

        }
    }
    protected void btncontinueshoping_Click(object sender, EventArgs e)
    {
        Response.Redirect("homePage.aspx");
    }
}