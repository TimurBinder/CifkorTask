using UnityEngine;

namespace CifkorTask.Model
{
    [System.Serializable]
    public class WeatherResponse
    {
        public WeatherProperties Properties { get; private set; }
    }

    [System.Serializable]
    public class WeatherProperties
    {
        public ForecastPeriod[] Periods { get; private set; }
    }

    [System.Serializable]
    public class ForecastPeriod
    {
        public int Temperature { get; private set; }
        public string TemperatureUnit { get; private set; }
        public string Icon { get; private set; }
    }
}
