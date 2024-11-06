using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchPlacer : MonoBehaviour
{
        
    public int currentHeigth;
    public string branchType;
    public string sproutType;

    Object[] branchPrefabModules;
    public bool isAvailable = true;

    // Start is called before the first frame update
    void Start()
    {
       
        branchPrefabModules = Resources.LoadAll(branchType);


        SpawnRandomBranch();
    }


    public void SpawnRandomBranch()
    {
        if (isAvailable == true)
        {
            GameObject toSpawn = (GameObject)branchPrefabModules[Random.Range(0, branchPrefabModules.Length)];
            GameObject spawned = Instantiate(toSpawn, this.transform.position, Quaternion.identity, this.transform);
            spawned.GetComponent<BranchInfo>().currentHeigth = this.currentHeigth;
            spawned.GetComponent<BranchInfo>().branchType = this.branchType;
            spawned.GetComponent<BranchInfo>().sproutType = this.sproutType;
            isAvailable = false;
        }
    }



    public IEnumerator WaitAndSpawnBranch()
    {
        yield return new WaitForSecondsRealtime(GetComponentInParent<BaseModule>().regrowTime);
        SpawnRandomBranch();
    }


}
