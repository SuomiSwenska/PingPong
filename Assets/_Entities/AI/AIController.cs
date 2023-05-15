using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] private bool _isAIActive;
    [SerializeField] private float _moveSencitivity;
    [SerializeField] private float _quickReactionDistance;

    private InputController _inputController;
    private Rigidbody _rigidbody;
    private Ball _ball;
    private float _startZPosition;
    private float _nextXPosition;
    private float _sencitivityAffectFactor;

    private void Awake()
    {
        _inputController = GetComponent<InputController>();
        _rigidbody = GetComponent<Rigidbody>();
        _ball = FindObjectOfType<Ball>();
        _startZPosition = transform.position.z;
    }

    private void Start()
    {
        if (_isAIActive)
        {
            _inputController.enabled = false;
        }
    }

    private void LateUpdate()
    {
        if (_isAIActive)
        {
            ChangeSencitivityAffectFactor();

            _nextXPosition = Mathf.Lerp(transform.position.x, _ball.transform.position.x, Time.deltaTime * _moveSencitivity * _sencitivityAffectFactor);

            if (_nextXPosition >= _inputController.MovingLimits.y) _nextXPosition = _inputController.MovingLimits.y;
            else if (_nextXPosition <= _inputController.MovingLimits.x) _nextXPosition = _inputController.MovingLimits.x;

            _rigidbody.MovePosition(new Vector3(_nextXPosition, 0, _startZPosition));
        }
    }


    private void ChangeSencitivityAffectFactor()
    {
        if (Vector3.Distance(transform.position, _ball.transform.position) <= _quickReactionDistance) _sencitivityAffectFactor = 1;
        else _sencitivityAffectFactor = 0.05f;
    }
}
