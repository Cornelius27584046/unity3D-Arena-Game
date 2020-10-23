using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    CHASE,
    ATTACK
}

public class EnemyController : MonoBehaviour
{
    private CharacterAnimations enemy_anim;
    private NavMeshAgent navAgent;

    private Transform playerTarget;

    public float move_speed = 3.5f;

    public float attack_distance = 1.3f;
    public float chase_player_after_attack_distance = 1f;

    private float wait_before_attack_time = 3f;
    private float attack_timer;

    private EnemyState e_state;

    public GameObject attackPoint;

    private CharacterSoundFX soundFx;

    void Awake()
    {
        soundFx = GetComponentInChildren<CharacterSoundFX>();
        enemy_anim = GetComponent<CharacterAnimations>();
        navAgent = GetComponent<NavMeshAgent>();

        playerTarget = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
    }

    private void Start()
    {
        e_state = EnemyState.CHASE;

        attack_timer = wait_before_attack_time;
    }

    void Update()
    {
        if(e_state == EnemyState.CHASE)
        {
            ChasePlayer();
        }

        if(e_state == EnemyState.ATTACK)
        {
            AttackPlayer();
        }
    }

    void ChasePlayer()
    {
        //playerTarget = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
        navAgent.SetDestination(playerTarget.position);
        navAgent.speed = move_speed;

        if(navAgent.velocity.sqrMagnitude == 0)
        {
            enemy_anim.Walk(false);
        }else
        {
            enemy_anim.Walk(true);
        }

        if(Vector3.Distance(transform.position, playerTarget.position) <= attack_distance)
        {
            e_state = EnemyState.ATTACK;
        }
    }

    void AttackPlayer() 
    {
        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;
        enemy_anim.Walk(false);
        attack_timer += Time.deltaTime;

        if(attack_timer > wait_before_attack_time)
        {
            if(Random.Range(0,2) > 0)
            {
                enemy_anim.Attack_1();
                soundFx.Attack1();
            }
            else
            {
                enemy_anim.Attack_2();
                soundFx.Attack2();
            }

            attack_timer = 0f;
        }

        if(Vector3.Distance(transform.position, playerTarget.position) >
            attack_distance + chase_player_after_attack_distance)
        {
            navAgent.isStopped = false;
            e_state = EnemyState.CHASE;
        }
    }

    void Activate_Attack_Point()
    {
        attackPoint.SetActive(true);
    }

    void Deactivate_Attack_Point()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }
} // class
