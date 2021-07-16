using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _score;

    public int Score => _score;
    public event UnityAction<int> ScoreChanged;
    public event UnityAction PlayerDying;

    private void Awake()
    {
        Time.fixedDeltaTime = 1f / Screen.currentResolution.refreshRate;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Coin>(out Coin coin))
        {
            _score++;
            ScoreChanged?.Invoke(_score);

            other.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Obstacle>(out Obstacle obstacle))
        {
            PlayerDying?.Invoke();
        }
    }
}
