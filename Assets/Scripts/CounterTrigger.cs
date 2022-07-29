using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterTrigger : MonoBehaviour
{

    public GameObject manager;

    private int rotCounter = -1;

    private void OnTriggerEnter(Collider col)
    {
        if (col.name.Equals("Start"))
        {
            rotCounter += 1;
            
            if (rotCounter > 0)
            {
                manager.GetComponent<Main>().incCounter();
                manager.GetComponent<Main>().incRotationFactor(2);
            }
        }
    }


    void Start()
    {

    }


    void Update()
    {
        
    }

}
