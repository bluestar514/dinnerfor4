﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene("HouseScene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
