// --------------------------------------------------------------------------------------
// <copyright file="WeatherInfo.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 - 2023 André Krämer https://www.andrekraemer.de - 
//      GPL3 License (see license.txt)
// </copyright>
// <summary>
//  Memory Leak Demo Projekt
// </summary>
// --------------------------------------------------------------------------------------

namespace Ak.MemoryLeakDemo.Models
{
    public class WeatherInfo
    {
        public City City { get; set; }

        public Temperature Temperature { get; set; }


        public Humidity Humidity { get; set; }

        public Pressure Pressure { get; set; }

        public Wind Wind { get; set; }

        public Clouds Clouds { get; set; }

        public object Visibility { get; set; }

        public Precipitation Precipitation { get; set; }


        public Weather Weather { get; set; }


        public Lastupdate Lastupdate { get; set; }


        public object Head { get; set; }
    }
}