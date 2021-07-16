using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Coin : MonoBehaviour
{
    [SerializeField] private float _minAnimationSpeed;
    [SerializeField] private float _maxAnimationSpeed;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        SetRandomAnimationSpeed();
    }

    private void SetRandomAnimationSpeed()
    {
        float randomPlaybackSpeed = Random.Range(_minAnimationSpeed, _maxAnimationSpeed);

        _animator.speed = randomPlaybackSpeed;
    }
}
