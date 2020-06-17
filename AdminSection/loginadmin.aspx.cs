using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_Section_loginadmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void login_Click(object sender, EventArgs e)
    {
        Connection conn = new Connection();
        SqlCommand cmd=new SqlCommand("select * from admin_details where Admin_name=@name and Admin_password=@password",conn.con);
        cmd.Parameters.AddWithValue("@name",name.Text);
        cmd.Parameters.AddWithValue("@password",txtpassword.Text);
        SqlDataAdapter sda=new SqlDataAdapter(cmd);
        DataSet ds=new DataSet();
        sda.Fill(ds);
        if(ds.Tables[0].Rows.Count>0)
        {
            Session["Admin_Id"]=ds.Tables[0].Rows[0]["Admin_id"].ToString();
            Session["logintime"]=DateTime.Now.ToString();
            SqlCommand cmd1=new SqlCommand("Insert into logindata value(@id,@name,@password,@logintime,null)",conn.con);
            cmd1.Parameters.AddWithValue("@id",Session["Admin_id"].ToString());
            cmd1.Parameters.AddWithValue("@name",name.Text);
            cmd1.Parameters.AddWithValue("@password",txtpassword.Text);
            cmd1.Parameters.AddWithValue("@logintime",Session["logintime"].ToString());
            int i=cmd1.ExecuteNonQuery();
            if(i>0)
            {
                Response.Redirect("Homepageadmin.aspx");
            }
        }
        else{
            ClientScript.RegisterStartupScript(Page.GetType(),"validation","<script>alert('INVALID USER NAME AND PASSWORD')</script>");
        }
    }
}