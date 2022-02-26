using System;
using UnityEngine;


[CreateAssetMenu(fileName = "Bool", menuName = "ScriptebleObject/Bool")]
public class SOBoolData : ScriptableObject
{
    [NonSerialized]
    public bool Value;

    public void SetValue(bool state)
    {
        Value = state;
    }
}