using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TossableCoin : ShootableObject
{
    public float ricochetRadius;
    public float critMultiplier;
    public float effectDuration;

    // Start is called before the first frame update
    void Start()
    {
        maximumHealth = 0.1f;
        currentHealth = 0.1f;
    }

    public override void OnZeroHealth(float damage)
    {
        //StartCoroutine(RicochetEffect(transform));
        AreaDamageEnemies(transform.position, ricochetRadius, damage);
    }

    void AreaDamageEnemies(Vector3 location, float radius, float damage)
    {
        Collider[] objectsInRange = Physics.OverlapSphere(location, radius); 
        foreach (Collider col in objectsInRange)
        {
            Enemy enemy = col.GetComponent<Enemy>();
            if (enemy != null && enemy.tag == "Enemy")
            {
                enemy.TakeDamage(damage*critMultiplier);

                Debug.DrawLine(transform.position, enemy.transform.position, Color.yellow, 3f);
            }                 
        }
    }

    //IEnumerator RicochetEffect(Transform currentPos)
    //{
    //    AreaDamageEnemies(currentPos.position, ricochetRadius, ricochetDamage);

    //    yield return null;
    //}
}
