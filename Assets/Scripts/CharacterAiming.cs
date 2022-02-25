using UnityEngine;

public class CharacterAiming : MonoBehaviour
{
    [SerializeField] private float _turnSpeed = 15f;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, yawCamera, 0f), _turnSpeed * Time.fixedDeltaTime);
    }
}