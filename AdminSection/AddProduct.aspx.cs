using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class AdminSection_AddProduct : System.Web.UI.Page
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
        Connection conn = new Connection();
        SqlCommand cmd = new SqlCommand("Select * from product_Details", conn.con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void productbutton_Click(object sender, EventArgs e)
    {
        Connection conn = new Connection();
        if (txtfuproductimage.HasFile)
        {
            txtfuproductimage.PostedFile.SaveAs(Server.MapPath(".") + "//Product_Images//" + txtfuproductimage.FileName);
            Session["imagepath"] = "/AdminSection/Product_Images/" + txtfuproductimage.FileName;
            SqlCommand cmd = new SqlCommand("insert into product_Details values(@product_name,@product_company,@product_img_url,@product_price,@product_category,@product_description)", conn.con);
            cmd.Parameters.AddWithValue("@product_name", txtproductname.Text);
            cmd.Parameters.AddWithValue("@product_company", txtproductcomapnay.Text);
            cmd.Parameters.AddWithValue("@product_img_url", Session["Imagepath"].ToString());
            cmd.Parameters.AddWithValue("@product_price", txtproductprice.Text);
            cmd.Parameters.AddWithValue("@product_category", txtproductcategory.Text);
            cmd.Parameters.AddWithValue("@product_description", txtproductdescript.Text);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script>alert('Product Added Successfully') </script>");
                fillgridview();
            }
        }
    }


    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        fillgridview();

    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        fillgridview();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Connection conn = new Connection();
        Label LBLPRODUCTID = (Label)GridView1.Rows[e.RowIndex].FindControl("LBLPRODUCTID");
        TextBox txtgvproductname = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtgvproductname");
        TextBox txtgvproductcompany = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtgvproductcompany");
        TextBox txtgvproductprice = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtgvproductprice");
        TextBox txtgvproductcategory = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtgvproductcategory");
        TextBox txtgvproductdesc = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtgvproductdesc");
        FileUpload fugvproductimage = (FileUpload)GridView1.Rows[e.RowIndex].FindControl("fugvproductimage");
        if (fugvproductimage.HasFile)
        {
            fugvproductimage.PostedFile.SaveAs(Server.MapPath("//Product_Images//") + fugvproductimage.FileName);
            Session["imagepathgv"] = "/Admin Section/Product_Images/" + fugvproductimage.FileName;

            SqlCommand cmd1 = new SqlCommand("update product_Details set product_name@product_name,product_company@product_company,product_img_url@product_img_url,product_price@product_price,product_category@product_category,product_description@product_description where product_id=@id)", conn.con);
            cmd1.Parameters.AddWithValue("@id", LBLPRODUCTID.Text);
            cmd1.Parameters.AddWithValue("@product_name", txtgvproductname.Text);
            cmd1.Parameters.AddWithValue("@product_company", txtgvproductcompany.Text);
            cmd1.Parameters.AddWithValue("@product_img_url", Session["Imagepathgv"].ToString());
            cmd1.Parameters.AddWithValue("@product_price", txtgvproductprice.Text);
            cmd1.Parameters.AddWithValue("@product_category", txtgvproductcategory.Text);
            cmd1.Parameters.AddWithValue("@product_description", txtgvproductdesc.Text);
            int i = cmd1.ExecuteNonQuery();
            if (i > 0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script>alert('Product Added Successfully') </script>");
                GridView1.EditIndex = -1;
                fillgridview();
            }
        }
        else
        {
            SqlCommand cmd1 = new SqlCommand("update product_Details set product_name=@product_name,product_company=@product_company,product_price=@product_price,product_category=@product_category,product_description=@product_description where product_id=@id", conn.con);
            cmd1.Parameters.AddWithValue("@id", LBLPRODUCTID.Text);
            cmd1.Parameters.AddWithValue("@product_name", txtgvproductname.Text);
            cmd1.Parameters.AddWithValue("@product_company", txtgvproductcompany.Text);
            cmd1.Parameters.AddWithValue("@product_price", txtgvproductprice.Text);
            cmd1.Parameters.AddWithValue("@product_category", txtgvproductcategory.Text);
            cmd1.Parameters.AddWithValue("@product_description", txtgvproductdesc.Text);
            int i = cmd1.ExecuteNonQuery();
            if (i > 0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script>alert('Product Updated Successfully') </script>");
                GridView1.EditIndex = -1;
                fillgridview();
            }
        }

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Connection conn = new Connection();
        Label LBLPRODUCTID = (Label)GridView1.Rows[e.RowIndex].FindControl("LBLPRODUCTID");
        SqlCommand cmd = new SqlCommand("Delete product_Details where product_id=@id", conn.con);
        cmd.Parameters.AddWithValue("@id", LBLPRODUCTID.Text);
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script>alert('Product Deleted Successfully') </script>");
            GridView1.EditIndex = -1;
            fillgridview();
        }
    }
}