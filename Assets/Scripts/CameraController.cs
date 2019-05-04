using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Camera Controller.
 */
public class CameraController : MonoBehaviour
{
    /** Player Object reference */
    public GameObject player;

    /** Verical turning speed */
    public float verticalTurnSpeed = 4.0f;


    /** Horizontal turning speed */
    public float horizontalTurnSpeed = 2.0f;

    /** The offset */
    private Vector3 offset;

    /** Handles Start */
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    /** Called after each frame update */
    void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Vertical2") * verticalTurnSpeed, Vector3.up) * offset;
        offset = Quaternion.AngleAxis(Input.GetAxis("Horizontal2") * horizontalTurnSpeed, Vector3.right) * offset;
        transform.position = player.transform.position + offset;

        /** Always look at the player */
        transform.LookAt(player.transform.position);
    }

}
