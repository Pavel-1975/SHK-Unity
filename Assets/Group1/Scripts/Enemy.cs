using UnityEngine;

public class Enemy : MonoBehaviour
{
    private readonly float _maxDistance = 2;

    private Vector3 _target;


    private void Start()
    {
        SetTarget();
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _maxDistance * Time.deltaTime);

        if (transform.position == _target)
            SetTarget();
    }

    private void SetTarget()
    {
        int coefficient = 4;

        _target = Random.insideUnitCircle * coefficient;
    }
}
