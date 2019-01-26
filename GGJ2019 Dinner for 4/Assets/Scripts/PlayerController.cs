using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
    public float customGravity = 9.8f;
    float horizontal;
    float vertical;
    Vector3 movement;

    private CharacterController controller;
    private Vector3 playerVelocity;

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

        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, (Input.GetAxis("Vertical")));
        movement *= speed;//sets speed of movement
        movement = Vector3.ClampMagnitude(movement, speed);
        movement = transform.TransformDirection(movement);

        playerVelocity.y = playerVelocity.y + (Physics.gravity.y * customGravity * Time.deltaTime);//add gravity to player's velocity
        controller.Move(playerVelocity * Time.deltaTime);//apply gravity to character with Move

        controller.Move(movement * Time.deltaTime);
    }
}
