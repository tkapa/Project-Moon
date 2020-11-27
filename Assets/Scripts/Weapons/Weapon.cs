using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

/// <summary>
/// All weapons should inherit from the weapon class.
/// </summary>
public class Weapon : MonoBehaviour
{
    [Tooltip("The maximum amount of ammo that the weapon can hold")]
    public int maximumAmmo = 10;

    [Tooltip("The current amount of ammo in the weapon")]
    public int ammoCount;

    [Tooltip("Specifies fire rate for the weapon in rounds per minute")]
    public float fireRate = 60;

    [Tooltip("Specifies how long the weapon takes to reload")]
    public float reloadTime = 1f;

    [Tooltip("The Range of this Weapon")]
    public float weaponRange = 100f;

    [Tooltip("The damage of this Weapon")]
    public float weaponDamage = 50f;

    private float _fireCooldown;
    private float _fireCooldownTimer;
    public float _reloadTimer;

    private Transform _mainCameraTransform;

    public virtual void OnValidate()
    {
        ammoCount = maximumAmmo;
    }

    private void Awake()
    {
        _fireCooldown = 60 / fireRate;
        _fireCooldownTimer = 0f;
        _reloadTimer = 0f;

        //This is kind of scuffed and won't support Multiplayer
        _mainCameraTransform = Camera.main.transform;
    }

    /// <summary>
    /// Fire action is called from <see cref="PlayerWeapon"/>
    /// Manages what should happen when the player attemps to fire.
    /// </summary>
    public virtual void Fire()
    {
        if (CanFire())
        {
            ammoCount--;
            Projectile();
            _fireCooldownTimer = _fireCooldown;
        }
        //Else: Can't fire
    }

    /// <summary>
    /// Defines the behaviour for this weapon's projectiles.
    /// Defaults to a raycast up to the weapon range,
    /// damaging the shootable object hit.
    /// </summary>
    public virtual void Projectile()
    {
        //Fire Hitscan
        RaycastHit hit;
        if (Physics.Raycast(
            _mainCameraTransform.position,
            _mainCameraTransform.forward,
            out hit,
            weaponRange))
        {
            Debug.Log($"Hit {hit.transform.name} with {gameObject.name}");

            var shootableObject = hit.transform.GetComponent<ShootableObject>();

            if (shootableObject != null)
            {
                shootableObject.TakeDamage(weaponDamage);
            }
        }
    }

    /// <summary>
    /// Reload action is called from <see cref="PlayerWeapon"/>
    /// Manages what should happen when the player attempts to reload.
    /// </summary>
    public virtual void Reload()
    {
        if (_reloadTimer <= 0f && ammoCount != maximumAmmo)
        {
            _reloadTimer = reloadTime;
            StartCoroutine(nameof(ReloadCountdown));
        }
    }

    private void FixedUpdate()
    {
        if (_fireCooldownTimer > 0f)
        {
            _fireCooldownTimer -= Time.fixedDeltaTime;
        }
    }

    /// <summary>
    /// A function to determine whether or not this weapon should fire a shot
    /// - The fire rate cooldown has elapsed
    /// - The current ammo count of the weapon is greater than 0
    /// - The weapon is not currently reloading
    /// </summary>
    /// <returns>Whether or not this weapon can fire</returns>
    private bool CanFire()
    {
        return (
            (_fireCooldownTimer <= 0f) &&
            (ammoCount > 0) &&
            (_reloadTimer <= 0f)
        );
    }

    /// <summary>
    /// Manages the countdown until the weapon is reloaded.
    /// </summary>
    private IEnumerator ReloadCountdown()
    {
        while (_reloadTimer > 0f)
        {
            _reloadTimer -= Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        ammoCount = maximumAmmo;

        yield return null;
    }
}
