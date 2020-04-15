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


    public partial class Submissions : Page
    {
        //sql database connection
        SqlConnection con;
        //Here we declare the parameter which we have to use in our application  
        SqlCommand cmd = new SqlCommand();
        //listing id we will be reviewing
        int listingId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //set appropriate elements for view
            review.Visible = true;
            finished.Visible = false;

            //Create connection to stored procedure and execute
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            cmd = new SqlCommand("spGetSubmission", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            //Read data
            SqlDataReader reader = cmd.ExecuteReader();

            //Check if anything came back, if not show default page
            if (reader.HasRows)
            {
                //read data
                while (reader.Read())
                {
                    //input listing data into review page
                    listingId = (int)reader[0];
                    title.InnerText = (string)reader[1];
                    author.InnerText = (string)reader[2] + " " + reader[3];
                    price.InnerText = reader[4].ToString();
                    category.InnerText = (string)reader[5];
                    //if there is a description present, put it here
                    if (reader[6] != null)
                    {
                        description.InnerText = (string)reader[6];
                    }
                }
            }
            else
            {
                //Show default page if no submissions are awaiting approval
                finished.Visible = true;
                review.Visible = false;
            }
        }

        protected void Accept_Click(object sender, EventArgs e)
        {
            //Create connection to stored procedure and execute
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            cmd = new SqlCommand("spApproveRemoveSubmission", con);
            cmd.Parameters.Add("@listingId", SqlDbType.Int).Value = listingId;
            cmd.Parameters.Add("@approved", SqlDbType.Bit).Value = 1;
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.ExecuteNonQuery();

            //Refresh current page
            Response.Redirect(Request.RawUrl);
        }

        protected void Decline_Click(object sender, EventArgs e)
        {
            //Create connection to stored procedure and execute
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            cmd = new SqlCommand("spApproveRemoveSubmission", con);
            cmd.Parameters.Add("@listingId", SqlDbType.Int).Value = listingId;
            cmd.Parameters.Add("@approved", SqlDbType.Bit).Value = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.ExecuteNonQuery();

            //Refresh current page
            Response.Redirect(Request.RawUrl);
        }
    }
}
