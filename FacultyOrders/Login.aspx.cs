﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace FacultyOrders
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_Login_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection_String"].ConnectionString);
            
            connection.Open();
            
            string checkUser = "SELECT COUNT(*) FROM Users where Username ='" + txtUser.Text.ToString() + "'";
            SqlCommand com = new SqlCommand(checkUser, connection);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            connection.Close();

            //Used to check what the password is for the username that was slected. 
            if (temp == 1)
            {
                Encryption crypto = new Encryption();

                string password = dbQuery("SELECT Password FROM Users WHERE Username = '" + txtUser.Text.ToString() + "'");

                if (crypto.Decrypt(password) == txtPass.Text.ToString())
                {
                    Session["User"] = txtUser.Text.ToString();
                    Session["Role"] = dbQuery("SELECT Role FROM Users WHERE Username = '" + Session["User"].ToString() + "'");
                    Response.Write("Password is correct");
                    
                    //Response.Redirect("Accounting.aspx"); 
                    /*
                     * See if role is Accountant/PurchaserComp/PurchaserOther and redirect to relevant view
                     */
                }
                else
                {
                    Response.Write("Password is not correct");
                }
            }
            else
            {
                Response.Write("Please provid a valid Username");
            }

        }

        protected String dbQuery(String qS)
        {
            object result = "";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection_String"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Parameters.Clear();
                    try
                    {
                        command.CommandText = qS;
                        command.Connection = connection;
                        command.Connection.Open();

                        result = command.ExecuteScalar();

                        command.Connection.Close();

                    }
                    catch
                    {
                        command.Connection.Close();
                    }
                }
            }
            if (result == null)
                return "";
            else
                return result.ToString();
        }

        protected void nonQuery(String qS)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection_String"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Parameters.Clear();
                    try
                    {
                        command.CommandText = qS;
                        command.Connection = connection;
                        command.Connection.Open();

                        command.ExecuteNonQuery();

                        command.Connection.Close();

                    }
                    catch
                    {
                        command.Connection.Close();
                    }
                }
            }
        }
    }
}