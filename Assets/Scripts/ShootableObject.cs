using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObject : MonoBehaviour
{
    public float maximumHealth = 100f;
    public float currentHealth;

    private void OnValidate()
    {
        if (currentHealth != maximumHealth)
            currentHealth = maximumHealth;
    }

    /// <summary>
    /// Reduces the Current Health of the object.
    /// </summary>
    /// <param name="damage">Number to reduce Current Health by.</param>
    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
            OnZeroHealth(damage);
    }

    /// <summary>
    /// What happens when on zero health.
    /// </summary>
    /// <param name="damage">Equal to the amount of damage it took before it died</param>
    public virtual void OnZeroHealth(float damage)
    {
        Debug.Log($"{gameObject.name}: {nameof(OnZeroHealth)}");
    }
}
