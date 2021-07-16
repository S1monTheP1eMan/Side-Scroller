using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Fade _fade;
    [SerializeField] private int _slowMotionIterations;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void OnEnable()
    {
        _player.PlayerDying += OnPlayerDying;
    }

    private void OnDisable()
    {
        _player.PlayerDying -= OnPlayerDying;
    }

    private void OnPlayerDying()
    {
        StartCoroutine(SlowDownTime());
    }

    private IEnumerator SlowDownTime()
    {
        float time = Time.timeScale;
        float fixedDeltaTime = Time.fixedDeltaTime;

        for (int i = 0; i < _slowMotionIterations; i++)
        {
            if (i == _slowMotionIterations / 2)
            {
                _fade.PlayTransitionAnimation(0);
            }

            time = 1f - (1f / _slowMotionIterations * i);
            Time.timeScale = time;
            Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
            yield return null;
        }
    }
}
