using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothSpeed;
    [SerializeField] private Vector3 ofset;

    private Vector3 _targetPosition;
    private Vector3 _nextPosition;

    private void FixedUpdate()
    {
        _targetPosition = _target.position + ofset;
        _nextPosition = Vector3.Lerp(transform.position, _targetPosition, _smoothSpeed);
        transform.position = _nextPosition;
    }
}
