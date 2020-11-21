using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWSUI : MonoBehaviour
{
    public Slider healthBar;
    public Canvas enemyCanvas;

    GameObject player;
    Enemy enemyScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyScript = gameObject.GetComponent<Enemy>();

        AssignHBValues();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCanvas.transform.LookAt(player.transform.position);
    }

    public void AssignHBValues()
    {
        healthBar.maxValue = enemyScript.MaximumHealth;
        healthBar.value = enemyScript.CurrentHealth;
    }
}
