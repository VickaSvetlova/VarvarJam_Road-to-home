using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.SO;
using UnityEngine;
using UnityEngine.Events;

public class EventEnable : MonoBehaviour
{
    [SerializeReference] private SOEventBool _stateCursour;
    [SerializeField] private float _timeToStart = 1;
    public UnityEvent _event;

    private void OnEnable()
    {
        Invoke("EventAction", _timeToStart);
    }

    private void EventAction()
    {
        _event?.Invoke();
        if (_stateCursour != null)
        {
            _stateCursour.Event?.Invoke(true);
        }
        enabled = false;
    }
}