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
    public partial class Buy : Page
    {
        //sql database connection
        SqlConnection con;
        //Here we declare the parameter which we have to use in our application  
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Create connection to stored procedure for listings and execute
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            cmd = new SqlCommand("spGetListings", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            //Read data
            SqlDataReader reader = cmd.ExecuteReader();

            //read data
            while (reader.Read())
            {
                //these will be the elements of items in card
                int listingId;
                string title;
                string author;
                int price;
                string category;
                string description = "";

                //These are the filepaths to set as the image source(s) whe displaying images
                // also note that they may have up to 5, but possibly less.
                string img1Src = "";
                string img2Src = "";
                string img3Src = "";
                string img4Src = "";
                string img5Src = "";

                //input listing data into variables
                listingId = (int)reader[0];
                title = reader[1].ToString();
                author = (string)reader[2] + " " + reader[3];
                price = (int)reader[4];
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

                //Create objects to add to html
                LiteralControl beginningHtml = new LiteralControl();
                LiteralControl endHtml = new LiteralControl();
                Button remove = new Button();
                remove.ID = listingId.ToString();
                remove.Text = "Add to Cart";
                remove.Attributes.Add("class", "btn btn-primary btn-sm");
                remove.Attributes.Add("runat", "server");
                remove.Click += new EventHandler(this.Cart_Add);

                //shorten title if need be
                if(title.Length > 11)
                {
                    title = title.Substring(0,9) + "...";
                }

                //make html
                beginningHtml.Text += "<div class='jumbotron' style='float:left;width:19%;margin-right:5px;'>";
                beginningHtml.Text += "<div style='display:block;'>";
                if (img1Src != "")
                {
                    beginningHtml.Text += "<img src=" + '"' + img1Src + '"' + "style=" + '"' + "height:50px;" + '"' + "/><br>";
                }
                else
                {
                    beginningHtml.Text += "<img src='Content\\Images\\deafult.png' style=" + '"' + "height:50px;" + '"' + "/><br>";
                }
                beginningHtml.Text += "<h3>" + title + "</h3>";
                beginningHtml.Text += "<h4 style='padding-top:20px;'> Price: " + price + "</h4>";

                
                //add button and ending html
                content.Controls.Add(beginningHtml);
                content.Controls.Add(remove);
                endHtml.Text = "</div></div>";
                content.Controls.Add(endHtml);

                //While loops repeats until all listings in cart have been displayed
            }

            reader.Close();


        }
        protected void Cart_Add(object sender, EventArgs e)
        {
            if (Session["userId"] == null)
            {
                Response.Redirect("CreateAccount.aspx");
            }
            else
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
                cmd = new SqlCommand("spAddRemoveCart", con);
                cmd.Parameters.Add("@userId", SqlDbType.VarChar).Value = Session["userId"];
                cmd.Parameters.Add("@listingId", SqlDbType.VarChar).Value = (sender as Button).ID;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.ExecuteNonQuery();
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}