using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private CharacterController controller;
    private Vector2 inputVector;
    private Vector3 moveDirection;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }

    private void Update()
    {
        // Calculate orientation relative to camera
        Transform cam = Camera.main.transform;
        Vector3 forward = cam.forward;
        Vector3 right = cam.right;

        forward.y = 0; // Ignore vertical component
        right.y = 0; // Ignore vertical component
        forward.Normalize();
        right.Normalize();

        moveDirection = forward * inputVector.y + right * inputVector.x;

        if (moveDirection.magnitude > 0.1f)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * 10f);
        }

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
