using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;
using System.Xml.Serialization;
namespace OnlineClothingStore
{
    

    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }

    public DataSet getDelivery()
    {
        SqlConnection conn = new SqlConnection();
        StringBuilder sql = new StringBuilder();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet deliveryData = new Dataset();

        conn = dbConn.getConnection();
        deliveryData = new DataSet();
        sql = new StringBuilder();
        sql.AppendLine("SELECT * FROM DeliveryRec");

        conn.Open();
        da = new SqlDataAdapter(sql.ToString(), conn);
        da.Fill(deliveryData);

        return deliveryData;
    }
}