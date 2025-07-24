namespace CifkorTask.Model
{
    [System.Serializable]
    public class WeatherResponse
    {
        public WeatherProperties properties;
    }

    [System.Serializable]
    public class WeatherProperties
    {
        public ForecastPeriod[] periods;
    }

    [System.Serializable]
    public class ForecastPeriod
    {
        public int temperature;
        public string temperatureUnit;
        public string icon;
    }
}
