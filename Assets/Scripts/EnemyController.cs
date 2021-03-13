using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int enemyHealth;
    public Animator animator;
    public Collider foot;
    private GameObject gameStateCtrl;
    private SpawnController spawnController;
    public GameObject heartDrop;
    private bool dead = false;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(foot != null);
        Debug.Assert(animator != null);
        Debug.Assert(heartDrop != null);
        gameStateCtrl = GameObject.Find("Game State Controller");
        spawnController = gameStateCtrl.GetComponent<SpawnController>();
        enemyHealth = 100 * spawnController.waveNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0 && !dead)
        {
            dead = true;
            animator.SetBool("isDead", true);
            foot.enabled = false;
            rollForDrop();
            Invoke("destroyEnemy", 15f);
            spawnController.enemyKilled();
        }
    }

    void rollForDrop()
    {
        int drop = Random.Range(1,4);
        // 25% chance of drop
        if (drop == 1)
        {
            Instantiate(heartDrop, gameObject.transform.position, gameObject.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            damageSkeleton(100);
        }
    }

    private void damageSkeleton(int dmg)
    {
        enemyHealth -= dmg; 
    }

    public void setEnemyHealth(int health)
    {
        enemyHealth = health;
    }


    private void destroyEnemy()
    {
        Destroy(gameObject);
    }
}
