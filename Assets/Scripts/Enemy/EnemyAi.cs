using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;

    //Zombie Speed
    public float walkSpeed;
    public float chaseSpeed;

    //attack attribute
    bool lookAtPlayer;// look at player only once when attack()

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool AlreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    

    //Animation
    private ZombieAnim m_AnimController;
    public ZombieAnim AnimController
    {
        get
        {
            if (m_AnimController == null)
            {
                m_AnimController = GetComponent<ZombieAnim>();
            }
            return m_AnimController;
        }
    }


    private void Awake()
    {
        player = GameObject.Find("PlayerMain").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        //Check for sight and AttackRange
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        

        if(isPlaying(AnimController.zombieAnimation, "Attack"))
        {
            
            AttackPlayer();
            
        }
        else
        {
            if (!playerInSightRange && !playerInAttackRange) Patrolling();
            if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            if (playerInAttackRange && playerInSightRange) AttackPlayer();
        }

        

    }

    private void Patrolling()
    {
        agent.speed = walkSpeed;
        AnimController.Patrol();
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpointReached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;  
    }

    private void SearchWalkPoint()
    {
        //calculate random point in range
        float RandomZ = Random.Range(-walkPointRange, walkPointRange);
        float RandomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + RandomX, transform.position.y, transform.position.z + RandomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;

    }

    private void ChasePlayer()
    {

        agent.speed = chaseSpeed;
        AnimController.Chase();
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        
        //make sure enemy dont move when attack 
        agent.SetDestination(transform.position);


        
        if (!AlreadyAttacked)
        {
            //attackCode here
            AnimController.attack();
            //make enemy lookatPlayer
            Vector3 playerDirection = player.position - new Vector3(transform.position.x, 0, transform.position.z);
            transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            
            AlreadyAttacked = true;
            
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        AlreadyAttacked = false;
        
    }

    bool isPlaying(Animator Anim, string stateName)
    {
        if(Anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) && 
            Anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
