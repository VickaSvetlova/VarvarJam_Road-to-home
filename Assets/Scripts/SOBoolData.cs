using System;
using UnityEngine;


[CreateAssetMenu(fileName = "Bool", menuName = "ScriptebleObject/Bool")]
internal class SOBoolData : ScriptableObject
{
    [NonSerialized]
    public bool Value;
}