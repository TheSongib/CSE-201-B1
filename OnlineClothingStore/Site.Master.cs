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
    public partial class SiteMaster : MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Show create account page if no user is logged in, else show users name as button
            if (Session["email"] == null)
            {
                submissions.Visible = false;
                account.InnerHtml = "Create Account/Login";

            }
            else
            {
                account.InnerHtml = (string) Session["firstName"];
                account.HRef = "~/AccountInfo";
                if ((bool)Session["admin"])
                {
                    submissions.Visible = true;
                    submissions.HRef = "~/Submissions";
                }
                else
                {
                    submissions.Visible = false;
                }
            }
        }
    }
}