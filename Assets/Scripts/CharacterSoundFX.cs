using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundFX : MonoBehaviour
{
    private AudioSource soundFX;

    [SerializeField]
    private AudioClip attack_sound_1, attack_sound_2, die_sound;

    void Awake()
    {
        soundFX = GetComponent<AudioSource>();
    }

    public void Attack2()
    {
        soundFX.clip = attack_sound_2;
        soundFX.Play();
    }

    public void Die()
    {
        soundFX.clip = die_sound;
        soundFX.Play();
    }

    public void Attack1()
    {
        soundFX.clip = attack_sound_1;
        soundFX.Play();
    }
}
