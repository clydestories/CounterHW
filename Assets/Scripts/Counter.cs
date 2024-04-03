using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    private bool _isActive = false;
    private int _counterValue = 0;
    private float _delay = 0.5f;
    private bool _isDelayed = false;

    public UnityEvent CounterIncreased;
    public UnityEvent StateChanged;

    public bool IsActive => _isActive;
    public int CounterValue => _counterValue;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isActive = !_isActive;
            StateChanged?.Invoke();
        }

        if (_isActive && _isDelayed == false)
        {
            StartCoroutine(nameof(IncreaseCounter));
        }
    }

    private IEnumerator IncreaseCounter()
    {
        _isDelayed = true;
        _counterValue++;
        CounterIncreased?.Invoke();
        yield return new WaitForSeconds(_delay);
        _isDelayed = false;
    }
}
