using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class HakoniwaCityInputs : MonoBehaviour
{
    private PlayerInput playerInput;

    [HideInInspector]
    public Vector3 speed;
    [HideInInspector]
    private bool putTent;
    [HideInInspector]
    public Vector3 cameraSpeed;
    [HideInInspector]
    public bool cameraMove;
    [HideInInspector]
    public int rotateCamera;
    [HideInInspector]
    private Vector2 currentPoint;
    private bool touch;

    private bool leftMouseButtonHold;


    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        initMap(playerInput.currentActionMap);
    }

    private void initMap(InputActionMap map)
    {
        map.Disable();

        AddCameraInputMap(map);

        map.Enable();
    }

    private void AddCameraInputMap(InputActionMap map)
    {
        map["ToggleCameraMove"].started += ctx => ToggleCameraMove(ctx);
        map["ToggleCameraMove"].canceled += ctx => ToggleCameraMove(ctx);
        if (map["RotateCameraRight"] == null)
        {
            map.AddAction("RotateCameraRight", InputActionType.Button, "<Keyboard>/e");
        }
        map["RotateCameraRight"].started += ctx => RotateCamera(1);

        if (map["RotateCameraLeft"] == null)
        {
            map.AddAction("RotateCameraLeft", InputActionType.Button, "<Keyboard>/q");
        }
        map["RotateCameraLeft"].started += ctx => RotateCamera(-1);
    }

    private void AddDragOrPointInputMap(InputActionMap map)
    {
        map["LeftMouseButtonHold"].started += ctx => LeftMouseButtonHold(ctx);
        map["LeftMouseButtonHold"].canceled += ctx => LeftMouseButtonHold(ctx);
    }

    public void OnMove(InputValue value)
    {
        Vector2 vec = value.Get<Vector2>();
        speed = new Vector3(vec.y, 0f, -vec.x);
    }

    public void OnPutTent(InputValue value)
    {
        putTent = value.isPressed;
    }
    public bool ConsumePutTent()
    {
        bool ret = putTent;
        putTent = false;
        return ret;
    }

    public void OnLook(InputValue value)
    {
        Vector2 vec = value.Get<Vector2>();
        cameraSpeed = new Vector3(vec.y, 0f, -vec.x);
    }
    private void ToggleCameraMove(InputAction.CallbackContext context)
    {
        cameraMove = context.ReadValueAsButton();
    }
    private void RotateCamera(int value)
    {
        rotateCamera = value;
    }

    private void LeftMouseButtonHold(InputAction.CallbackContext context)
    {
        leftMouseButtonHold = context.ReadValueAsButton();
    }
    public void OnPoint(InputValue value)
    {
        currentPoint = value.Get<Vector2>();
    }

    public void OnTouch(InputValue value)
    {
        touch = value.isPressed;
    }
    public bool GetTouchPoint(ref Vector2 value, bool ignoreOnUIElement)
    {
        if (!ignoreOnUIElement && EventSystem.current.IsPointerOverGameObject())
        {
            ConsumeTouch();
            return false;
        }

        if (touch == true)
        {
            value = currentPoint;
        }

        bool success = touch;
        ConsumeTouch();
        return success;
    }

    public bool GetTouchPoint(ref Vector2 value)
    {
        return GetTouchPoint(ref value, false);
    }

    public Vector2 GetCursorPoint()
    {
        return currentPoint;
    }
    private void ConsumeTouch()
    {
        touch = false;
    }
}
