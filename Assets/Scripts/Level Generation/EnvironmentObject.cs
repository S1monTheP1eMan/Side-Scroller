using UnityEngine;

public class EnvironmentObject : MonoBehaviour
{
    [SerializeField] private int _chance;

    public int Chance => _chance;

    private float _lifeTime = 10f;
    private float _elapsedTime;

    private void OnValidate()
    {
        _chance = Mathf.Clamp(_chance, 1, 100);
    }

    private void OnEnable()
    {
        _elapsedTime = 0;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _lifeTime)
            gameObject.SetActive(false);
    }
}
