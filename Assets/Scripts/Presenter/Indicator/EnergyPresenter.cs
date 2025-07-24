using CifkorTask.Model;

public class EnergyPresenter : IndicatePresenter<Energy>
{
    private EnergyAccumulatable _accumulatable;

    public void Init(Energy energy, EnergyAccumulatable accumulatable)
    {
        base.Init(energy);
        _accumulatable = accumulatable;
        Change();
    }

    private void Update() =>
        _accumulatable.Tick();

    protected override void Change() =>
        _text.text = $"{_model.Value}/{_model.MaxValue}";
}
