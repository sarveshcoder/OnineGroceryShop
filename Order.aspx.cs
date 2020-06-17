using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public partial class Order : System.Web.UI.Page
{
    StringBuilder htmltable = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillhtmltable();
        }
    }

    public void fillhtmltable()
    {
        Connection con = new Connection();
        SqlCommand cmd = new SqlCommand("getpaymentproductbyuserid", con.con);
        cmd.Parameters.AddWithValue("@userid", Session["userid"].ToString());
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            htmltable.Append("<h1>My Order Details</h1>");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                htmltable.Append("<h3 >Food " + dt.Rows[i]["Food_Name"] + "</h3>");
                htmltable.Append("<table id='table_id' style='background-color:#eee;padding:25px;border: 1px solid #5555;' >");
                htmltable.Append("<tr><td>FOOD NAME:-</td><td>" + dt.Rows[i]["Food_Name"] + "</td></tr>");
                htmltable.Append("<tr><td>FOOD CATEGORY:-</td><td>" + dt.Rows[i]["Food_category"] + "</td></tr>");
                htmltable.Append("<tr><td>FOOD PRICE:-</td><td>" + dt.Rows[i]["Food_Price"] + "</td></tr>");
                htmltable.Append("<tr><td>DATE:-</td><td>" + dt.Rows[i]["Payment_Date"] + "</td></tr>");
                htmltable.Append("<tr><td>PAYMENT ID:-</td><td>" + dt.Rows[i]["Payment_Id"] + "</td></tr>");
                htmltable.Append("<tr><td><a href='DeliveryStatus.aspx?id=" + dt.Rows[i]["payment_ID"].ToString() + "'>CHECK DELIVERY STATUS</td></tr>");
                htmltable.Append("</table>");
            }

            dvorder.Controls.Add(new Literal { Text = htmltable.ToString() });
        }
        else
        {
            htmltable.Append("<table><tr><td>NO RECORD</td></tr></table>");
            dvorder.Controls.Add(new Literal { Text = htmltable.ToString() });
        }
    }
}