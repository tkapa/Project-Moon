using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWSUI : MonoBehaviour
{
    public Slider healthBar;
    public Canvas enemyCanvas;

    Transform player;
    Enemy enemyScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCanvas.transform.LookAt(player.position);
    }

    public void AssignHBValues(float maximumHealth, float currentHealth)
    {
        healthBar.maxValue = maximumHealth;
        healthBar.value = currentHealth;
    }
}
