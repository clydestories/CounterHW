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
            if (_isActive)
            {
                TurnOff();
            }
            else
            {
                TurnOn();
            }

            StateChanged?.Invoke();
        }

        StartCoroutine(nameof(IncreaseCounter));
    }

    private IEnumerator IncreaseCounter()
    {
        yield return new WaitWhile(() => _isActive == false);
        _counterValue++;
        CounterIncreased?.Invoke();
    }

    private void TurnOn()
    {
        _isActive = true;
    }

    private void TurnOff()
    {
        _isActive = false;
    }
}
