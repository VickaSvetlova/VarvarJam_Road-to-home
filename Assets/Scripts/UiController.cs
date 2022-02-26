
using Scripts.SO;
using UnityEngine;
using UnityEngine.Serialization;

public class UiController : MonoBehaviour
{
    [FormerlySerializedAs("_eventOnspeach")] [SerializeField] private SOEventBool eventBoolOnspeach;
    [SerializeField] private GameObject _captionOnSpech;

    private void OnEnable()
    {
        eventBoolOnspeach.Event += OnVisibleOnSpech;
    }

    private void OnVisibleOnSpech(bool obj)
    {
        _captionOnSpech.SetActive(obj);
    }
}