using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    private HealthScript hScript;

    void Awake()
    {
        hScript = GetComponent<HealthScript>();
    }


    public void ActivateShield(bool shieldActive)
    {
        hScript.shieldActivated = shieldActive;
    }
}
