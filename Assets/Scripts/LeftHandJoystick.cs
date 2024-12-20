using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; 

public class LeftHandJoystick : MonoBehaviour
{
    public InputActionProperty leftJoystickMove;
    public float movementSpeed = 1000f;

    public TextMeshProUGUI joystickValueText;

    public GameObject controlledObject;

    private void OnEnable()
    {
        leftJoystickMove.action.Enable();
    }

    private void OnDisable()
    {
        leftJoystickMove.action.Disable();
    }

    private void Update()
    {
        Vector2 joystickInput = leftJoystickMove.action.ReadValue<Vector2>();

        joystickInput = MapJoystickInput(joystickInput);

        if (joystickInput != Vector2.zero)
        {
            Vector3 forward = controlledObject.transform.forward;

            float moveAmountZ = joystickInput.y * 10f * Time.deltaTime; // Forward/backward movement
            float rotationAmountY = joystickInput.x * 50f * Time.deltaTime; // Left/right rotation
            controlledObject.transform.Rotate(0, rotationAmountY, 0);

            Vector3 moveDirection = forward * moveAmountZ;

            controlledObject.transform.position += moveDirection;
        }

        joystickValueText.text = $"Joystick Input: {joystickInput}";
    }

    private Vector2 MapJoystickInput(Vector2 input)
    {
        float deadZone = 0.3f;
        float amplifiedX = Mathf.Abs(input.x) > deadZone ? input.x : 0;
        float amplifiedY = Mathf.Abs(input.y) > deadZone ? input.y : 0;

        amplifiedX = amplifiedX > 0 ? amplifiedX * 1.5f : amplifiedX; 
        amplifiedY = amplifiedY > 0 ? amplifiedY * 1.5f : amplifiedY; 

        return new Vector2(amplifiedX, amplifiedY);
    }
}
