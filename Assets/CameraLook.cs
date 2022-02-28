using System;
using Scripts.SO;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public SOEventBool _switchCam;
    public GameObject _cameraFPS;
    public GameObject _cameraTps;


    private void OnEnable()
    {
        _switchCam.Event += SwitchCam;
    }

    private void SwitchCam(bool obj)
    {
        if (!obj)
        {
            _cameraTps.SetActive(false);
            _cameraFPS.SetActive(true);
        }
        else
        {
            _cameraTps.SetActive(true);
            _cameraFPS.SetActive(false);
        }
    }

    private void OnDisable()
    {
        _switchCam.Event -= SwitchCam;
    }
}