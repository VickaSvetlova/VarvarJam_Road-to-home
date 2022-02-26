
using Scripts.SO;
using UnityEngine;

public class LockCursor : MonoBehaviour
{
    [SerializeField] private SOEventBool _cursorVisible;

    private void OnEnable()
    {
        SetCursor(false);
        _cursorVisible.Event += SetCursor;
    }

    private void SetCursor(bool b)
    {
        Cursor.lockState = b ? CursorLockMode.Confined : CursorLockMode.Locked;
        Cursor.visible = b;
    }

    private void OnDisable()
    {
        _cursorVisible.Event -= SetCursor;
    }
}