using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWSUI : MonoBehaviour
{
    public Slider healthBar;
    public Canvas enemyCanvas;
    private Transform _player;

    private void OnValidate()
    {
        if(_player == null)
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemyCanvas.transform.LookAt(_player.position);
    }

    public void AssignHBValues(float maximumHealth, float currentHealth)
    {
        healthBar.maxValue = maximumHealth;
        healthBar.value = currentHealth;
    }
}
