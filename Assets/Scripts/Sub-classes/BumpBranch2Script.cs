using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpBranch2Script : Branch
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
            SpawnBranchPlace(-0.25f, 0.63f);
            SpawnBranchPlace(0.36f, 0.8f);
        }
        //SpawnSproutPlace(0f, 0f);
    }



    void Update()
    {
        SwayBranch();
    }

}
