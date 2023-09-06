using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityEventSequencer 
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
