using System;
using DialogueEditor;
using Scripts.Interfaces;
using Scripts.SO;
using UnityEditor.Scripting;
using UnityEngine;
using UnityEngine.Events;

public class InteractebleController : MonoBehaviour
{
    [SerializeField] private SOEventGameObject _eventGameObject;
    [SerializeField] private SOEventBool _cursorState;
    [SerializeField] private SOBoolData _onDialog;
    [SerializeField] private SOEventBool _onSpeach;
    [SerializeField] private SOBoolData _isUse;
    [SerializeField] private float _lenghtRay;
    [SerializeField] private LayerMask _layerMask;
    private Camera _camera;
    [SerializeField] private Vector3 _offsetPositionAim = new Vector3();
    private Vector3 destination;
    public UnityEvent _eventStart;
    public UnityEvent _eventEnd;
    [SerializeField] private float _distanceInteracteble;

    private Collider iobjectCollider;
    private IDetectableObject iobject;

    private void OnEnable()
    {
        _camera = Camera.main;
        ConversationManager.OnConversationStarted += DialogStart;
        ConversationManager.OnConversationEnded += DialogExit;
    }

    private void DialogExit()
    {
        _cursorState.Event?.Invoke(false);
        _eventEnd?.Invoke();
    }

    private void DialogStart()
    {
        _cursorState.Event?.Invoke(true);
        _eventStart?.Invoke();
    }

    private void Update()
    {
        if (_isUse.Value && iobject != null) {
            iobject?.OnRise();
            _onDialog.Value = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        var objectDetect = other.GetComponent<IDetectableObject>();
        if (objectDetect != null) {
            iobjectCollider = other;
            iobject = objectDetect;
            _onSpeach.Event?.Invoke(true);

            if (_isUse.Value) {
                objectDetect?.OnRise();
                _onDialog.Value = true;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (iobjectCollider == other) {
            _onSpeach.Event?.Invoke(false);
            iobjectCollider = null;
            iobject = null;
        }
    }

}