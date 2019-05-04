using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    public float distance = 6f;

    public float verticalTurnSpeed = 4.0f;
    public float horizontalTurnSpeed = 2.0f;

    private Vector3 offset;

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
        transform.LookAt(player.transform.position);
    }

}
