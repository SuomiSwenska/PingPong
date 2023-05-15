using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _firstAccelerationForce;
    private Rigidbody _ballRigidbody;
    private Vector3 _startPosition;

    private void Awake()
    {
        _ballRigidbody = GetComponent<Rigidbody>();
        _startPosition = transform.position;
    }

    private void Start()
    {
        StartCoroutine(FirstAccelerationCoroutine(2f));
    }

    private IEnumerator FirstAccelerationCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        bool isUpward = (Random.Range(0, 101) <= 50);
        float signDirection = (Random.Range(0, 101) <= 50) ? -1 : 1;
        Vector3 randomVector = new Vector3((Random.Range(0,0.5f)) * signDirection, 0, isUpward ? 1 : -1);
        _ballRigidbody.AddForce(randomVector * _firstAccelerationForce, ForceMode.Impulse);
    }

    public void RestartBall()
    {
        _ballRigidbody.velocity = Vector3.zero;
        transform.position = _startPosition;
        StartCoroutine(FirstAccelerationCoroutine(2f));
    }
}
