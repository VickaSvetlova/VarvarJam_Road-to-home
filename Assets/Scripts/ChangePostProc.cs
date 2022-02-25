using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ChangePostProc : MonoBehaviour {

    [SerializeField] private Volume volume;

    [SerializeField] private VolumeProfile profilePeace;
    [SerializeField] private VolumeProfile profileWar;


    void Update() {
        if (Input.GetButtonDown("Fire2")) {
            if (volume.profile == profilePeace) {
                volume.profile = profileWar;
            } else {
                volume.profile = profilePeace;
            }
        }
    }
}
