using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    [SerializeField] private Transform pathFinderOffset;
    public Transform target;

    private void Awake() {
        target = FindObjectsOfType<Animator>()[2].transform;
    }

    private void FixedUpdate() {
        if (target) pathFinderOffset.LookAt(target);
    }


}
