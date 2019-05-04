using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public Transform camera;
    public float speed = 6f;

    public float jumpSpeed = 8f;

    public float gravity = 20f;

    public float rotationSpeed = 6f;

    private Vector3 moveDirection = Vector3.zero;

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

    
    float direction = 0;
    direction = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
        direction += camera.eulerAngles.y;



        if (controller.isGrounded) {

                

            // moveDirection = transform.forward * speed * Time.deltaTime;
            Vector3 horizontalM = Vector3.zero;
            Vector3 verticalM = Vector3.zero;;
            if (horizontal > 0) {
                horizontalM = transform.forward * horizontal;
            } else if (horizontal < 0) {
                horizontalM = (transform.forward * -1) * horizontal;
            }

            if (vertical > 0) {
                verticalM = transform.forward * vertical;
            } else if (vertical < 0) {
                verticalM = (transform.forward * -1) * vertical;
            }
            moveDirection = horizontalM + verticalM;
            // moveDirection = new Vector3(horizontal, 0, vertical);
            // transform.TransformDirection(Vector3.forward);
     
            moveDirection *= speed;

            if (Input.GetButton("Jump")) {
                moveDirection.y = jumpSpeed;
            }
        }
 
    if (horizontal != 0 || vertical != 0) {
        
        transform.rotation = Quaternion.Slerp(
        transform.rotation, 
        Quaternion.Euler (0, direction, 0),
        rotationSpeed * Time.deltaTime);
    }

        // Vector3 nextDir = new Vector3(horizontal, 0, vertical);
// transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, transform.localEulerAngles.z);
    // float angle = Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg;

// transform.rotation = Quaternion.Euler(new Vector3(0,angle,  0));
        // if (nextDir != Vector3.zero) {
            // transform.rotation = camera.TransformDirection(Quaternion.LookRotation(nextDir));
            // transform.rotation = ;
        // }

        // transform.Rotate(0, horizontal, 0);

        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);
    }
}
