using DG.Tweening;
using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Digit : SpawnableAnimation
{
    [SerializeField] private float _moveDuration = 1.0f;
    [SerializeField] private float _moveDistance = 1.0f;
    [SerializeField] private float _fadeDuration = 1.5f;
    [SerializeField] private float _minAlpha = 0f;
    [SerializeField] private float _maxAlpha = 1f;

    private TextMeshProUGUI _text;
    public event Action<Digit> Finished;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _text.alpha = _maxAlpha;
        var animation = DOTween.Sequence();

        animation
            .Append(transform.DOMoveY(_moveDistance, _moveDuration))
            .Join(_text.DOFade(_minAlpha, _fadeDuration))
            .OnComplete(() => Finished?.Invoke(this));
    }
}
