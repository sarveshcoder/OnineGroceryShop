using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for GoGWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class GoGWebService : System.Web.Services.WebService {

    public GoGWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public List<string> GetgroceryName(string groceryname)
    {
        Connection con = new Connection();
        List<string> grocerynames = new List<string>();
        SqlCommand cmd = new SqlCommand("getallgrocerynames", con.con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@groceryname", groceryname);

        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {

            grocerynames.Add(rdr["product_name"].ToString());

        }

        return grocerynames;
    }
    
}
