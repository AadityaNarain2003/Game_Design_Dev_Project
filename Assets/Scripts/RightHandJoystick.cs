using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class RightHandJoystick : MonoBehaviour
{
    public InputActionProperty rightJoystickMove;
    public float rotationSpeed = 5000f;

    public TextMeshProUGUI joystickValueText;

    public GameObject controlledObject;

    private void OnEnable()
    {
        rightJoystickMove.action.Enable();
    }

    private void OnDisable()
    {
        rightJoystickMove.action.Disable();
    }

    private void Update()
    {
        Vector2 joystickInput = rightJoystickMove.action.ReadValue<Vector2>();


        if (joystickInput != Vector2.zero)
        {
            float rotationAmountX = joystickInput.y * rotationSpeed * Time.deltaTime;
            float rotationAmountZ = -joystickInput.x * rotationSpeed * Time.deltaTime; // Left/right rotation
            controlledObject.transform.Rotate(rotationAmountX,0,rotationAmountZ);
        }

        joystickValueText.text = $"Joystick Input: {joystickInput}";
    }
}
