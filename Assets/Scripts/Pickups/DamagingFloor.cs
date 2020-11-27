using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingFloor : InteractableTerrain
{
    public float floorDamage;
    public float damageRate;
    [SerializeField]
    float damageTimer;

    public override void OnTriggerStay(Collider other)
    {
        base.OnTriggerEnter(other);
        if(other.tag == "Player")
        {
            Debug.Log("Touching Player");
            PlayerAttributes player = other.GetComponent<PlayerAttributes>();

            if(damageTimer == 0)
                player.TakeDamage(floorDamage);  

            damageTimer += Time.deltaTime;
            if(damageTimer > damageRate)
                damageTimer = 0;        
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        damageTimer = 0;
    }
}
