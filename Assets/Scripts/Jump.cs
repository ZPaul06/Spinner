using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public Rigidbody rigBod;
    private bool running = false; 

    void Start()
    {

    }


    void Update()
    {
        if (running)
        {
            if (Input.GetKeyDown("space"))
            {
                rigBod.AddForce(new Vector3(0, 11, 0), ForceMode.VelocityChange);
            }
        }
    }

    public void setRunning(bool shouldRotate)
    {
        running = shouldRotate;
    }

}
