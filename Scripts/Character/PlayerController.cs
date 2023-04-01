using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arbor;

public class PlayerController : MonoBehaviour
{
    public float _walkSpeed = 2;
    public float _runSpeed = 5;
    public Camera camera;

    public float gravity = -15.0f;
    public bool grounded = true;
    public float groundedOffset = -0.14f;
    public float groundedRadius = 0.28f;
    public LayerMask groundLayers;

    private float _verticalVelocity;
    private float _terminalVelocity = 53.0f;

    private ParameterContainer parameterContainer;

    public HakoniwaCityInputs inputs;

    // Start is called before the first frame update
    void Start()
    {
        parameterContainer = GetComponent<ParameterContainer>();
    }

    // Update is called once per frame
    void Update()
    {
        Gravity();
        GroundedCheck();
        Move();
        Action();
    }

    private void Move()
    {
        float currentRotation = camera.transform.rotation.eulerAngles.y;

        // 0, 90, 180, 270ˆÈŠO‚ÌŽž‚ÉˆÚ“®‚ªŽÎ‚ß‚É‚È‚é
        float speedX = -inputs.speed.z * Mathf.Cos(currentRotation * Mathf.Deg2Rad) + inputs.speed.x * Mathf.Sin(currentRotation * Mathf.Deg2Rad);
        float speedZ = -inputs.speed.z * Mathf.Sin(currentRotation * Mathf.Deg2Rad) - inputs.speed.x * Mathf.Cos(currentRotation * Mathf.Deg2Rad);

        Vector3 speed = new Vector3(speedX, 0f, -speedZ) * _walkSpeed;

        //transform.LookAt(transform.position + speed);
        //transform.Translate(speed * Time.deltaTime, Space.World);
        parameterContainer.SetVector3("Speed", speed);
    }

    private void GroundedCheck()
    {
        // set sphere position, with offset
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - groundedOffset,
            transform.position.z);
        grounded = Physics.CheckSphere(spherePosition, groundedRadius, groundLayers,
            QueryTriggerInteraction.Ignore);

    }

    private void Gravity()
    {
        if (grounded)
        {
            // stop our velocity dropping infinitely when grounded
            if (_verticalVelocity < 0.0f)
            {
                _verticalVelocity = -2f;
            }
        }

        // apply gravity over time if under terminal (multiply by delta time twice to linearly speed up over time)
        if (_verticalVelocity < _terminalVelocity)
        {
            _verticalVelocity += gravity * Time.deltaTime;
        }
    }

    private void Action()
    {
        if (inputs.ConsumePutTent())
        {
            parameterContainer.SetString("Action", "PutTent");
        }
    }
    private void OnDrawGizmosSelected()
    {
        Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
        Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

        if (grounded) Gizmos.color = transparentGreen;
        else Gizmos.color = transparentRed;

        // when selected, draw a gizmo in the position of, and matching radius of, the grounded collider
        Gizmos.DrawSphere(
            new Vector3(transform.position.x, transform.position.y - groundedOffset, transform.position.z),
            groundedRadius);
    }

}
