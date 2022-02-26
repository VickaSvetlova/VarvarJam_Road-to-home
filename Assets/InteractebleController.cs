using DialogueEditor;
using Scripts.Interfaces;
using UnityEditor.Scripting;
using UnityEngine;
using UnityEngine.Events;

public class InteractebleController : MonoBehaviour
{
    [SerializeField] private SOBoolData _onDialog;
    [SerializeField] private SOBoolData _isUse;
    [SerializeField] private float _lenghtRay;
    [SerializeField] private LayerMask _layerMask;
    private Camera _camera;
    [SerializeField] private Vector3 _offsetPositionAim = new Vector3();
    private Vector3 destination;
    public UnityEvent _eventStart;
    public UnityEvent _eventEnd;

    private void OnEnable()
    {
        _camera = Camera.main;
        ConversationManager.OnConversationStarted += DialogStart;
        ConversationManager.OnConversationEnded += DialogExit;
    }

    private void DialogExit()
    {
        _eventEnd?.Invoke();
    }

    private void DialogStart()
    {
        _eventStart?.Invoke();
    }

    private void Update()
    {
        RayCast();
        Debug.DrawRay(_camera.transform.position, _camera.transform.forward * _lenghtRay, Color.green);
    }

    private Vector3 RayCast()
    {
        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0) + _offsetPositionAim);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var objectDetect = hit.collider.GetComponent<IDetectableObject>();
            if (objectDetect != null && _isUse.Value)
            {
                objectDetect?.OnRise();
                _onDialog.Value = true;
            }
        }
        else
        {
            destination = ray.GetPoint(100000);
        }

        return destination;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(destination, 5);
    }
}