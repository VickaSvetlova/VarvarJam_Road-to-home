using System;
using UnityEngine;

namespace Scripts.SO
{
    [CreateAssetMenu (fileName = "Vector2",menuName = "ScriptebleObject/Vector2")]
    public class SOVector2Data : ScriptableObject
    {
        [NonSerialized]
        public Vector2 Value;
    }
}