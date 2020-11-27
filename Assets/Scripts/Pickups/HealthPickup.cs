using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : InteractableObject
{
    public float addHealth;

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
            player.AddHealth(addHealth);
        }
        Destroy(gameObject);
    }
}
