using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class IndicatePresenter<T> : MonoBehaviour where T : IChangeable
{
    [SerializeField] protected TextMeshProUGUI _text;

    protected T _model;

    public virtual void Init(T model)
    {
        _model = model;
        enabled = true;
    }

    private void OnValidate()
    {
        enabled = false;
    }

    private void OnEnable()
    {
        _model.Changed += Change;
    }

    private void OnDisable()
    {
        _model.Changed -= Change;
    }

    protected abstract void Change();
}
