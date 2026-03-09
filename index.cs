using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public string fileName;
    private float vehicleSpeed = 15.0f;
    private float turnSpeed = 20.0f;
    private float horizontalInput;
    private float forwardInput;
    public string inputID;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Console.WriteLine("Hello, world");
    }

    // Update is called once per frame
    void Update()
    {
        // Get user's input
        //Vertical and horizontal
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);
        // Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * vehicleSpeed * forwardInput);
        // Turn the vehicle
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
