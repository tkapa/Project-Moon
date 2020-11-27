using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public CapsuleCollider cc;

    // Start is called before the first frame update
    public virtual void Start()
    {
        if(GetComponent<CapsuleCollider>() == null)
            gameObject.AddComponent<CapsuleCollider>();
        cc = GetComponent<CapsuleCollider>();
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
