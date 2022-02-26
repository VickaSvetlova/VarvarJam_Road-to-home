using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SOInt", menuName = "ScriptebleObject/SOInt")]
internal class SOIntData : ScriptableObject
{
    [NonSerialized]
    public int Value;

    public void SetValue(int state)
    {
        Value = state;
    }
}