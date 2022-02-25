using Scripts.SO;
using UnityEngine;

public class ControlInput : MonoBehaviour
{
    [SerializeField] private SOVector2Data _vector;
    private Vector2 _input;

    void Update()
    {
        _vector.Value.x = Input.GetAxis("Horizontal");
        _vector.Value.y = Input.GetAxis("Vertical");
    }
}