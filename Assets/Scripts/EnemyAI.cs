using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    NavMeshAgent navMesh;

    public Transform target;
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

        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        bool isRunning = animator.GetBool("isRunning");
        bool isWalking = animator.GetBool("isWalking");
        bool isDead = animator.GetBool("isDead");
        bool isKicking = animator.GetBool("isKicking");
        bool isPunching_Left = animator.GetBool("isPunching_Left");
        bool isPunching_Right = animator.GetBool("isPunching_Right");
        */
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
}
