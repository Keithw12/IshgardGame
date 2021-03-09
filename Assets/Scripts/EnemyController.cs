using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int enemyHealth;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            animator.SetBool("isDead", true);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            damageSkeleton(25);
        }
    }

    private void damageSkeleton(int dmg)
    {
        enemyHealth -= dmg; 
    }
}
