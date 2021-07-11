using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GroundPool _ground;
    [SerializeField] private ObstaclePool _obstacles;
    [SerializeField] private CoinPool _coins;

    [SerializeField] private Transform _player;
    [SerializeField] private int _width;
    [SerializeField] private int _length;
    [SerializeField] private float _generationPauseTime;

    private float _elapsedTime;
    private int _gridSpacingOffset = 1;
    private int _generationStart = 0;
    private int _currentLength;

    private List<GameObject> _placedObjects = new List<GameObject>();

    private void Start()
    {
        _currentLength = _length * 2;

        SpawnObjects();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _generationPauseTime)
        {
            SpawnObjects();

            _elapsedTime = 0;
        }
    }

    private void SpawnObjects()
    {
        StartCoroutine(TrySpawnObjects());
    }

    private IEnumerator TrySpawnObjects()
    {
        for (int x = _generationStart; x < _currentLength; x++)
        {
            for (int z = -_width; z < _width; z++)
            {
                TryCreateGround(_ground, x, z);
                TryCreateObjectOnGround(_obstacles, _coins, x, z, _gridSpacingOffset);
            }

            yield return new WaitForFixedUpdate();
        }

        _generationStart = _currentLength;
        _currentLength += _length;
    }

    private void TryCreateGround(GroundPool pool, int x, int z)
    {
        GameObject prefab = pool.TryGetObject();

        if (prefab == null)
            return;

        prefab.SetActive(true);
        prefab.transform.position = new Vector3(x * _gridSpacingOffset, 0, z * _gridSpacingOffset);
        _placedObjects.Add(prefab);
    }

    private void TryCreateObjectOnGround(ObstaclePool obstacles, CoinPool coins, int x, int z, int verticalOffset)
    {
        GameObject obstacle = obstacles.TryGetObject();

        if (obstacle != null)
        {
            obstacle.SetActive(true);
            obstacle.transform.position = new Vector3(x * _gridSpacingOffset, verticalOffset, z * _gridSpacingOffset);
            _placedObjects.Add(obstacle);

            return;
        }

        GameObject coin = coins.TryGetObject();

        if (coin != null)
        {
            coin.SetActive(true);
            coin.transform.position = new Vector3(x * _gridSpacingOffset, verticalOffset, z * _gridSpacingOffset);
            _placedObjects.Add(coin);
        }
    }
}
