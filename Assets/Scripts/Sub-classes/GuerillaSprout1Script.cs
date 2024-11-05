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

        swayOffset = Random.Range(-10, 10);

        GetComponent<Transform>().localScale = new Vector3(0.05f, 0.05f, 1); //Makes the sprout small so it can grow
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
