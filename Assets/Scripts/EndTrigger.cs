using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    public GameObject manager;

    private void OnTriggerExit(Collider col)
    {
        if (col.name.Equals("Player"))
        {
            manager.GetComponent<Main>().toggleEnd();
        }
    }


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
