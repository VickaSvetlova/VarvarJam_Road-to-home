using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.SO;
using UnityEngine;
using UnityEngine.Events;

public class EventEnable : MonoBehaviour
{
    [SerializeReference] private SOEventBool _stateCursour;
    public UnityEvent _event;

    private void OnEnable()
    {
        Invoke("EventAction", 2);
    }

    private void EventAction()
    {
        if (_event == null) return;
        _event?.Invoke();
        _stateCursour.Event?.Invoke(true);
        enabled = false;
    }
}