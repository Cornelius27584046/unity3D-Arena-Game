﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;

    float x_death = -90f;
    private float death_smooth = 0.9f;
    private float rotate_time = 0.23f;
    private bool playerDied = false;

    public bool isPlayer;

    [HideInInspector]
    public bool shieldActivated;

    [SerializeField]
    private Image health_UI;

    private CharacterSoundFX soundFx;

    private void Awake()
    {
        soundFx = GetComponentInChildren<CharacterSoundFX>(); // in children because it's attached to player child
    }

    private void Update()
    {
        if(playerDied)
        {
            RotateAfterDeath();
        }
    }

    private void RotateAfterDeath()
    {
        transform.eulerAngles = new Vector3(
            Mathf.Lerp(transform.eulerAngles.x, x_death, Time.deltaTime * death_smooth),
            transform.eulerAngles.y, transform.eulerAngles.z);
    }

    IEnumerator AllowRotate()
    {
        playerDied = true;

        yield return new WaitForSeconds(rotate_time);

        playerDied = false;
    }

    public void ApplyDamage(float damage)
    {
        if (shieldActivated) return;

        health -= damage;

        if(health_UI != null)
        {
            health_UI.fillAmount = health / 100f;
        }

        if(health <= 0)
        {
            soundFx.Die();

            GetComponent<Animator>().enabled = false;
            StartCoroutine(AllowRotate());

            if(isPlayer)
            {
                GetComponent<PlayerMove>().enabled = false;
                GetComponent<PlayerAttackInput>().enabled = false;

                // Camera.main.transform.SetParent(null);
                GameObject.FindGameObjectWithTag("MainCamera")
                    .GetComponent<CameraFollow>().enabled = false;

                GameObject.FindGameObjectWithTag(Tags.ENEMY_TAG)
                    .GetComponent<EnemyController>().enabled = false;
            }else
            {
                GetComponent<EnemyController>().enabled = false;
                GetComponent<NavMeshAgent>().enabled = false;
            }
        }
    }
}
