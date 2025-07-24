using System;
using UnityEngine;
using UnityEngine.Networking;

namespace CifkorTask.Model
{
    public class WeatherRequester : Requester
    {
        private string _url;

        public event Action<ForecastPeriod> ResponseReceived;

        public WeatherRequester(RequestPool requestPool, string url) : base(requestPool)
        {
            _url = url;
        }

        public void AddRequest() => base.AddRequest(_url);

        protected override void OnCompleteResponse(UnityWebRequest request)
        {
            WeatherResponse response = JsonUtility.FromJson<WeatherResponse>(request.downloadHandler.text);

            if (response == null || response.Properties == null || response.Properties.Periods.Length == 0)
            {
                Debug.LogError("Invalid weather data format");
                return;
            }

            ForecastPeriod today = response.Properties.Periods[0];
            ResponseReceived?.Invoke(today);
        }

        protected override void OnFailedResponse(UnityWebRequest request)
        {
            Debug.LogError($"Error: {request.error}");
            Debug.LogError($"Response: {request.downloadHandler.text}");
        }
    }
}