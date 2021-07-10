using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : ObjectPool
{
    [SerializeField] private Coin _template;

    private void Awake()
    {
        Initialize(_template.gameObject);
    }
}
