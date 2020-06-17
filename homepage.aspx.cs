using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public partial class homepage : System.Web.UI.Page
{
    StringBuilder htmltable = new StringBuilder();

    int no;
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
        SqlCommand cmd = new SqlCommand("getproductimage", con.con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            htmltable.Append("<table id='table_id'>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                htmltable.Append("<tr>");
                htmltable.Append("<td><img src='" + dt.Rows[i]["product_img_url"].ToString() + "' style='height: 186px;width:269px;'></td>");
                htmltable.Append("<td> Product Name:- " + dt.Rows[i]["product_name"].ToString() + "<br/> Product Category :- " + dt.Rows[i]["product_category"].ToString() + "<br/> Product Company :- " + dt.Rows[i]["product_company"].ToString() + "<br/> Product Description :- " + dt.Rows[i]["product_description"].ToString() + "<br/>Price:-" + dt.Rows[i]["product_price"].ToString() + "<br/><br/><a href='product.aspx'>ORDER NOW</a><br/><br/><a href='product.aspx?id=" + dt.Rows[i]["product_id"].ToString() + "'>VIEW DETAILS</a> </td>");
                htmltable.Append("</tr>");
            }
            htmltable.Append("</table>");
            Grocerysection.Controls.Add(new Literal { Text = htmltable.ToString() });
        }
        else
        {
            htmltable.Append("<table><tr><td>NO RECORD</td></tr></table>");
            Grocerysection.Controls.Add(new Literal { Text = htmltable.ToString() });
        }
    }
    public void filltablebyfoodname()
    {
        Connection con = new Connection();
        SqlCommand cmd = new SqlCommand("getfoodbyname", con.con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@groceryname", txtfindgrocery);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            htmltable.Append("<table id='table_id'>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                htmltable.Append("<tr>");
                htmltable.Append("<td> <img src='" + dt.Rows[i]["Food_img_url"].ToString() + "' style='height: 186px;width:269px;'></td>");
                htmltable.Append("<td> Food :- " + dt.Rows[i]["product_name"].ToString() + "<br/> Category :- " + dt.Rows[i]["product_category"].ToString() + "<br/> Food Company :- " + dt.Rows[i]["product_company"].ToString() + "<br/> Food Description :- " + dt.Rows[i]["product_description"].ToString() + "<br/>Price:-" + dt.Rows[i]["product_price"].ToString() + "<br/><br/><a href='Food.aspx'>ORDER NOW</a> <br/><br/><a href='Food.aspx?id=" + dt.Rows[i]["product_id"].ToString() + "'>VIEW DETAILS</a></td>");
                htmltable.Append("</tr>");
            }
            htmltable.Append("</table>");
            divproductplaceholder.Controls.Add(new Literal { Text = htmltable.ToString() });
        }
        else
        {
            htmltable.Append("<table><tr><td>NO RECORD</td></tr></table>");
            divproductplaceholder.Controls.Add(new Literal { Text = htmltable.ToString() });
        }
    }

    protected void lbtnfoodsearch_Click(object sender, EventArgs e)
    {
        htmltable.Append("");
        divproductplaceholder.Controls.Add(new Literal { Text = htmltable.ToString() });
        filltablebyfoodname();
    }
}