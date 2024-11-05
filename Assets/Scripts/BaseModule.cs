using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseModule : MonoBehaviour
{

    //Plant stats (effects entire plant)

    public float growthSpeed;
    public float baseDamage;
    public float baseAttackSpeed;
    public float baseRange;
    public float baseKnockback;
    public int maxHeight;
    public int maxHeigthAverage;

    public string branchType;
    public string sproutType;


    private void Start()
    {
        maxHeight = maxHeigthAverage + Random.Range(-1, 2);
        BaseSpawnBranchPlace(0f, 0f);
    }





    void BaseSpawnBranchPlace(float x, float y)
    {
        Object toSpawn = Resources.Load("BranchPlace");
        GameObject spawnedBranchPlace = (GameObject)Instantiate(toSpawn, this.transform.position + new Vector3(x, y, 0), Quaternion.identity, this.transform);
        spawnedBranchPlace.GetComponent<BranchPlacer>().currentHeigth = 1;
        spawnedBranchPlace.GetComponent<BranchPlacer>().branchType = this.branchType;
        spawnedBranchPlace.GetComponent<BranchPlacer>().sproutType = this.sproutType;
    }

}
