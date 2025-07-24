using UnityEngine;

public class DigitSpawner : AnimationSpawner<Digit>
{
    [SerializeField] private float _maxOffsetLeft = 1f;
    [SerializeField] private float _maxOffsetRight = 1f;

    public override Digit Get(Vector3 position)
    {
        position.x += Random.Range(-_maxOffsetLeft, _maxOffsetRight);
        return base.Get(position);
    }

    protected override void OnActionGet(Digit digit)
    {
        digit.gameObject.SetActive(true);
        digit.Finished += Release;
    }

    protected override void OnActionRelease(Digit digit)
    {
        digit.Finished -= Release;
        digit.gameObject.SetActive(false);
    }
}
