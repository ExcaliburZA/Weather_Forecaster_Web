using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;
using System.Web.Services.Description;
using System.Threading;
using System.Web.SessionState;
using System.EnterpriseServices;

namespace Weather_Forecaster_Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnUserLogin_Click(object sender, EventArgs e)
        {
            string username, password;
            bool valid = false;
            SqlConnection userConnection = new SqlConnection("Data Source = localhost; Initial Catalog = weather_forecaster; Integrated Security = True");
            string userUsername = txtUsername.Text.Trim(); string userPassword = txtPassword.Text.Trim();

            using (userConnection)
            {
                using (SqlCommand testCommand = new SqlCommand("SELECT U_ID, USERNAME, PASS FROM USERS", userConnection))
                {
                    userConnection.Open();
                    using (SqlDataReader userReader = testCommand.ExecuteReader())
                    {
                        while ((userReader.Read()) && (valid == false))
                        {
                            username = (userReader[1].ToString()).Trim();
                            password = (userReader[2].ToString()).Trim();

                            if (userValid(username, password, userUsername, userPassword) == true)
                            {
                                MessageBox.Show("Login verified, redirecting...");
                                sessionVariables(username, password);
                                Response.Redirect("User.aspx");
                                valid = true;
                            }
                        }
                    }
                }
            }
            if (valid == false)
            {
                MessageBox.Show("User not found!");
            }
        }

        protected void btnCasterLogin_Click(object sender, EventArgs e)
        {
            string username, password;
            bool valid = false;
            SqlConnection casterConnection = new SqlConnection("Data Source = localhost; Initial Catalog = weather_forecaster; Integrated Security = True");
            string userUsername = txtUsername.Text.Trim(); string userPassword = txtPassword.Text.Trim();

            using (casterConnection)
            {
                using (SqlCommand testCommand = new SqlCommand("SELECT C_ID, USERNAME, PASS FROM CASTERS", casterConnection))
                {
                    casterConnection.Open();
                    using (SqlDataReader userReader = testCommand.ExecuteReader())
                    {
                        while ((userReader.Read()) && (valid == false))
                        {
                            username = (userReader[1].ToString()).Trim();
                            password = (userReader[2].ToString()).Trim();
                            
                            if (userValid(username, password, userUsername, userPassword) == true)
                            {
                                MessageBox.Show("Login verified, redirecting...");
                                sessionVariables(username, password);
                                Response.Redirect("CasterPage.aspx");
                                valid = true; 
                            }                           
                        }
                    }
                }
            }
            if (valid == false)
            {
                MessageBox.Show("User not found!");
            }
        }

        public static bool userValid(string dbUsername, string dbPassword, string username, string password)
        {
            bool found = false;

            if((username.Equals(dbUsername) == true) && (password.Equals(dbPassword) == true))
            {
                found = true;
            }

            return found;
        }

        public static void sessionVariables(string username, string password)
        {
            HttpContext.Current.Session["username"] = username;
            HttpContext.Current.Session["password"] = password;
        }
    }
}