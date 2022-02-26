using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experiemntal.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ChangePostProc : MonoBehaviour {

    [SerializeField] private Volume volume;

    [SerializeField] private VolumeProfile profilePeace;
    [SerializeField] private VolumeProfile profileWar;

    [SerializeField] private VolumeFogFeature fogFeature;


    void Update() {
        if (Input.GetButtonDown("Fire2")) {
            if (volume.profile == profilePeace) {
                volume.profile = profileWar;
                fogFeature.SetActive(true);
            } else {
                volume.profile = profilePeace;
                fogFeature.SetActive(false);
            }
        }
    }
}
