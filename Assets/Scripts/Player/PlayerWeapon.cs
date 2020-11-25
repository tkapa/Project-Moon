using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [Tooltip("The weapon that the player is currently holding")]
    public Weapon weapon;

    private bool _isFiring = false;

    public void OnFire(InputAction.CallbackContext context)
    {
        _isFiring = context.ReadValueAsButton();
        
    }

    public void OnReload(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            weapon.Reload();
        }
    }

    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isFiring)
            weapon.Fire();
    }
}