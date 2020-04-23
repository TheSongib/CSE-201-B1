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


    public partial class Sell : Page
    {
        //sql database connection
        SqlConnection con;
        //Here we declare the parameter which we have to use in our application  
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //Dont let user make listing if user is not logged in
            if (Session["userId"] == null)
            {
                //Display error message if user is not logged in
                Error.Text = "ERROR: Not Logged In";
            }
            else
            {
                Error.Text = "";
                //establish connect to stored procedure and execute
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
                cmd = new SqlCommand("spAddListing", con);
                cmd.Parameters.Add("@userId", SqlDbType.Int).Value = (int)Session["userId"];
                cmd.Parameters.Add("@title", SqlDbType.VarChar, 50).Value = listingTitle.Text;
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = Int32.Parse(Price.Text);
                cmd.Parameters.Add("@category", SqlDbType.VarChar, 50).Value = Category.SelectedItem.Text;
                cmd.Parameters.Add("@description", SqlDbType.VarChar, 1000).Value = Description.Text;
                SqlParameter retval = cmd.Parameters.Add("@success", SqlDbType.Int);
                retval.Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.ExecuteNonQuery();
                int returnvalue = (int)cmd.Parameters["@success"].Value;

                //Create folder for this listing
                string path = Server.MapPath("/Content/Images/") + Session["userId"];
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //Check if listng was created
                if (returnvalue == 0)
                {
                    //Display message for duplicate listing here
                    Error.Text = "ERROR: Duplicate Item";
                }
                else
                {
                    path = path + "/" + returnvalue.ToString() + "/";
                    Directory.CreateDirectory(path);

                    //Make sure image file names have no spaces
                    if (image1.HasFile)
                    {
                        image1.PostedFile.SaveAs(path + image1.FileName.Replace(' ', '_'));
                        cmd = new SqlCommand("spAddRemoveImages", con);
                        cmd.Parameters.Add("@imageId", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@listingId", SqlDbType.Int).Value = returnvalue;
                        cmd.Parameters.Add("@imageName", SqlDbType.VarChar, 50).Value = image1.FileName.Replace(' ', '_');
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                    }
                        
                    if (image2.HasFile)
                    {
                        image2.PostedFile.SaveAs(path + image2.FileName.Replace(' ', '_'));
                        cmd = new SqlCommand("spAddRemoveImages", con);
                        cmd.Parameters.Add("@imageId", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@listingId", SqlDbType.Int).Value = returnvalue;
                        cmd.Parameters.Add("@imageName", SqlDbType.VarChar, 50).Value = image2.FileName.Replace(' ', '_');
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                    }
                        
                    if (image3.HasFile)
                    {
                        image3.PostedFile.SaveAs(path + image3.FileName.Replace(' ', '_'));
                        cmd = new SqlCommand("spAddRemoveImages", con);
                        cmd.Parameters.Add("@imageId", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@listingId", SqlDbType.Int).Value = returnvalue;
                        cmd.Parameters.Add("@imageName", SqlDbType.VarChar, 50).Value = image3.FileName.Replace(' ', '_');
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                    }
                        
                    if (image4.HasFile)
                    {
                        image4.PostedFile.SaveAs(path + image4.FileName.Replace(' ', '_'));
                        cmd = new SqlCommand("spAddRemoveImages", con);
                        cmd.Parameters.Add("@imageId", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@listingId", SqlDbType.Int).Value = returnvalue;
                        cmd.Parameters.Add("@imageName", SqlDbType.VarChar, 50).Value = image4.FileName.Replace(' ', '_');
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                    }
                        
                    if (image5.HasFile)
                    {
                        image5.PostedFile.SaveAs(path + image5.FileName.Replace(' ', '_'));
                        cmd = new SqlCommand("spAddRemoveImages", con);
                        cmd.Parameters.Add("@imageId", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@listingId", SqlDbType.Int).Value = returnvalue;
                        cmd.Parameters.Add("@imageName", SqlDbType.VarChar, 50).Value = image5.FileName.Replace(' ', '_');
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                    }
                        
                    
                    //located at the "path" string and then add them to Images table in database using spAddRemoveImages

                    Response.Redirect(Request.RawUrl);
                }
                con.Close();
            }
        }
    }

}