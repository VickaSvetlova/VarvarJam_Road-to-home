using Scripts.SO;
using UnityEngine;

public class ControlInput : MonoBehaviour
{
    [SerializeField] private SOVector2Data _vector;
    [SerializeField] private SOBoolData _jump;
    [SerializeField] private SOBoolData _use;
    [SerializeField] private SOBoolData _dialogActive;

    private Vector2 _input;

    void Update()
    {
        _use.Value = Input.GetKey(KeyCode.E);
        if (_dialogActive.Value) return;
        _vector.Value.x = Input.GetAxis("Horizontal");
        _vector.Value.y = Input.GetAxis("Vertical");
        _jump.Value = Input.GetKey(KeyCode.Space);
   //     Debug.Log("use " + _use.Value);
    }
}