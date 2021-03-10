using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class HitController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator;

    public HealthBar healthBar;

    public GameObject GameController;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        Debug.Assert(GameController != null);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Damage"))
        { 
            
            DoDamageToPlayer(2);  
            animator.SetBool("Hit", true); 
            Invoke("dmgImpact", 0.8f);
        }
    }

    private void DoDamageToPlayer(int dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameController.GetComponent<GameCtrl>().EndGame();
        }
        healthBar.setHealth(currentHealth);
    }

    private void dmgImpact() 
    { 
            animator.SetBool("Hit", false);   
    }

    public void HealPlayer(int heal)
    {
        currentHealth += heal;
        if (currentHealth > 100)
            currentHealth = 100;
        healthBar.setHealth(currentHealth);
    }
}

