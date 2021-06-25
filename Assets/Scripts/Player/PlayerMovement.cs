using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _jumpDuration;

    private Vector3 _velocity;
    private Rigidbody _rigidbody;
    private bool _isGrounded;
    private bool _isReadyToJump;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _isReadyToJump = true;
        }
    }

    private void FixedUpdate()
    {
        _velocity = new Vector3(_speed, 0, 0);
        _rigidbody.position += _velocity * Time.fixedDeltaTime;

        if (_isReadyToJump)
        {
            StartCoroutine(Jump());

            _isReadyToJump = false;
            _isGrounded = false;
        }
    }

    private IEnumerator Jump()
    {
        var waitForPhysicsUpdate = new WaitForFixedUpdate();
        var jumpForce = _jumpForce;

        for (int i = 0; i < _jumpDuration; i++)
        {
            jumpForce = jumpForce - (jumpForce / _jumpDuration * i);
            _rigidbody.position += new Vector3(0, jumpForce * Time.fixedDeltaTime);

            yield return waitForPhysicsUpdate;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Ground ground))
        {
            _isGrounded = true;
        }
    }
}
