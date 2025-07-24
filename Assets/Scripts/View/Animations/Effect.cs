using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Effect : SpawnableAnimation
{
    private ParticleSystem _particleSystem;
    private WaitForSeconds _wait;

    public event Action<Effect> Finished;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _wait = new WaitForSeconds(_particleSystem.main.duration);
    }

    private void OnEnable()
    {
        StartCoroutine(Playing());
    }

    private void OnDisable()
    {
        _particleSystem.Stop();
        _particleSystem.Clear();
    }

    private IEnumerator Playing()
    {
        _particleSystem.Play();
        yield return _wait;
        Finished?.Invoke(this);
    }
}
