using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuerillaSprout1Script : Sprout
{

    int swayOffset;

    void Start()
    {
        projectileType = "GuerillaProjectile1";

        this.growthSpeed = GetComponentInParent<BaseModule>().growthSpeed;
        this.baseDamage = GetComponentInParent<BaseModule>().baseDamage;
        this.baseAttackSpeed = GetComponentInParent<BaseModule>().baseAttackSpeed;
        this.baseRange = GetComponentInParent<BaseModule>().baseRange;
        this.baseKnockback = GetComponentInParent<BaseModule>().baseKnockback;

        swayOffset = Random.Range(-10, 10);

        StartCoroutine(Growing());
        StartCoroutine(ShotClosestEnemy());

    }

    

    void Update()
    {
        if (isIdle == true)
        {
            SwaySprout(swayOffset);
        }

    }
}
