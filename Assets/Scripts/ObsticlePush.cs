using System;
using Scripts.Interfaces;
using UnityEngine;

public class ObsticlePush : MonoBehaviour
{
    [SerializeField] private float _forceMantitude;
    [SerializeField] private float _lenghtRay;
    [SerializeField] private LayerMask _layerMask;

    private void Update()
    {
        RayCast();
        CheckingPushObject();
    }

    private void CheckingPushObject()
    {
        var hit = RayCast();

        if (hit.collider != null && hit.collider.GetComponent<IMovable>() != null)
        {
            Rigidbody attachedRigidbody = hit.collider.attachedRigidbody;
            if (attachedRigidbody != null)
            {
               
                Vector3 forceDirection =hit.collider.transform.position-transform.position;
                forceDirection.y = 0;
                forceDirection.Normalize();
                attachedRigidbody.AddForceAtPosition(forceDirection*_forceMantitude,transform.position, ForceMode.Impulse);
            }
        }
    }

    private RaycastHit RayCast()
    {
        RaycastHit hit;
        var hiting = Physics.Raycast(transform.position, transform.forward, out hit, _lenghtRay, _layerMask);
        if (hiting)
        {
            Debug.Log("hit" + hit.collider.name);
        }

        return hit;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * _lenghtRay);
    }

    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.collider.GetComponent<IMovable>() != null)
    //     {
    //         Rigidbody attachedRigidbody = other.collider.attachedRigidbody;
    //         if (attachedRigidbody != null)
    //         {
    //             var position = transform.position;
    //             Vector3 forceDirection = other.gameObject.transform.position - position;
    //             forceDirection.y = 0;
    //             forceDirection.Normalize();
    //
    //             attachedRigidbody.AddForceAtPosition(forceDirection * _forceMantitude, position, ForceMode.Impulse);
    //         }
    //     }
    // }
}