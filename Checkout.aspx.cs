using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Checkout : System.Web.UI.Page
{
   

     protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            filldetailsofpayment();
        }
    }
     public void filldetailsofpayment()
     {
         if (Session["userid"] != null)
         {
             if (Request.QueryString["payment"] == "cart")
             {
                 Connection con = new Connection();
                 SqlCommand cmd = new SqlCommand("getcartproductdetailsbyuserid", con.con);
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.AddWithValue("@userid", int.Parse(Session["userid"].ToString()));
                 SqlDataAdapter sda = new SqlDataAdapter(cmd);
                 DataTable dt = new DataTable();
                 sda.Fill(dt);
                 Session["cart_id"] = dt.Rows[0]["cart_id"].ToString();
                 lblnoofproducts.Text = dt.Rows.Count.ToString();
                 SqlCommand cmd1 = new SqlCommand("select Max(S_no) from Payment_Details", con.con);
                 string i = cmd1.ExecuteScalar().ToString();
                 if (i == "")
                 {
                     lblpaymentid.Text = "pay0001";
                 }
                 else
                 {
                     int j = int.Parse(i);
                     j++;
                     lblpaymentid.Text = "pay0001" + j.ToString();
                 }

                 lblpriceofproduct.Text = Request.QueryString["price"];
                 lblshipingcharges.Text = "100";
                 lbltotalprice.Text = ((int.Parse(lblpriceofproduct.Text) + int.Parse(lblshipingcharges.Text))).ToString();
                 SqlCommand cmd2 = new SqlCommand("select * from registration where cust_id=@userid", con.con);
                 cmd2.Parameters.AddWithValue("@userid", int.Parse(Session["userid"].ToString()));
                 SqlDataReader sdr2 = cmd2.ExecuteReader();
                 while (sdr2.Read())
                 {
                     lblshipingaddress.Text = sdr2["address"].ToString();
                 }
                 productdetails.DataSource = dt;
                 productdetails.DataBind();
                 con.con.Close();
             }
             else if (Request.QueryString["payment"] == "product")
             {
                 Connection con = new Connection();
                 SqlCommand cmd1 = new SqlCommand("select Max(S_no) from Payment_Details", con.con);
                 string i = cmd1.ExecuteScalar().ToString();
                 if (i == "")
                 {
                     lblpaymentid.Text = "pay0001";
                 }
                 else
                 {
                     int j = int.Parse(i);
                     j++;
                     lblpaymentid.Text = "pay0001" + j.ToString();
                 }
                 lblpriceofproduct.Text = Session["totalamount"].ToString();
                 lblshipingcharges.Text = "100";
                 lbltotalprice.Text = ((int.Parse(lblpriceofproduct.Text) + int.Parse(lblshipingcharges.Text))).ToString();
                 SqlCommand cmd2 = new SqlCommand("select * from registration where cust_id=@userid", con.con);
                 cmd2.Parameters.AddWithValue("@userid", int.Parse(Session["userid"].ToString()));
                 SqlDataReader sdr2 = cmd2.ExecuteReader();
                 while (sdr2.Read())
                 {
                     lblshipingaddress.Text = sdr2["address"].ToString();
                 }
                 con.con.Close();
                 con.con.Open();
                 SqlCommand cmd = new SqlCommand("select * from product_details where product_id='" + int.Parse(Session["productid"].ToString()) + "'", con.con);
                 SqlDataAdapter sda = new SqlDataAdapter(cmd);
                 DataTable dt = new DataTable();
                 sda.Fill(dt);
                 productdetails.DataSource = dt;
                 productdetails.DataBind();
                 con.con.Close();
             }
             else
             {
                 Response.Redirect("homePage.aspx");
             }
         }
     }
    protected void btnconfirmandpay_Click(object sender, EventArgs e)
    {
        if (Session["userid"] != null)
        {
            if (Request.QueryString["payment"] == "cart")
            {
                string datetime = DateTime.Now.ToString();
                Connection con = new Connection();
                SqlCommand cmd = new SqlCommand("select * from cartdetails where Cid='" + Session["userid"].ToString() + "'", con.con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                int count = 0;
                if (dt.Rows.Count > 0)
                {
                    while (count < dt.Rows.Count)
                    {
                        SqlCommand cmd1 = new SqlCommand("insert into Payment_Details values(@payment_ID,@card,@productid,@cart_id,null,null,@total,@userid,@datetime)", con.con);
                        cmd1.Parameters.AddWithValue("@payment_ID", lblpaymentid.Text);
                        cmd1.Parameters.AddWithValue("@cart_id", int.Parse(dt.Rows[count]["cart_id"].ToString()));
                        cmd1.Parameters.AddWithValue("@productid", int.Parse(dt.Rows[count]["product_id"].ToString()));
                        cmd1.Parameters.AddWithValue("@userid", int.Parse(Session["userid"].ToString()));
                        cmd1.Parameters.AddWithValue("@datetime", datetime);
                        cmd1.Parameters.AddWithValue("@card", "CARD");
                        cmd1.Parameters.AddWithValue("@total", dt.Rows[0]["total_price"].ToString());
                        cmd1.ExecuteNonQuery();
                        count++;
                    }
                    Session["paymentcart"] = lblpaymentid.Text;
                    Session["datecart"] = datetime;
                    Response.Redirect("orderplace.aspx?id=" + Session["userid"].ToString() + "&payment=cart");
                }


            }
            else
            {
                string datetime = DateTime.Now.ToString();
                Connection con = new Connection();
                SqlCommand cmd1 = new SqlCommand("insert into Payment_Details values(@payment_ID,@card,@productid,null,@price,@shipping,@total,@userid,@datetime)", con.con);
                cmd1.Parameters.AddWithValue("@payment_ID", lblpaymentid.Text);
                cmd1.Parameters.AddWithValue("@productid", Session["productid"].ToString());
                cmd1.Parameters.AddWithValue("@price", Session["price"].ToString());
                cmd1.Parameters.AddWithValue("@shipping", "100");
                cmd1.Parameters.AddWithValue("@total", Session["totalamount"].ToString());
                cmd1.Parameters.AddWithValue("@userid", int.Parse(Session["userid"].ToString()));
                cmd1.Parameters.AddWithValue("@datetime", datetime);
                cmd1.Parameters.AddWithValue("@card", "CARD");
                cmd1.ExecuteNonQuery();
                Session["paymentproduct"] = lblpaymentid.Text;
                Session["dateproduct"] = datetime;
                Response.Redirect("orderplace.aspx?id=" + Session["userid"].ToString() + "&payment=product");
            }
        }
    }
}