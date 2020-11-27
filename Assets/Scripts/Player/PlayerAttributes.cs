using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100;
    public float currentArmour;
    public float maxArmour = 100;

    public float pullSpeed;
    public float pullRadius;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentArmour = maxArmour;
    }

    // Update is called once per frame
    void Update()
    {
        PullingPickups(pullRadius);
    }

    public void TakeDamage(float damage)
    {
        if(currentArmour > damage)
            currentArmour -= damage;
        else if(currentArmour < damage && currentArmour > 0)
        {
            float leftOver = damage - currentArmour;
            currentArmour -= damage;
            currentHealth -= leftOver;
        }
        else            
            currentHealth -= damage;

        if(currentArmour < 0)
            currentArmour = 0;
        if(currentHealth < 0)
            currentHealth = 0;
    }

    public void AddHealth(float health)
    {
        currentHealth += health;
        if(currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    public void AddArmour(float armour)
    {
        currentArmour += armour;
        if(currentArmour > maxArmour)
            currentArmour = maxArmour;
    }

    void PullingPickups(float radius)
    {
        Collider[] objectsInRange = Physics.OverlapSphere(transform.position, radius, 1 << 8); 
        foreach (Collider col in objectsInRange)
        {
            if(col.tag == "HealthPickup" && currentHealth < maxHealth)
                PullPickup(col);
            if(col.tag == "ArmourPickup" && currentArmour < maxArmour)
                PullPickup(col);    
        }
    }

    void PullPickup(Collider col)
    {
        Debug.Log(col.name);
        float step = pullSpeed * Time.deltaTime;
        col.transform.position = Vector3.MoveTowards(col.transform.position, new Vector3(transform.position.x, transform.position.y+transform.localScale.y/2, transform.position.z), step);
    }
}
