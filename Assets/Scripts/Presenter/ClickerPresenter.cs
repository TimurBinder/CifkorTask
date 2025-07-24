using CifkorTask.Model;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClickerPresenter : MonoBehaviour
{
    private Clicker _model;
    private ClickerView _view;
    private Button _button;
    private Autoclicker _autoclicker;

    public void Init(Clicker model, ClickerView view, Autoclicker autoclicker = null)
    {
        _model = model;
        _view = view;
        _button = GetComponent<Button>();
        _autoclicker = autoclicker;
        enabled = true;
    }

    private void OnValidate() =>
        enabled = false;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
        _model.Clicked += _view.OnClick;
    }

    private void Update() =>
        _autoclicker?.Tick();

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
        _model.Clicked += _view.OnClick;
    }

    private void OnClick()
    {
        _model.TryClick();
    }
}
