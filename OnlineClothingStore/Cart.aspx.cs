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


    public partial class Cart : Page
    {
        //sql database connection
        SqlConnection con;
        //Here we declare the parameter which we have to use in our application  
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Create connection to stored procedure for listings and execute
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            cmd = new SqlCommand("spGetCart", con);
            cmd.Parameters.Add("@userId", SqlDbType.VarChar).Value = Session["userId"];
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            //Read data
            SqlDataReader reader = cmd.ExecuteReader();

            //Check if anything came back, if not show no items in cart page
            if (reader.HasRows)
            {
                //Show cart, not empty cart text
                emptyCart.Visible = false;
                cart.Visible = true;

                //read data
                while (reader.Read())
                {
                    //these will be the elements of items in card
                    int listingId;
                    string title;
                    string author;
                    double price;
                    string category;
                    string description;

                    //These are the filepaths to set as the image source(s) whe displaying images
                    // also note that they may have up to 5, but possibly less.
                    string img1Src;
                    string img2Src;
                    string img3Src;
                    string img4Src;
                    string img5Src;

                    //input listing data into variables
                    listingId = (int)reader[0];
                    title = (string)reader[1];
                    author = (string)reader[2] + " " + reader[3];
                    price = (double)reader[4];
                    category = (string)reader[5];

                    //if there is a description present, put it here
                    if (reader[6] != null)
                    {
                        description = (string)reader[6];
                    }

                    //run stored provedur for getting 
                    SqlCommand imgCmd = new SqlCommand("spGetImages", con);
                    imgCmd.Parameters.Add("@listingId", SqlDbType.VarChar).Value = listingId;
                    imgCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader imgReader = imgCmd.ExecuteReader();
                    if (imgReader.HasRows)
                    {
                        //read data
                        if (imgReader.Read())
                        {
                            img1Src = "Content\\Images\\" + imgReader[0] + "\\" + imgReader[1] + "\\" + imgReader[2];
                        }
                        if (imgReader.Read())
                        {
                            img2Src = "Content\\Images\\" + imgReader[0] + "\\" + imgReader[1] + "\\" + imgReader[2];
                        }
                        if (imgReader.Read())
                        {
                            img3Src = "Content\\Images\\" + imgReader[0] + "\\" + imgReader[1] + "\\" + imgReader[2];
                        }
                        if (imgReader.Read())
                        {
                            img4Src = "Content\\Images\\" + imgReader[0] + "\\" + imgReader[1] + "\\" + imgReader[2];
                        }
                        if (imgReader.Read())
                        {
                            img5Src = "Content\\Images\\" + imgReader[0] + "\\" + imgReader[1] + "\\" + imgReader[2];
                        }
                    }
                    imgReader.Close();
                    

                    /**
                     * 
                     * Put code here to display this listing in the cart
                     * 
                     * this will repeat until all listings in the user's cart have
                     * been displayed
                     *
                     */




                    //While loops repeats until all listings in cart have been displayed
                }

                reader.Close();

                
            }
            else
            {
                //Show cart is empty if no items in cart
                emptyCart.Visible = true;
                cart.Visible = false;
            }
        }

    }
}
