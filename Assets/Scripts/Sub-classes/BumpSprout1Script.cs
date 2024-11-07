using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpSprout1Script : Sprout
{


    void Start()
    {
        projectileType = "BumpProjectile1";

        this.growthSpeed = GetComponentInParent<BaseModule>().growthSpeed;
        this.baseDamage = GetComponentInParent<BaseModule>().baseDamage;
        this.baseAttackSpeed = GetComponentInParent<BaseModule>().baseAttackSpeed;
        this.baseRange = GetComponentInParent<BaseModule>().baseRange;
        this.baseKnockback = GetComponentInParent<BaseModule>().baseKnockback;


        StartCoroutine(Growing());
        StartCoroutine(ShotClosestEnemy());

    }


    public override void HowToMoveShooting(Vector3 direction)
    {
        PointLeftRight(direction);
    }

    public override void HowToMoveIdle()
    {
        SwaySprout();
    }

}
