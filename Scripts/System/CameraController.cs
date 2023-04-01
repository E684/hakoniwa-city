using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public HakoniwaCityInputs inputs;
    public float moveSpeed = 5;


    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();

    }

    private void Move()
    {
        if (inputs.cameraMove)
        {
            float currentRotation = transform.rotation.eulerAngles.y;

            float speedX = -inputs.cameraSpeed.z * Mathf.Cos(currentRotation * Mathf.Deg2Rad) + inputs.cameraSpeed.x * Mathf.Sin(currentRotation * Mathf.Deg2Rad);
            float speedZ = -inputs.cameraSpeed.z * Mathf.Sin(currentRotation * Mathf.Deg2Rad) - inputs.cameraSpeed.x * Mathf.Cos(currentRotation * Mathf.Deg2Rad);

            Vector3 speed = new Vector3(speedX, 0f, -speedZ) * moveSpeed;

            transform.Translate(speed * Time.deltaTime, Space.World);
        }
    }

    private void Rotate()
    {
        if (inputs.rotateCamera != 0)
        {
            Vector3 rotation = new Vector3(0f, 30f * inputs.rotateCamera, 0f);
            transform.Rotate(rotation, Space.World);
            inputs.rotateCamera = 0;
        }
    }
}
