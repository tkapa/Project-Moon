using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ShootableObject
{
    EnemyWSUI enemyWSUI;

    // Start is called before the first frame update
    void Start()
    {
        enemyWSUI = gameObject.GetComponent<EnemyWSUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        enemyWSUI.AssignHBValues();
    }
}
