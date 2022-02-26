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


    public bool isWar = false;


    void Update() {
        if (Input.GetButtonDown("Fire2")) {
            if (isWar) {
                volume.profile = profilePeace;
                fogFeature.SetActive(false);
                isWar = false;
            } else {
                volume.profile = profileWar;
                fogFeature.SetActive(true);
                isWar = true;
            }
        }
    }
}
