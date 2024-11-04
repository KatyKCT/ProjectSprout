using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuerillaBranch2Script : Branch
{


    void Start()
    {

        this.branchType = GetComponent<BranchInfo>().branchType;
        this.sproutType = GetComponent<BranchInfo>().sproutType;
        this.currentHeigth = GetComponent<BranchInfo>().currentHeigth;

        GetComponent<Transform>().localScale = new Vector3(0.05f, 0.05f, 1); //Makes the branch small so it can grow
        StartCoroutine(Growing());

    }


    public override void SpawnPlaces()
    {
        if (onlySpawnSprout == false)
        {
            SpawnBranchPlace(-0.3f, 0.68f);
            SpawnBranchPlace(0.34f, 0.62f);
        }
        //SpawnSproutPlace(0f, 0f);
    }



    void Update()
    {
        SwayBranch();
    }



}
