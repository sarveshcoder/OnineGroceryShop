using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class Registrationpage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void submit_Click(object sender, EventArgs e)
    {
        Connection conn = new Connection();
        string query = "insert into registration values(@name,@email,@password,@cnfpassword,@address,@contact)";
        SqlCommand cmd = new SqlCommand(query, conn.con);
        cmd.Parameters.AddWithValue("@name", name.Text);
        cmd.Parameters.AddWithValue("@email", mail.Text);
        cmd.Parameters.AddWithValue("@password", passwordreg.Text);
        cmd.Parameters.AddWithValue("@cnfpassword", passwordcnf.Text);
        cmd.Parameters.AddWithValue("@address", custaddress.Text);
        cmd.Parameters.AddWithValue("@contact", custcontact.Text);
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<Script> alert('Congrats! Data Saved Successfully')</Script>");
        }
    }
}