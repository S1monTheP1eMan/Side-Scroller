using System.Collections;
using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Fade _fade;
    [SerializeField] private float _fadeOutTime;

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
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(_fadeOutTime);

        _fade.PlayTransitionAnimation(0);
    }
}
