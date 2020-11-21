﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TossableCoin : ShootableObject
{
    public float ricochetRadius;
    public float ricochetDamage;

    LineRenderer lr;
    public float lineWidth;

    public GameObject debugSphere;

    // Start is called before the first frame update
    void Start()
    {
        lr = gameObject.GetComponent<LineRenderer>();

        MaximumHealth = 0.1f;
        CurrentHealth = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        Transform currentPos = transform;
        AreaDamageEnemies(currentPos.position, ricochetRadius, ricochetDamage);

        Instantiate(debugSphere);
        debugSphere.transform.localScale = new Vector3(ricochetRadius, ricochetRadius, ricochetRadius);
        debugSphere.transform.position = transform.position;
    }

    void AreaDamageEnemies(Vector3 location, float radius, float damage)
    {
        Collider[] objectsInRange = Physics.OverlapSphere(location, radius); 
        List<Collider> enemiesInRange = new List<Collider>();
        foreach (Collider col in objectsInRange)
        {
            Enemy enemy = col.GetComponent<Enemy>();
            if (enemy != null && enemy.tag == "Enemy")
            {
                enemy.TakeDamage(damage); 
                enemiesInRange.Add(col);
            }                 
        }
        DrawRicochets(enemiesInRange);
    }

    void DrawRicochets(List<Collider> enemies)
    {
        Debug.Log("Enemy Count: "+enemies.Count);
        int lrPosLen = enemies.Count*2;
        lr.positionCount = lrPosLen;
        lr.startWidth = lineWidth;
        lr.endWidth = lineWidth;

        List<Vector3> points = new List<Vector3>();
        for (int i = 0; i < lrPosLen/2; i++)
        {
            points.Add(transform.position);
            points.Add(enemies[i].transform.position);
        }
        for (int k = 0; k < lrPosLen; k++)
        {
            Debug.Log("Line Pos: "+points[k]);
        }

        lr.SetPositions(points.ToArray());
    }
}
