using CifkorTask.Model;
using UnityEngine;
using Zenject;

public class WeatherInit : MonoBehaviour, IInitializable
{
    [SerializeField] WeatherPresenter _weatherPresenter;
    [SerializeField] WeatherSettings _weatherSettings;

    public void Initialize()
    {
        var requestPool = new RequestPool(500);
        var weatherRequester = new WeatherRequester(requestPool, _weatherSettings.ApiUrl);
        var imageRequester = new ImageRequester(requestPool);
        var weatherData = new WeatherData(weatherRequester, imageRequester, _weatherSettings.RequestDelay);
        _weatherPresenter.Init(weatherData);
    }

    public void Awake()
    {
        Initialize();
    }
}
