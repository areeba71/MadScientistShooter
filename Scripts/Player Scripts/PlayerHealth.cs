using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float health = 100f;

    private PlayerMovement playerMovement;

    [SerializeField]
    private Slider healthSlider;
    
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    public void TakeDamage (float damageAmount)
    {
        if (health <= 0f)
            return;

        health -= damageAmount;
        if (health <= 0)
        {
            // inform player died
            playerMovement.PlayerDeid();

            GameplayController.instance.RestartGame();

        }

        healthSlider.value = health;
    }

}
