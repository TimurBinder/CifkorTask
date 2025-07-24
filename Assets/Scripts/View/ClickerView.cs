using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ClickerView : MonoBehaviour
{
    [SerializeField] EffectSpawner _effectSpawner;
    [SerializeField] DigitSpawner _digitSpawner;
    [SerializeField] AudioSource _audioSource;

    public void Init()
    {
        enabled = true;
    }

    public void OnClick()
    {
        _effectSpawner.Get(transform.position);
        _digitSpawner.Get(transform.position);
        _audioSource.Play();
    }

    private void OnValidate() =>
        enabled = false;
}
