using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private float _moveSencitivity;
    [SerializeField] private Vector2 movingLimits;
    private Rigidbody _rigidbody;
    private float _defZPosition;

    public Vector2 MovingLimits { get => movingLimits; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _defZPosition = transform.position.z;
    }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.A))
        {
            if (_rigidbody.transform.position.x <= movingLimits.x) return;
            _rigidbody.MovePosition(transform.position - new Vector3(1 * _moveSencitivity, 0, 0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (_rigidbody.transform.position.x > movingLimits.y) return;
            _rigidbody.MovePosition(transform.position + new Vector3(1 * _moveSencitivity, 0, 0));
        }
#endif

#if !UNITY_EDITOR
if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 worldTouchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            worldTouchPosition.z = _defZPosition;
            worldTouchPosition.y = 0;
            _rigidbody.MovePosition(worldTouchPosition);
        }
#endif
    }
}
