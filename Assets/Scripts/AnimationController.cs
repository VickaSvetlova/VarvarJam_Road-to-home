using Scripts.SO;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private SOVector2Data _input;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        _animator.SetFloat("InputX", _input.Value.x);
        _animator.SetFloat("InputY", _input.Value.y);
    }
}