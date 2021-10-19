using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _timer;
    [SerializeField] private float _time;

    private int _speedMultiplier = 2;
    private int _speedDivider = 2;

    private float _timeValue;


    private void Start()
    {
        _timeValue = _time;

        PlayTime();
    }

    private void Update()
    {
        var offset = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        transform.Translate(offset * _speed * Time.deltaTime);
    }

    public void IncreaseSpeed()
    {
        _speed *= _speedMultiplier;

        _timer = true;
        _time = _timeValue;

        PlayTime();
    }

    private IEnumerator WaitForSeconds()
    {
        yield return new WaitForFixedUpdate();

        PlayTime();
    }

    private void PlayTime()
    {
        if (_timer)
        {
            _time -= Time.deltaTime;

            if (_time < 0)
            {
                _timer = false;
                _speed /= _speedDivider;
            }

            StartCoroutine(WaitForSeconds());
        }
    }
}
