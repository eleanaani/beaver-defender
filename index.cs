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

public class FollowPlayer : MonoBehaviour
{   
    public GameObject player;
    public KeyCode switchKey = KeyCode.C;

    //Settings for the view from behind the vehicle
    private Vector3 behindViewPosition = new Vector3(0, 5, -7);
    private Vector3 behindViewRotation = new Vector3(17, 0, 0);

    //Settings for the first person view
    private Vector3 firstViewPosition = new Vector3(0, 2, 1);
    private Vector3 firstViewRotation = new Vector3(12, 0, 0);

    //Settings for the view change
    private bool isBehindView = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(switchKey))
        {
            isBehindView = !isBehindView;
        }

        if (isBehindView)
        {
            // Offset behind view position and rotation by adding to the player's position
            transform.position = player.transform.position + behindViewPosition;
            transform.rotation = Quaternion.Euler(behindViewRotation);
        }
        
    }
}
