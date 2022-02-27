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

    public void Add(int i)
    {
        Value += i;
    }

    public void Extract(int i)
    {
        Value -= i;
    }
}