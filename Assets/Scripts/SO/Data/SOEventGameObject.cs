using System;
using UnityEngine;

namespace Scripts.SO
{
    [CreateAssetMenu(fileName = "SOEventGameObject", menuName = "ScriptebleObject/SOEventGameobject")]
    public class SOEventGameObject : ScriptableObject
    {
        public Action<GameObject> Event;

        [NonSerialized]
        public GameObject Value;
    }
}