using System;
using Scripts.SO;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class AnimationController : MonoBehaviour
{
    [SerializeField] private SOVector2Data _input;
    [SerializeField] private SOBoolData _inputJump;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _jumpForce;
    private Vector3 _jumpDirection = Vector3.up;

    [FormerlySerializedAs("_lenghtRay")] [SerializeField]
    private float _lenghtRayOnGround;

    [SerializeField] private LayerMask _layerMask;
    private Rigidbody _rigidbody;
    private bool _isGround;
    private float _lenghtRayOnWall;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        //GroundCheck();
       // Jump();
    }

    private void Jump()
    {
        var hit = RayCast(transform.position, -transform.up, _lenghtRayOnGround).collider;
        if (hit)
        {
            if (_inputJump)
            {
                _rigidbody.AddForce(_jumpDirection * _jumpForce, ForceMode.Impulse);
            }
        }
    }

    private void GroundCheck()
    {
        var hit = RayCast(transform.position, -transform.up, _lenghtRayOnGround).collider;
        if (!hit && _rigidbody.velocity.y < -1)
        {
            _animator.SetBool("fall", true);
        }
        else
        {
            _animator.SetBool("fall", false);
        }

        if (!hit && _rigidbody.velocity.y > 0)
        {
            _animator.SetBool("jump", true);
        }
        else
        {
            _animator.SetBool("jump", false);
        }
    }

    private void Move()
    {
        _animator.SetFloat("InputX", _input.Value.x);
        _animator.SetFloat("InputY", _input.Value.y);
    }

    private RaycastHit RayCast(Vector3 origin, Vector3 direction, float lenghtRay)
    {
        RaycastHit hit;
        var hiting = Physics.Raycast(origin, direction, out hit, lenghtRay, _layerMask);
        if (hiting)
        {
            Debug.Log("hit" + hit.collider.name);
        }

        return hit;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, -transform.up * _lenghtRayOnGround);
    }
}