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
        ChangeAmbient(isWar);
    }

    void ChangeAmbient(bool war) {
        isWar = war;
        if (war) {
            volume.profile = profileWar;
            fogFeatureWar.SetActive(true);
            fogFeaturePeace.SetActive(false);
        } else {
            volume.profile = profilePeace;
            fogFeatureWar.SetActive(false);
            fogFeaturePeace.SetActive(true);
        }
    }


    void Update() {
        if (Input.GetButtonDown("Fire2")) {
            ChangeAmbient(!isWar);
        }
    }
}
