using UnityEngine;

[CreateAssetMenu(fileName = "WeatherSettings", menuName = "Settings/Weather")]
public class WeatherSettings : ScriptableObject
{
    [field: SerializeField] public string ApiUrl = "https://api.weather.gov/gridpoints/TOP/32,81/forecast";
    [field: SerializeField] public float RequestDelay = 5.0f;
}
