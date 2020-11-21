using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObject : MonoBehaviour
{
    public float MaximumHealth = 100f;
    public float CurrentHealth;

    private void OnValidate()
    {
        if (CurrentHealth != MaximumHealth)
            CurrentHealth = MaximumHealth;
    }

    /// <summary>
    /// Reduces the Current Health of the object.
    /// </summary>
    /// <param name="damage">Number to reduce Current Health by.</param>
    public virtual void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0f)
            OnZeroHealth();
    }

    /// <summary>
    /// What happens when on zero health.
    /// </summary>
    public virtual void OnZeroHealth()
    {
        Debug.Log($"{gameObject.name}: {nameof(OnZeroHealth)}");
    }
}
