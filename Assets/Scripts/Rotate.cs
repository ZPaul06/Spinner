using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameObject spinner;
    public int rotationFactor;
    private bool running = false;

    void Start()
    {

    }

    
    void Update()
    {
        if (running == true)
        {
            spinner.transform.Rotate(new Vector3(0, 0, Time.deltaTime * -rotationFactor));
        }
    }


    public void setRunning(bool shouldRotate)
    {
        running = shouldRotate;
    }

    public void incRotationFactor(int addToFact)
    {
        rotationFactor += addToFact;
    }

}
