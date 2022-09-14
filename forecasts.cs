using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Weather_Forecaster_Web
{
    public class Forecasts
    {
        //declaring attributes
        private String city;
        private DateTime date;
        private float minTemp;
        private float maxTemp;
        private int precipitation;
        private int humidity;
        private float windSpeed;


        //creating getters and setters
        public string City { get => city; set => city = value; }
        public DateTime Date { get => date; set => date = value; }
        public float MinTemp { get => minTemp; set => minTemp = value; }
        public float MaxTemp { get => maxTemp; set => maxTemp = value; }
        public int Humidity { get => humidity; set => humidity = value; }
        public float WindSpeed { get => windSpeed; set => windSpeed = value; }
        public int Precipitation { get => precipitation; set => precipitation = value; }

        //parameterised constructor for instantiating the class
        public Forecasts(string city, DateTime date, float minTemp, float maxTemp, int precipitation, int humidity, float windSpeed)
        {
            this.City = city;
            this.Date = date;
            this.MinTemp = minTemp;
            this.MaxTemp = maxTemp;
            this.Precipitation = precipitation;
            this.Humidity = humidity;
            this.WindSpeed = windSpeed;
        }

        public Forecasts()
        {

        }

        //method to test if the date of the specified Forecast object falls within a certain date range specified by the arguments being passed to the method
        public bool rangeCheck(DateTime startDate, DateTime endDate)
        {
            return ((date >= startDate) && (date <= endDate));
        }


        public bool dateCheckSingle(DateTime date)
        {
            bool isSelected = false;

            if (((this.date).Date) == date.Date)
            {
                isSelected = true;
            }

            return isSelected;
        }

        public bool cityCheckMulti(string[] cities)
        {
            int x = 0;
            bool isSelected = false, breakFlag = false;

            while ((cities[x] != null) && (breakFlag == false))
            {
                if (cities[x].Equals(this.city) == true)
                {
                    isSelected = true;
                    breakFlag = true;
                }
                ++x;
            }
            return isSelected;
        }

        public bool cityCheckSingle(string city)
        {
            bool isSelected = false;

            if ((this.city).Equals(city) == true)
            {
                isSelected = true;
            }

            return isSelected;
        }



        public string getCity()
        {
            return this.city;
        }

        public StringBuilder toString()
        {
            string newLine = Environment.NewLine;
            StringBuilder output = new StringBuilder(1000);

            output.Append("City:\t\t\t" + this.city + newLine);
            //output.Append("Date:\t\t\t"+this.date+ newLine);
            output.Append("Date:\t\t\t" + (this.date).ToShortDateString() + newLine);
            output.Append("Minimum temperature:\t" + this.minTemp + newLine);
            output.Append("Maximum temperature:\t" + this.maxTemp + newLine);
            output.Append("Humidity:\t\t\t" + this.humidity + newLine);
            output.Append("Wind speed:\t\t" + this.windSpeed + newLine);
            output.Append("Precipitation:\t\t" + this.precipitation + newLine);


            return output;
        }

        public StringBuilder toStringNoCity()
        {
            string newLine = Environment.NewLine;
            StringBuilder output = new StringBuilder(1000);

            //output.Append("Date:\t\t\t"+this.date+ newLine);
            output.Append("Date:\t\t\t" + (this.date).ToShortDateString() + newLine);
            output.Append("Minimum temperature:\t" + this.minTemp + newLine);
            output.Append("Maximum temperature:\t" + this.maxTemp + newLine);
            output.Append("Precipitation:\t\t" + this.precipitation + newLine);
            output.Append("Humidity:\t\t" + this.humidity + newLine);
            output.Append("Wind speed:\t\t" + this.windSpeed + newLine);            

            return output;
        }

        public void clearAllAttributes()
        {
            this.City = null;
            this.Date = DateTime.Now;
            this.MinTemp = 0;
            this.MaxTemp = 0;
            this.Precipitation = 0;
            this.Humidity = 0;
            this.WindSpeed = 0;
        }

    }
}