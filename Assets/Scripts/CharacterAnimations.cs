using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Walk(bool walk)
    {
        anim.SetBool(AnimTags.WALK_PARAMETER, walk);
    }

    public void Defend(bool def)
    {
        anim.SetBool(AnimTags.DEFEND_PARAMETER, def);
    }

    public void Attack_1()
    {
        anim.SetTrigger(AnimTags.ATTACK_TRIGGER_1);
    }

    public void Attack_2()
    {
        anim.SetTrigger(AnimTags.ATTACK_TRIGGER_2);
    }

    void FreezeAnimation()
    {
        anim.speed = 0;
    }

    public void UnfreezeAnimation()
    {
        anim.speed = 1f;
    }
} // class
