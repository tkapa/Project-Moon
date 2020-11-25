using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text ammoCounter;
    public Slider reloadCountdown;

    PlayerWeapon pw;

    // Start is called before the first frame update
    void Start()
    {
        pw = GetComponent<PlayerWeapon>();

        reloadCountdown.maxValue = pw.weapon.reloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        ammoCounter.text = pw.weapon.ammoCount+" / "+pw.weapon.maximumAmmo;
        reloadCountdown.value = pw.weapon._reloadTimer;
    }
}
