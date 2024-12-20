using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuerillaSprout1Script : Sprout
{

    

    void Start()
    {
        projectileType = "GuerillaProjectile1";

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
        PointAtEnemy(direction);
    }

    public override void HowToMoveIdle()
    {
        SwaySprout();
    }



}
