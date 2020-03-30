using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;
using System.Xml.Serialization;

namespace OnlineClothingStore
{
    

    public partial class CreateAccount : Page
    {
        //sql database connection
        SqlConnection con;
        //Here we declare the parameter which we have to use in our application  
        SqlCommand cmd = new SqlCommand();
        SqlParameter sp1 = new SqlParameter();
        SqlParameter sp2 = new SqlParameter();
        SqlParameter sp3 = new SqlParameter();
        SqlParameter sp4 = new SqlParameter();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //You will need to change the SqlConntion to the appropriate filepath
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Users\\owner\\Documents\\VS2019\\OnlineClothingStore\\OnlineClothingStore\\App_Data\\Store.mdf;Integrated Security=True");
            cmd = new SqlCommand("spCreateAccount", con);
            cmd.Parameters.Add("@firstName", SqlDbType.VarChar).Value = firstName.Text;
            cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = lastName.Text;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email.Text;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password.Text;
            cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = address.Text;
            SqlParameter retval = cmd.Parameters.Add("@success", SqlDbType.Bit);
            retval.Direction = ParameterDirection.Output;
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.ExecuteNonQuery();
            bool retunvalue = (bool)cmd.Parameters["@success"].Value;
            con.Close();
        }
    }

}