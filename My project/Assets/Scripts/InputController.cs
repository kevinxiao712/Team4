using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField]
    private float mouseMoveScale = 1;
    [SerializeField]
    private float mouseBendScale = 1;
    [SerializeField]
    private float joystickRotateScale = 1;

    private Vector2 mousePosDelta;

    private Vector2 previousJoystickInput;
    private Vector2 currentJoystickInput;

    private FishController fishController;


    private void Awake()
    {
        fishController = GetComponent<FishController>();
    }

    private void Start()
    {
        mousePosDelta = Vector2.zero;

        previousJoystickInput = Vector2.zero;
        currentJoystickInput = Vector2.zero;
    }

    public void OnMouseMove(InputAction.CallbackContext context)
    {
        if (Mouse.current != null)
        {
            if (Mouse.current.leftButton.isPressed)
            {
                Debug.Log("mousePosDelta.x = " + mousePosDelta.x);
                mousePosDelta.x += context.ReadValue<Vector2>().x;
            }
            else
            {
                mousePosDelta.x = 0;
            }

            fishController.SetDrivingForce(mousePosDelta.x * mouseMoveScale);
        }
    }

    public void OnGamepadMove(InputAction.CallbackContext context)
    {
        float input = context.ReadValue<Vector2>().x;

        fishController.SetDrivingForce(input);
    }

    public void OnMouseBend(InputAction.CallbackContext context)
    {
        if (Mouse.current != null &&
            Mouse.current.leftButton.isPressed)
        {
            float input = context.ReadValue<Vector2>().y * mouseBendScale;

            fishController.ChangeAngle(input);
        }
    }

    public void OnGamepadBend(InputAction.CallbackContext context)
    {
        float joystickRotation = 0;

        Debug.Log("OnGamepadBend Called!");

        currentJoystickInput = context.ReadValue<Vector2>();

        if (currentJoystickInput != Vector2.zero && 
            previousJoystickInput != Vector2.zero)
        {

        }

        joystickRotation = Vector2.SignedAngle(previousJoystickInput, currentJoystickInput);

        previousJoystickInput = currentJoystickInput;

        fishController.ChangeAngle(joystickRotation * joystickRotateScale);
    }
}
