﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public float rotationSpeed = 180f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f,rotationSpeed*Time.deltaTime,0.0f, Space.World);
        
    }
}
