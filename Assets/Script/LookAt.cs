﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{


    private Transform CameraView;


    // Use this for initialization
    void Start()
    {

        CameraView = Camera.main.transform;

    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the camera every frame so it keeps looking at the target
        transform.LookAt(CameraView);
    }

}