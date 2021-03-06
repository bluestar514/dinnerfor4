﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    bool holding;
    GameObject isHeld;
    public float maxDistance = 2.5f;
    public Texture2D crosshairImage;
    public Texture2D activecrosshairImage;
    Texture2D inuse;
    // Start is called before the first frame update
    void Start()
    {
        holding = false;
    }

    /*
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ingredient" && !holding && Input.GetKeyDown(KeyCode.Mouse0))
        {
            other.transform.parent = this.transform;
        }

        if (other.tag == "bear" && Input.GetKeyDown(KeyCode.Mouse0))
        {
            //interact
        }
    }
    */

    void OnGUI()
    {
        float xMin = (Screen.width / 2) - (inuse.width / 2);
        float yMin = (Screen.height / 2) - (inuse.height / 2);
        GUI.DrawTexture(new Rect(xMin, yMin, inuse.width, inuse.height), inuse);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        //Debug.DrawRay(transform.position, fwd * 2.5f, Color.magenta, 0.1f, true);
        if (Physics.Raycast(transform.position, fwd, out hit, maxDistance))
        {
            if(holding && isHeld != hit.collider.gameObject)
            {
                drop();
            }
            if (hit.collider.gameObject.CompareTag("ingredient"))
            {
                inuse = activecrosshairImage;
                //print(hit.distance);
                if (holding)
                {
                    hit.collider.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    hit.collider.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                }

                if (!holding && Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hit.collider.gameObject.transform.parent = this.transform;
                    hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = false;

                    holding = true;
                    isHeld = hit.collider.gameObject;
                }
                else if (holding && Input.GetKeyDown(KeyCode.Mouse0))
                {
                    drop();
                }
            }
            else if (hit.collider.gameObject.CompareTag("bear") && Input.GetKeyDown(KeyCode.Mouse0))
            {
                //print("talkable");
                hit.collider.gameObject.GetComponent<Speaker>().OpenDialogueBox();
            }


        }
        else
        {
            inuse = crosshairImage;
            drop();
        }

    }

    void drop()
    {
        if (this.transform.childCount > 0)
        {
            this.transform.GetChild(0).GetComponent<Rigidbody>().useGravity = true;
            this.transform.DetachChildren();
            holding = false;
        }
    }
}
