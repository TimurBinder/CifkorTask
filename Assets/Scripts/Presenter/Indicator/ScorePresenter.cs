using CifkorTask.Model;

public class ScorePresenter : IndicatePresenter<Score>
{
    protected override void Change() =>
        _text.text = _model.Value.ToString();
}
