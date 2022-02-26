using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Scripts.SO
{
    [CreateAssetMenu(fileName = "SOEvent", menuName = "ScriptebleObject/SOEvent")]
    public class SOEventBool : ScriptableObject
    {
        public  Action<bool> Event;
    }
}