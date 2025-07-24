public class EffectSpawner : AnimationSpawner<Effect>
{
    protected override void OnActionGet(Effect effect)
    {
        effect.gameObject.SetActive(true);
        effect.Finished += Release;
    }

    protected override void OnActionRelease(Effect effect)
    {
        effect.Finished -= Release;
        effect.gameObject.SetActive(false);
    }
}
