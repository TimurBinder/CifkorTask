using Cysharp.Threading.Tasks;
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

        public async UniTaskVoid AddRequest() => base.AddRequest(_url);

        protected override void OnCompleteResponse(UnityWebRequest request)
        {
            try
            {
                WeatherResponse response = JsonUtility.FromJson<WeatherResponse>(request.downloadHandler.text);

                if (response == null || response.properties == null || response.properties.periods.Length == 0)
                    throw new ArgumentNullException(nameof(response));

                ForecastPeriod today = response.properties.periods[0];
                ResponseReceived?.Invoke(today);
            } 
            catch(Exception exception)
            {
                Debug.LogError(exception.Message);
            }
        }

        protected override void OnFailedResponse(UnityWebRequest request)
        {
            Debug.LogError($"Error: {request.error}");
            Debug.LogError($"Response: {request.downloadHandler.text}");
        }
    }
}