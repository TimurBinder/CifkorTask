using CifkorTask.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeatherPresenter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _icon;

    private WeatherData _data;

    public void Init(WeatherData data)
    {
        _data = data;
        _data.Updated += Change;
        enabled = true;
    }

    public void Change() 
    {
        _text.text = $"Сегодня - {_data.Temperature}{_data.TemperatureUnit}";
        _icon.sprite = _data.Icon;
    }

    private void OnValidate() =>
        enabled = false;

    private void Update() =>
        _data.Tick();
}
