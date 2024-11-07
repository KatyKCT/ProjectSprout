using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuerillaBranch3Script : Branch
{

    void Start()
    {


        this.branchType = GetComponent<BranchInfo>().branchType;
        this.sproutType = GetComponent<BranchInfo>().sproutType;
        this.currentHeigth = GetComponent<BranchInfo>().currentHeigth;

        StartCoroutine(Growing());

    }


    public override void SpawnPlaces()
    {
        if (onlySpawnSprout == false)
        {
            SpawnBranchPlace(0.15f, 0.8f);
        }

        SpawnSproutPlace(-0.15f, 0.45f);
    }



    void Update()
    {
        SwayBranch();
    }


}
