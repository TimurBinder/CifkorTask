using CifkorTask.Model;
using Unity.VisualScripting;
using UnityEngine;

public class ClickerInit : MonoBehaviour, IInitializable
{
    [SerializeField] private ClickerPresenter _clickerPresenter;
    [SerializeField] private ClickerView _view;
    [SerializeField] private ScorePresenter _scorePresenter;
    [SerializeField] private EnergyPresenter _energyPresenter;
    [SerializeField] private ClickerSettings _settings;

    public void Initialize()
    {
        var score = new Score(_settings.StartScore);
        var energy = new Energy(_settings.MaxEnergy, _settings.MaxEnergy);
        var energyAccumulatable = new EnergyAccumulatable(energy, _settings.AccumulatableEnergy, _settings.AccumulateEnergyDelay);
        var clicker = new Clicker(score, energy, _settings.Reward, _settings.ExpendableEnergy);
        var autoclicker = new Autoclicker(clicker, _settings.AutoclickDelay);
        _view.Init();
        _clickerPresenter.Init(clicker, _view, autoclicker);
        _scorePresenter.Init(score);
        _energyPresenter.Init(energy, energyAccumulatable);
    }

    private void Awake()
    {
        Initialize();
    }
}
