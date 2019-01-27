using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour{
    public Transform playerCam;
    public LayerMask RayMask;
    private RaycastHit hit;

    private Transform currentObject;
    private float length;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

        // If LMB is pressed, casts a raycast that hits objects. If it has the tag, then it will pick up the object.
        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(playerCam.position, playerCam.forward.normalized * 20, out hit, Mathf.Infinity, RayMask)) {
                if (hit.collider.gameObject.tag == "PickableObject") {
                    Debug.Log("Hit!");
                    Pickup(hit.transform);
                }
                Debug.DrawRay(playerCam.position, playerCam.forward * 20, Color.red, 200);
                Debug.Log("Missed!");
            }
        }

        // If RMB is pressed, it will drop the object.
        if (Input.GetMouseButtonDown(1)) {
            Drop();
        }

        // Moves the object through the function.
        if (currentObject) {
            Move();
        }
    }

    public void Pickup(Transform newObject) {
        Debug.Log("Picked up!");
        currentObject = newObject;
        length = Vector3.Distance(playerCam.position, newObject.position) / 2;
        currentObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void Move() {
        currentObject.position = playerCam.position + playerCam.forward * length;
    }

    public void Drop() {
        Debug.Log("Dropped it!");
        currentObject.GetComponent<Rigidbody>().isKinematic = false;
        currentObject = null;
    }
}
