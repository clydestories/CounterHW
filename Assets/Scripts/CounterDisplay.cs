using TMPro;
using UnityEngine;

public class CounterDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private TextMeshProUGUI _stateText;
    [SerializeField] private Counter _counter;

    private void Start()
    {
        UpdateCounter();
        UpdateState();
    }

    private void OnEnable()
    {
        _counter.CounterIncreased.AddListener(UpdateCounter);
        _counter.CounterIncreased.AddListener(UpdateState);
    }

    private void UpdateCounter()
    {
        _counterText.text = _counter.CounterValue.ToString();
    }

    private void UpdateState()
    {
        string enabledStateText = "On";
        string disabledStateText = "Off";

        Debug.Log("qwe");

        if (_counter.IsActive)
        {
            _stateText.text = enabledStateText;
        }
        else
        {
            _stateText.text = disabledStateText;
        }
    }

    private void OnDisable()
    {
        _counter.CounterIncreased.RemoveListener(UpdateCounter);
        _counter.CounterIncreased.RemoveListener(UpdateState);
    }
}
