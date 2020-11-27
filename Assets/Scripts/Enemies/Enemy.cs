using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ShootableObject
{
    [SerializeField] private EnemyWSUI _enemyWSUI;

    private void OnValidate()
    {
        if (_enemyWSUI == null && GetComponent<EnemyWSUI>())
        {
            _enemyWSUI = GetComponent<EnemyWSUI>();            
        }            
        else if(!GetComponent<EnemyWSUI>())
            Debug.LogError($"{gameObject.name} does not have an EnemyWSUI");
        currentHealth = maximumHealth;
    }

    private void Start()
    {
        _enemyWSUI.AssignHBValues(maximumHealth, currentHealth);
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        _enemyWSUI.AssignHBValues(maximumHealth, currentHealth);
    }
}
