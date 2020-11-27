using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourPickup : InteractableObject
{
    public float addArmour;

    public override void Start()
    {
        base.Start();
        cc.radius = 1;
    }

    public override void OnTriggerEnter(Collider other) 
    {
        base.OnTriggerEnter(other);
        if(other.tag == "Player")
        {
            PlayerAttributes player = other.GetComponent<PlayerAttributes>();
            player.AddArmour(addArmour);
        }
        Destroy(gameObject);
    }
}
