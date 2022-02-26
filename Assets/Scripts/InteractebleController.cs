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
        RayCast();
        Debug.DrawRay(_camera.transform.position, _camera.transform.forward * _lenghtRay, Color.green);
    }

    private void RayCast()
    {
        //Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0) + _offsetPositionAim);

        RaycastHit hit;
        var raycast = Physics.Raycast(transform.position, transform.forward, out hit, _distanceInteracteble, _layerMask);
        if (raycast)
        {
            var objectDetect = hit.collider.GetComponent<IDetectableObject>();
            if (objectDetect != null && Vector3.Distance(transform.position, hit.point) < _distanceInteracteble)
            {
                _onSpeach.Event?.Invoke(true);

                if (_isUse.Value)
                {
                    objectDetect?.OnRise();
                    _onDialog.Value = true;
                }
            }
        }
        else
        {
            _onSpeach.Event?.Invoke(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * _distanceInteracteble);
    }
}