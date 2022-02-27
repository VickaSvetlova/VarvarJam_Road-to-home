using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.SO;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    public SOEventBool _visiblePlayer;
    [SerializeField] private GameObject[] _bodyPart;

    private void OnEnable()
    {
        _visiblePlayer.Event += VisiblePaths;
    }

    public void VisiblePaths(bool stat)
    {
        foreach (var body in _bodyPart)
        {
            body.SetActive(stat);
        }
    }
}