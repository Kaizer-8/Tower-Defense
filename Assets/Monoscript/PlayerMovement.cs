using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 Velocity;
    private Vector3 PlayerMovementInput;
    private Vector3 PlayerMouseInput;
    private float xRot;

    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed;
    [SerializeField] private float sensitivity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        MovePlayer();
        MousePlayerCamera();
    }
    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput);

        if (Input.GetKey(KeyCode.Space))
        {
            Velocity.y = 1f;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            Velocity.y = -1f;
        }
        characterController.Move(MoveVector * speed * Time.deltaTime);
        characterController.Move(Velocity * speed * Time.deltaTime);

        Velocity.y = 0f;
    }
    private void MousePlayerCamera()
    {
        if (Input.GetMouseButton(1))
        {
            xRot -= PlayerMouseInput.y * sensitivity;
            transform.Rotate(0f, PlayerMouseInput.x * sensitivity * 30f, 0f);
            PlayerCamera.transform.localRotation = quaternion.Euler(xRot, 0f, 0f);
        }
    }
}
