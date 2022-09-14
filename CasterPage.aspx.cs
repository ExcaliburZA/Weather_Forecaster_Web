using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Resources;

namespace Weather_Forecaster_Web
{
    public partial class CasterPage : System.Web.UI.Page
    {
        SqlConnection dbConnection = new SqlConnection("Data Source = localhost; Initial Catalog = weather_forecaster; Integrated Security = True");
        List<Forecasts> theForecasts = new List<Forecasts>();
        string newLine = Environment.NewLine; string longLine = "---------------------------------";
        protected void Page_Load(object sender, EventArgs e)
        {
            generateForecastsList();
        }

        protected void btnView_Click(object sender, EventArgs e) //WORKING!!!
            //forecasts displayed according to user input
        {
            string city = txtCityView.Text.ToLower();
            DateTime startDate = DateTime.Parse(txtStartDate.Text); DateTime endDate = DateTime.Parse(txtEndDate.Text);
            //working
            List<Forecasts> toDisplay = new List<Forecasts>();

            for (int x = 0; x < theForecasts.Count(); ++x)
            {
                if (((theForecasts.ElementAt(x)).rangeCheck(startDate, endDate) == true) && (theForecasts.ElementAt(x).City).Equals(city) == true)
                {
                    if (toDisplay.Contains(theForecasts.ElementAt(x)) == false)
                    {
                        toDisplay.Add(theForecasts.ElementAt(x));
                    }
                }
            }

            txtOutput.Text = string.Empty;
            txtOutput.Text += longLine + newLine + "Forecasts Report for " + (city).ToUpper() + newLine + longLine + newLine;
            for (int y = 0; y < toDisplay.Count(); ++y)
            {
                txtOutput.Text += (toDisplay.ElementAt(y)).toStringNoCity();
                txtOutput.Text += newLine;
            }

        }

        public void generateForecastsList() //WORKING!!!!
            //all forecasts successfully read and displayed from local DB
        {
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

        protected void btnEdit_Click(object sender, EventArgs e) //WORKING
            //forecast updated successfully based on user criteria
        {
            SqlConnection editConnection = new SqlConnection("Data Source = localhost; Initial Catalog = weather_forecaster; Integrated Security = True");
            string city = txtCityEdit.Text.ToLower(); DateTime date = DateTime.Parse(txtDateEdit.Text);
            
            using (editConnection)
            {              
                SqlCommand editForecast = new SqlCommand("UPDATE FORECASTS SET MIN_TEMP = @min, MAX_TEMP = @max, PRECIP = @precip, HUMIDITY = @humidity, WSPEED = @wspeed WHERE ((CITY = @city) AND (FDATE = @date)) ", editConnection);
                using (editForecast)
                {
                    editConnection.Open();
                    editForecast.Parameters.AddWithValue("city", txtCityEdit.Text.ToLower());
                    editForecast.Parameters.AddWithValue("date", DateTime.Parse(txtDateEdit.Text));
                    editForecast.Parameters.AddWithValue("min", float.Parse(Interaction.InputBox("Please enter a minimum temperature value")));
                    editForecast.Parameters.AddWithValue("max", float.Parse(Interaction.InputBox("Please enter a maximum temperature value")));
                    editForecast.Parameters.AddWithValue("precip", float.Parse(Interaction.InputBox("Please enter a precipitation chance value")));
                    editForecast.Parameters.AddWithValue("humidity", float.Parse(Interaction.InputBox("Please enter a humidity value")));
                    editForecast.Parameters.AddWithValue("wspeed", float.Parse(Interaction.InputBox("Please enter the average wind speed")));
                    int rowsAffected = editForecast.ExecuteNonQuery();
                    if (rowsAffected <= 1)
                    {
                        MessageBox.Show("Rows affected: " + rowsAffected);
                    }
                    else
                    {
                        MessageBox.Show("Forecast not found!");
                    }
                }
            }
        }
    }
}