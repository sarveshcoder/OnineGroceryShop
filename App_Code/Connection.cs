using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
/// <summary>
/// Summary description for Connection
/// </summary>
public class Connection
{
    public SqlConnection con;
	public Connection()
	{
        con=new SqlConnection(WebConfigurationManager.ConnectionStrings["onlinegrocery"].ConnectionString);
        
        con.Open();
	}
}