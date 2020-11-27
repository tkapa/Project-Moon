using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text ammoCounter;
    public Slider reloadCountdown;

    public Text healthNum;
    public Slider healthBar;
    public Text armourNum;
    public Slider armourBar;

    public Text accuracyCounter;
    public Text accuracyBuffTotal;

    PlayerWeapon pw;
    PlayerAttributes pa;

    // Start is called before the first frame update
    void Start()
    {
        pw = GetComponent<PlayerWeapon>();
        pa = GetComponent<PlayerAttributes>();

        reloadCountdown.maxValue = pw.weapon.reloadTime;

        healthBar.maxValue = pa.maxHealth;
        armourBar.maxValue = pa.maxArmour;
    }

    // Update is called once per frame
    void Update()
    {
        ammoCounter.text = pw.weapon.ammoCount+" | "+pw.weapon.reserveAmmo;
        reloadCountdown.value = pw.weapon._reloadTimer;

        healthNum.text = (int)pa.currentHealth+"";
        healthBar.value = pa.currentHealth;
        armourNum.text = (int)pa.currentArmour+"";
        armourBar.value = pa.currentArmour;

        accuracyCounter.text = ""+pw.weapon.accuracyCombo;
        accuracyBuffTotal.text = "x"+pw.weapon.accuracyDamBuff.ToString("F")+"!";
    }
}
