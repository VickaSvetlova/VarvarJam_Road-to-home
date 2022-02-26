using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    [SerializeField] private GameObject[] _bodyPart;

    public void VisiblePaths(bool stat)
    {
        foreach (var body in _bodyPart)
        {
            body.SetActive(stat);
        }
    }
}