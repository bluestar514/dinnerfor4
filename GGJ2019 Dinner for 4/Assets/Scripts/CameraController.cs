using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject character;
    Vector2 mouseLook;
    Vector2 smoothCam;
    public float sens = 7f;
    public float smooth = 3f;

    // Start is called before the first frame update
    void Start()
    {
        character = transform.parent.gameObject;//set this camera as the child of gameobject
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 = 
    }
}
