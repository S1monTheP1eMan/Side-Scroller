using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Coin : EnvironmentObject
{
    [SerializeField] private float _minAnimationSpeed;
    [SerializeField] private float _maxAnimationSpeed;
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        ApplyRandomAnimationSpeed();
    }

    private void ApplyRandomAnimationSpeed()
    {
        float randomPlaybackSpeed = Random.Range(_minAnimationSpeed, _maxAnimationSpeed);

        _animator.speed = randomPlaybackSpeed;
    }
}
