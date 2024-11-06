using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpBranch1Script : Branch
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
            SpawnBranchPlace(0.1f, 0.72f);
        }

        SpawnSproutPlace(0.12f, 0.4f);
    }



    void Update()
    {
        SwayBranch();
    }
}
