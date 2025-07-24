using System;
using UnityEngine;
using Zenject;

namespace CifkorTask.Model
{
    public class WeatherData : ITickable
    {
        private WeatherRequester _requester;
        private float _requestDelay;
        private float _requestTimer;
        private ImageRequester _imageRequester;

        public event Action Updated;

        public WeatherData(
            WeatherRequester requester, 
            ImageRequester imageRequester, 
            float requestDelay
        )
        {
            _requester = requester;
            _imageRequester = imageRequester;
            _requester.ResponseReceived += Update;
            _requestDelay = requestDelay;
            _requestTimer = 0;
            _requester.AddRequest();
        }

        ~WeatherData()
        {
            _requester.ResponseReceived -= Update;
        }

        public Sprite Icon { get; private set; }
        public int Temperature { get; private set; }
        public string TemperatureUnit { get; private set; }

        public void Tick()
        {
            _requestTimer += Time.deltaTime;

            if (_requestTimer >= _requestDelay)
            {
                _requester.AddRequest();
                _requestTimer = 0;
            }
        }

        private void Update(ForecastPeriod forecastPeriod)
        {
            Temperature = forecastPeriod.Temperature;
            TemperatureUnit = forecastPeriod.TemperatureUnit;
            _imageRequester.AddRequest(forecastPeriod.Icon);
            _imageRequester.ImageLoaded += LoadIcon;
        }

        private void LoadIcon(Sprite sprite)
        {
            _imageRequester.ImageLoaded -= LoadIcon;
            Icon = sprite;
            Updated?.Invoke();
        }
    }
}
