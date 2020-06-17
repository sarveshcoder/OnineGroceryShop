using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class loginpage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void login_Click(object sender, EventArgs e)
    {
        Connection conn = new Connection();
        string query = "Select * from registration where Email=@Email and password=@password";
        SqlCommand cmd = new SqlCommand(query, conn.con);
        cmd.Parameters.AddWithValue("@Email", mail.Text);
        cmd.Parameters.AddWithValue("@password", txtpassword.Text);

        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["Userid"] = ds.Tables[0].Rows[0]["cust_id"].ToString();
            Session["logintime"] = DateTime.Now.ToString();
            SqlCommand cm = new SqlCommand("insert into logindata values(@Userid,@mail,@password,@logintime,null)", conn.con);
            cm.Parameters.AddWithValue("@Userid", Session["Userid"].ToString());
            cm.Parameters.AddWithValue("@mail", mail.Text);
            cm.Parameters.AddWithValue("@password", txtpassword.Text);
            cm.Parameters.AddWithValue("@logintime", Session["logintime"].ToString());
            int i = cm.ExecuteNonQuery();
            if (i > 0)
            {
                Response.Redirect("homepage.aspx");
            }
        }
    }
}