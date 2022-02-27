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

    [SerializeField] private VolumeFogFeature fogFeaturePeace;
    [SerializeField] private VolumeFogFeature fogFeatureWar;


    public bool isWar = false;


    private void Start() {
        if (isWar) {

        }
    }

    void ChangeAmbient() {

    }


    void Update() {
        if (Input.GetButtonDown("Fire2")) {
            if (isWar) {
                volume.profile = profilePeace;
                fogFeatureWar.SetActive(false);
                fogFeaturePeace.SetActive(true);
                isWar = false;
            } else {
                volume.profile = profileWar;
                fogFeatureWar.SetActive(true);
                fogFeaturePeace.SetActive(false);
                isWar = true;
            }
        }
    }
}
