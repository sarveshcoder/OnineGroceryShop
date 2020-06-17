using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;



public partial class GROCERYMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["login"]!=null)
        {
            lbtnprofile.Visible = true;
            lbtnorder.Visible = true;
            lbtnlogout.Visible = true;
            MIDBT.Visible = false;
            lbtnprofile.Text = Session["login"].ToString();
        }
        else
        {
            lbtnprofile.Visible = false;
            lbtnorder.Visible = false;
            lbtnlogout.Visible = false;
            MIDBT.Visible = true;
        }
        if (Session["Userid"] != null)
        {
            Connection con = new Connection();
            SqlCommand cmd = new SqlCommand("select * from cartdetails where Cid='" + Session["Userid"].ToString() + "'", con.con);
            SqlDataAdapter sda =new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count>0){
                lblnoofitemincart.Text=dt.Rows.Count.ToString();
            }

        }
        else
        {
            lblnoofitemincart.Text="0";
        }
    }
    protected void lbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("homepage.aspx");
    }
    protected void signup_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registrationpage.aspx");
    }
    protected void MIDBT_Click(object sender, EventArgs e)
    {
        Response.Redirect("loginpage.aspx");
    }
    protected void contact_Click(object sender, EventArgs e)
    {
        Response.Redirect("contact.aspx");
    }
    protected void lbtnorder_Click(object sender, EventArgs e)
    {
        Response.Redirect("MyOrders.aspx");
    }
    protected void lbtnprofile_Click(object sender, EventArgs e)
    {

    }
    protected void lbtnlogout_Click(object sender, EventArgs e)
    {

        Connection conn = new Connection();
        SqlCommand cmd1 = new SqlCommand("update logindata set logout=@logout where Userid=@userid and logintime=@login", conn.con);
        cmd1.Parameters.AddWithValue("@userid", Session["userid"].ToString());
        cmd1.Parameters.AddWithValue("@login", Session["logintime"].ToString());
        cmd1.Parameters.AddWithValue("@logout", DateTime.Now.ToString());
        int i = cmd1.ExecuteNonQuery();
        if (i > 0)
        {
            Session.RemoveAll();
            Session.Clear();
            Session.Abandon();
            Response.Redirect("loginpage.aspx");
        }
    }
}
