using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{

    private CharacterAnimations playerAnimation;

    public GameObject attackPoint;

    private PlayerShield shield;

    private CharacterSoundFX soundFx;

    void Awake()
    {
        soundFx = GetComponentInChildren<CharacterSoundFX>();
        playerAnimation = GetComponent<CharacterAnimations>();
        shield = GetComponent<PlayerShield>();
    } // awake


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J)) // defend
        {
            playerAnimation.Defend(true);

            shield.ActivateShield(true);
        }
        if (Input.GetKeyUp(KeyCode.J)) // defend
        {
            playerAnimation.UnfreezeAnimation();
            playerAnimation.Defend(false);

            shield.ActivateShield(false);
        }

        if (Input.GetKeyDown(KeyCode.K)) // attack
        {
            if(Random.Range(0, 2) > 0) // Range(inclusive, exclusive) but with float the second param is included
            {
                playerAnimation.Attack_1();
                soundFx.Attack1();
            }else
            {
                playerAnimation.Attack_2();
                soundFx.Attack2();
            }
        }
    } // update

    void Activate_Attack_Point()
    {
        attackPoint.SetActive(true);
    }

    void Deactivate_Attack_Point()
    {
        if(attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }
} // class
