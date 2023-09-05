using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventSequencer : MonoBehaviour
{
    [SerializeField]
    private UnityEvent[] _sequence;

    public void StartSequence()
    {
        foreach (var @event in _sequence)
        {
            @event.Invoke();
        }
    }
}
