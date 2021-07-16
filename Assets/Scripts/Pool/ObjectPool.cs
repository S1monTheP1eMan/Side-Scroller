using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _prefabs = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);
            _prefabs.Add(spawned);
        }
    }

    private bool TryCheckObject(out GameObject result)
    {
        result = _prefabs.FirstOrDefault(predicate => predicate.activeSelf == false);
        return result != null;
    }

    public GameObject TryGetObject()
    {
        if (TryCheckObject(out GameObject result) && result.GetComponent<EnvironmentObject>().Chance >= Random.Range(0, 100))
            return result;
        else
            return null;
    }
}
