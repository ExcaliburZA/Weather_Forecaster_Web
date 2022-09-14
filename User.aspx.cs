using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Weather_Forecaster_Web
{
    public partial class User : System.Web.UI.Page
    {
        
        List<Forecasts> theForecasts = new List<Forecasts>();
        List<string> userCities = new List<string>();
        string newLine = Environment.NewLine; string longLine = "---------------------------------";
        protected void Page_Load(object sender, EventArgs e) 
        {
            generateForecastsList();
            getUserCities();
            if (!IsPostBack)
            {
            populateDropdownList();
                ddlUserCities.SelectedIndex = 0;
            }
                
            
        }

        public void populateDropdownList() //WORKING!!
        {
            if (userCities.Count() > 0)
            {
                ddlUserCities.Items.Clear();
            }

            for (int x = 0;  x < userCities.Count(); ++x)
            {
                ddlUserCities.Items.Add(userCities.ElementAt(x));
            }
        }

        public void getUserCities() //WORKING!!
            //all user cities successfully retrieved and added to the dropdownlist
        {
            string userID;
            SqlConnection dbConnection = new SqlConnection("Data Source = localhost; Initial Catalog = weather_forecaster; Integrated Security = True");

            using (dbConnection)
            {
                
                SqlCommand retrieveID = new SqlCommand("SELECT U.U_ID FROM USERS U WHERE (U.USERNAME = @username)", dbConnection);
                using (retrieveID)
                {
                retrieveID.Parameters.AddWithValue("username", Session["username"]);
                dbConnection.Open();
                    
                    using (SqlDataReader idReader = retrieveID.ExecuteReader())
                    {
                        while (idReader.Read())
                        {
                            userID = idReader[0].ToString();
                            HttpContext.Current.Session["userid"] = userID;
                        }
                    }
                    dbConnection.Close();
                }                
                SqlCommand retrieveCities = new SqlCommand("SELECT CITY FROM USER_CITIES WHERE (U_ID = @userid)", dbConnection);
                using (retrieveCities)
                {
                    dbConnection.Open();
                    retrieveCities.Parameters.AddWithValue("userid", Session["userid"]);
                    using (SqlDataReader citiesReader = retrieveCities.ExecuteReader())
                    {
                        while (citiesReader.Read())
                        {
                            userCities.Add(citiesReader[0].ToString());
                            //MessageBox.Show(userCities.Last());
                        }
                    }
                } 
            }               
        }

        public void generateForecastsList() //WORKING!!!!
        //all forecasts successfully read and displayed from local DB
        {
            SqlConnection dbConnection = new SqlConnection("Data Source = localhost; Initial Catalog = weather_forecaster; Integrated Security = True");
            using (dbConnection)
            {
                using (SqlCommand viewForecasts = new SqlCommand("SELECT CITY, FDATE, MIN_TEMP, MAX_TEMP, PRECIP, HUMIDITY, WSPEED FROM FORECASTS", dbConnection))
                {
                    dbConnection.Open();
                    using (SqlDataReader forecastsReader = viewForecasts.ExecuteReader())
                    {
                        while (forecastsReader.Read())
                        {
                            Forecasts theForecast = new Forecasts();
                            theForecast.City = forecastsReader[0].ToString().ToLower();
                            theForecast.Date = DateTime.Parse(forecastsReader[1].ToString());
                            theForecast.MinTemp = float.Parse(forecastsReader[2].ToString());
                            theForecast.MaxTemp = float.Parse(forecastsReader[3].ToString());
                            theForecast.Precipitation = Int32.Parse(forecastsReader[4].ToString());
                            theForecast.Humidity = Int32.Parse(forecastsReader[5].ToString());
                            theForecast.WindSpeed = float.Parse(forecastsReader[6].ToString());
                            theForecasts.Add(theForecast);
                        }
                    }
                }
            }
        }

        protected void btnViewForecasts_Click(object sender, EventArgs e) //WORKING!
        {
            string city = ddlUserCities.SelectedValue.Trim().ToLower();
            
            txtOutput.Text = string.Empty; int z = 0; int y = 0;
            List<Forecasts> toDisplay = new List<Forecasts>();         

            while (z < theForecasts.Count())
            {
                if ((theForecasts.ElementAt(z).City.ToLower().Trim()).Equals(city) == true)
                {
                    toDisplay.Add(theForecasts.ElementAt(z));
                }                   
                ++z;
            }

            
            if (toDisplay.Count() > 0)
            {
                txtOutput.Text += "Forecasts for " + city.ToUpper() + newLine;
                while (y < toDisplay.Count())
                {
                txtOutput.Text += longLine + newLine;
                txtOutput.Text += (toDisplay.ElementAt(y)).toStringNoCity();
                txtOutput.Text += longLine;
                ++y;
                }   
            }
            else
            {
                MessageBox.Show("No forecasts for selected city!");
            }           
                    
        }

        protected void ddlUserCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        protected void btnAddCity_Click(object sender, EventArgs e) //WORKING!!
        {
            SqlConnection dbConnection = new SqlConnection("Data Source = localhost; Initial Catalog = weather_forecaster; Integrated Security = True");
           List<string> userCityIDs = new List<string>();
            HttpContext.Current.Session["userid"] = string.Empty;
            using (dbConnection)
            {
                dbConnection.Open();
                SqlCommand getIDList = new SqlCommand("SELECT UC.ID FROM USER_CITIES UC, USERS U WHERE ((UC.U_ID = U.U_ID) AND (U.USERNAME = @username))", dbConnection);              
                using (getIDList)
                {
                    getIDList.Parameters.AddWithValue("username", Session["username"]);
                    SqlDataReader reader = getIDList.ExecuteReader();
                    while (reader.Read())
                    {
                        userCityIDs.Add(reader[0].ToString());
                    }
                    reader.Close();
                }

                int theNextID = Int32.Parse(userCityIDs.Last()) + 1;

                
                SqlCommand getUserID = new SqlCommand("SELECT U_ID FROM USERS WHERE (USERNAME = @username)", dbConnection);
                using (getUserID)
                {
                    getUserID.Parameters.AddWithValue("username", Session["username"]);
                    SqlDataReader userIDReader = getUserID.ExecuteReader();
                    while (userIDReader.Read())
                    {
                        Session["userid"] = userIDReader[0].ToString();
                    }
                    userIDReader.Close();
                }

                SqlCommand addCity = new SqlCommand("INSERT INTO USER_CITIES(ID, U_ID, CITY) VALUES(@id, @userid, @city)", dbConnection);
                using (addCity)
                {
                    addCity.Parameters.AddWithValue("id", theNextID.ToString());
                    addCity.Parameters.AddWithValue("userid", Session["userid"]);
                    addCity.Parameters.AddWithValue("city", txtCity.Text.Trim());
                    MessageBox.Show(txtCity.Text.Trim() + " has been added!\nRows affected: "+addCity.ExecuteNonQuery());
                }
            }
            dbConnection.Close();
        }

        protected void btnRemoveCity_Click(object sender, EventArgs e) //WORKING!!
        {
            SqlConnection dbConnection = new SqlConnection("Data Source = localhost; Initial Catalog = weather_forecaster; Integrated Security = True");
            using (dbConnection)
            {
                dbConnection.Open();
                SqlCommand removeCity = new SqlCommand("DELETE FROM USER_CITIES WHERE ((U_ID = @userid) AND (CITY = @city))", dbConnection);
                using (removeCity)
                {
                    removeCity.Parameters.AddWithValue("userid", Session["userid"]);
                    removeCity.Parameters.AddWithValue("city", txtCity.Text.Trim());
                    MessageBox.Show(txtCity.Text.Trim() + " has been removed!\nRows affected: " + removeCity.ExecuteNonQuery());
                }
            }
            dbConnection.Close();
        }
    }
}