using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Third person character controller.
 */
public class ThirdPersonController : MonoBehaviour
{
    /** Camera object transform reference  */
    public Transform camera;
    /** Player movement speed */
    public float speed = 6f;

    /** Player jump speed */
    public float jumpSpeed = 8f;

    /** Gravity intensity */
    public float gravity = 20f;

    /** Player ratation speed */
    public float rotationSpeed = 6f;

    /** Movement direction */
    private Vector3 moveDirection = Vector3.zero;

    /** Reference to character controller */
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            HandleMovement(horizontal, vertical);
            if (Input.GetButton("Jump"))
            {
                HandleJump();
            }
        }

        HandleRotation(horizontal, vertical);

        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;

        // Move character
        controller.Move(moveDirection * Time.deltaTime);
    }

    /**
     * Handles player movement.
     */
    private void HandleMovement(float horizontal, float vertical)
    {
        Vector3 horizontalM = Vector3.zero;
        Vector3 verticalM = Vector3.zero;
        if (horizontal > 0)
        {
            horizontalM = transform.forward * horizontal;
        }
        else if (horizontal < 0)
        {
            horizontalM = (transform.forward * -1) * horizontal;
        }

        if (vertical > 0)
        {
            verticalM = transform.forward * vertical;
        }
        else if (vertical < 0)
        {
            verticalM = (transform.forward * -1) * vertical;
        }
        moveDirection = horizontalM + verticalM;

        moveDirection *= speed;
    }

    /**
     * Handle jumping.
     */
    private void HandleJump()
    {
        moveDirection.y = jumpSpeed;
    }

    /**
     * Handle player rotation.
     */
    private void HandleRotation(float horizontal, float vertical)
    {
        float direction = 0;
        direction = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
        direction += camera.eulerAngles.y;

        if (horizontal != 0 || vertical != 0)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.Euler(0, direction, 0),
                rotationSpeed * Time.deltaTime);
        }
    }
}
