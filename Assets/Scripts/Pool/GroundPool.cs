using UnityEngine;

public class GroundPool : ObjectPool
{
    [SerializeField] private Ground _template;

    private void Awake()
    {
        Initialize(_template.gameObject);
    }
}
