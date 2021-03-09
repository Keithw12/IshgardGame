using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Damage"))
        {
            DoDamageToPlayer(5);
        }
    }

    private void DoDamageToPlayer(int dmg)
    {
        currentHealth -= dmg;
        healthBar.setHealth(currentHealth);

    }

    public void HealPlayer(int heal)
    {
        currentHealth += heal;
        healthBar.setHealth(currentHealth);
    }
}

