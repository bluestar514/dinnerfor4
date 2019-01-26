using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 8f;
    public float gravity = -9.8f;
    float horizontal;
    float vertical;
    Vector3 movement;

    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;//disappear the cursor
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.Locked;//cursor comes back
        }

        movement = new Vector3(Input.GetAxis("Vertical"), 0, (Input.GetAxis("Horizontal")));
        movement *= speed;//sets speed of movement
        movement = Vector3.ClampMagnitude(movement, speed);
        movement = transform.TransformDirection(movement);
        controller.SimpleMove(movement * Time.deltaTime);
    }
}
