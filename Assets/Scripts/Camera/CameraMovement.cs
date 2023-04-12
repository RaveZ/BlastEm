using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Vector3 cameraOffset;
    public Transform playerTarget;
    public float camMoveSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, playerTarget.position + cameraOffset, camMoveSpeed *Time.deltaTime);
    }
}
