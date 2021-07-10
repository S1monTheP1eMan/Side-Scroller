using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : ObjectPool
{
    [SerializeField] private Obstacle _template;

    private void Awake()
    {
        Initialize(_template.gameObject);
    }
}
