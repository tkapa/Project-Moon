using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTerrain : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider cc;

    // Start is called before the first frame update
    public virtual void Start()
    {
        if(GetComponent<BoxCollider>() == null)
            gameObject.AddComponent<BoxCollider>();
        cc = GetComponent<BoxCollider>();
        cc.isTrigger = true;
    }

    public virtual void OnTriggerEnter(Collider other) 
    {

    }

    public virtual void OnTriggerStay(Collider other) 
    {
        
    }

    public virtual void OnTriggerExit(Collider other) 
    {
        
    }
}
