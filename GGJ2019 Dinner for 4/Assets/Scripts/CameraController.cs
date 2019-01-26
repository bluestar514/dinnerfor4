using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform playerTransform, lookTransform;
    public bool invert;
    public float sensivity = 5f;
    public Vector2 lookLimits = new Vector2(-70f, 80f);

    private Vector2 lookAngles;
    private Vector2 mouseDirection;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mouseDirection = new Vector2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));

        lookAngles.x += mouseDirection.x * sensivity * (invert ? 1f : -1f);
        lookAngles.y += mouseDirection.y * sensivity;

        lookAngles.x = Mathf.Clamp(lookAngles.x, lookLimits.x, lookLimits.y);

        lookTransform.localRotation = Quaternion.Euler(lookAngles.x, 0f, 0f);
        playerTransform.localRotation = Quaternion.Euler(0f, lookAngles.y, 0f);
    }
} 

