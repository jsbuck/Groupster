﻿// Json Mapping Automatically Generated By JsonToolkit Library for C#
// Diego Trinciarelli 2011
// To use this code you will need to reference Newtonsoft's Json Parser, downloadable from codeplex.
// http://json.codeplex.com/
// 

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Groupster.Core
{
    public class OpenGroupForecast
    {
        [JsonProperty(PropertyName = "List")] 
        public List<DailyForecast> Forecasts;
    }

    public class Temperature
    {
        public double Day;
        public double Min;
        public double Max;
        public double Night;
        public double Eve;
        public double Morn;
    }

    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class DailyForecast
    {

        public int Dt;
        [JsonProperty(PropertyName = "Temp")]
        public Temperature Temperature;
        public double Pressure;
        public int Humidity;
        [JsonProperty(PropertyName = "Weather")]
        public List<Weather> WeatherList;
        public double Speed;
        public int Deg;
        public int Clouds;
        public double? Rain;
    }
}