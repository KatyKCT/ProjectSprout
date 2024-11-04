using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuerillaBranch1Script : Branch
{


    void Start()
    {


        this.branchType = GetComponent<BranchInfo>().branchType;
        this.sproutType = GetComponent<BranchInfo>().sproutType;
        this.currentHeigth = GetComponent<BranchInfo>().currentHeigth;

        GetComponent<Transform>().localScale = new Vector3(0.05f, 0.05f, 1);
        StartCoroutine(Growing());

    }


    public override void SpawnPlaces()
    {
        if (onlySpawnSprout == false)
        {
            SpawnBranchPlace(0f, 0.8f);
        }

        SpawnSproutPlace(0f, 0.38f);
    }



    void Update()
    {
        SwayBranch();
    }


}