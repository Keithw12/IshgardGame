using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    NavMeshAgent navMesh;

    public Transform target; 
    public GameObject playerObject;
    public Animator animator;
    public float stoppingDistance;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

        navMesh = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        navMesh.stoppingDistance = stoppingDistance;
        navMesh.speed = speed; 

        playerObject = GameObject.Find("3RD Person Cowboy");
        target = playerObject.GetComponent<Transform>(); 



        
    }

    // Update is called once per frame
    void Update()
    {

        bool isDead = animator.GetBool("isDead");


        if (!isDead)
        {
            navMesh.SetDestination(target.position);
            transform.LookAt(target);

            if (navMesh.remainingDistance > stoppingDistance)
            {
                navMesh.speed = speed;
                animator.SetBool("isWalking", true);
                animator.SetBool("isKicking", false);

            }
            else
            {
                navMesh.speed = 0f;
                animator.SetBool("isWalking", false);
                animator.SetBool("isKicking", true);

            }
        }
        else
        {
            navMesh.speed = 0f;
        }
        
    }
}
